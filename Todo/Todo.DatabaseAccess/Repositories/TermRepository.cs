using System;
using System.Collections.Generic;
using System.Linq;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Data;
using NsuGo.Definition.Interfaces.Repositories.Local;
using NsuGo.Definition.Models;
using LocalData = Todo.LocalData.Models;

namespace NsuGo.DatabaseAccess.Repositories
{
    public class TermRepository : Base.LocalStorageRepository<Term, LocalData.Term>, ITermRepository
    {
        public TermRepository(IDataMapper<Term, LocalData.Term> dataMapper, IDatabaseProvider databaseProvider)
            : base(dataMapper, databaseProvider)
        {
        }

        public void Add(Term term)
        {
            try
            {
                AddObject(term);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to add a term with code: {term.Code} to the term local storage table. ", ex);
            }
        }

        public Term Get(string code)
        {
            try
            {
                var termFromDb = GetTermFromDb(code);

                if (termFromDb == null)
                    return null;

                return MapToDomainModel(termFromDb);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to retrieve a term fro local storage, that matches the code: {code}.", ex);
            }
        }

        private LocalData.Term GetTermFromDb(string code)
        {
            return DatabaseProvider.GetItem<LocalData.Term, string>(code);
        }

        public IEnumerable<Term> GetAll()
        {
            try
            {
                var termsFromDb = DatabaseProvider.GetItems<LocalData.Term>().ToList();
                return MapAllToDomainModel(termsFromDb);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException("An error occurred when an attempt was made to retrieve all the terms from local storage.", ex);
            }
        }

        public void RemoveAll()
        {
            try
            {
                RemoveAllObjects();
            }
            catch (DataRepositoryException)
            {
                throw;   
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove all the terms from local storage.", ex);
            }
        }

        public void Remove(Term term)
        {
            try
            {
                RemoveObject(term);                
            }
            catch (DataRepositoryException)
            {
                throw;
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove the term with code: {term.Code}.", ex);
            }
        }

        public void Update(Term term)
        {
            try
            {
                UpdateObject(term);
            }
			catch (DataRepositoryException)
			{
				throw;
			}
			catch (LocalStorageException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new DataRepositoryException($"An error occurred when an attempt was made to update the term with code: {term.Code}.", ex);
			}
        }

        public bool HasTermWithCode(string code)
        {
            return GetTermFromDb(code) != null;
        }
    }
}
