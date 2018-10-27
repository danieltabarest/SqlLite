using System;
using System.Collections.Generic;
using System.Linq;
using Todo.LocalData.Exceptions;
using Todo.LocalData.Models;
using NsuGo.Definition.Interfaces.Data;
using SQLite;

namespace Todo.LocalData
{
    public sealed class DatabaseProvider : SQLiteConnection, IDatabaseProvider
    {
        private static object locker = new object();

        public DatabaseProvider(string databasePath)
            : base(databasePath)
        {
            CreateTables();
        }


        private void CreateTables()
        {
            try
            {
                RunInTransaction(() =>
                {
                    CreateTable<AccountHold>();
                    CreateTable<AccountSummary>();
                    CreateTable<Announcement>();
                    CreateTable<Assignment>();
                    CreateTable<Content>();
                    CreateTable<Course>();
                    CreateTable<File>();
                    CreateTable<Folder>();
                    CreateTable<Grade>();
                    CreateTable<Staff>();
                    CreateTable<StaffCourseRoster>();
                    CreateTable<Term>();
                    CreateTable<User>();
                });
            }
            catch (Exception ex)
            {
                throw new DatabaseException("An error occurred while making an attempt to create database tables", ex);
            }
        }

        public int DeleteItem<TItem>(TItem item) where TItem : IPersistableEntity, new()
        {
            try
            {
                lock (locker)
                {
                    return Delete<TItem>(item);
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"An error occurred while attempting to delete an item with the id: {item.Id}", ex);
            }
        }

        public int DeleteItems<TItem>() where TItem : IPersistableEntity, new()
        {
            try
            {
                lock (locker)
                {
                    return DeleteAll<TItem>();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"An error occurred while attempting to delete all items from the {typeof(TItem).Name} table.", ex);
            }
        }

        public int ExecuteQuery(string query, params object[] args)
        {
            try
            {
                lock (locker)
                {
                    return Execute(query, args);
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"An error occurred while attempting to execute the query: \"{query}\".", ex);
            }
        }

        public TResult GetItem<TResult, TQuery>(TQuery id) where TResult : IPersistableEntity, new()
        {
            try
            {
                lock (locker)
                {
                    return Find<TResult>(id);
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"An error occurred while attempting to retrieve a {typeof(TResult).Name} with id: {id}.", ex);
            }
        }

        public IEnumerable<TResult> GetItems<TResult>() where TResult : IPersistableEntity, new()
        {
            var tablename = typeof(TResult).Name;

            try
            {
                return QueryDb<TResult>($"SELECT * FROM {tablename}");
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"An error occurred while attempting to retrieve all items from the {tablename} table.", ex);
            }
        }

        public int InsertItem<TItem>(TItem item) where TItem : IPersistableEntity, new()
        {
            try
            {
                lock (locker)
                {
                    return Insert(item);
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"An error occurred while attempting to insert an item with the id: {item.Id} into {typeof(TItem).Name} table.", ex);
            }
        }

        public int InsertItems<TItem>(IEnumerable<TItem> items, bool runInTransaction = true) where TItem : IPersistableEntity, new()
        {
            try
            {
                lock (locker)
                {
                    return InsertAll(items);
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"An error occurred while attempting to insert {items.Count()} items into {typeof(TItem).Name} table", ex);
            }
        }

        public int InsertOrReplaceItem<TItem>(TItem item) where TItem : IPersistableEntity, new()
        {
            try
            {
                lock (locker)
                {
                    return InsertOrReplace(item);
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"An error occurred while attempting to insert or replace an item with id: {item.Id} into {typeof(TItem).Name}.", ex);
            }
        }

        public IEnumerable<TResult> QueryDb<TResult>(string query, params object[] args) where TResult : IPersistableEntity, new()
        {
            try
            {
                lock (locker)
                {
                    return Query<TResult>(query, args);
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"An error occurred while attempting to query {typeof(TResult).Name} with query: {query}", ex);
            }
        }

        public int UpdateItem<TItem>(TItem item) where TItem : IPersistableEntity, new()
        {
            try
            {
                lock (locker)
                {
                    return Update(item);
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"An error occurred while attempting to update an {typeof(TItem).Name} item with id: {item.Id}", ex);
            }
        }

        public int UpdateItems<TItem>(IEnumerable<TItem> items) where TItem : IPersistableEntity, new()
        {
            try
            {
                lock (locker)
                {
                    return UpdateAll(items);
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"An error occurred while attempting to update {items.Count()} items that exists in {typeof(TItem).Name} table.", ex);
            }
        }
    }
}
