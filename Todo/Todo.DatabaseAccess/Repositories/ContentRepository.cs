using System;
using System.Collections.Generic;
using System.Linq;
using NsuGo.DatabaseAccess.Repositories.Base;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Data;
using NsuGo.Definition.Interfaces.Repositories.Local;
using NsuGo.Definition.Models;
using LocalData = Todo.LocalData.Models;

namespace NsuGo.DatabaseAccess.Repositories
{
    public class ContentRepository : LocalStorageRepository<Content, LocalData.Content>, IContentRepository
    {
        private readonly IFolderRepository _folderRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IDataMapper<Folder, LocalData.Folder> _folderMapper;
        private readonly IDataMapper<File, LocalData.File> _fileMapper;

        public ContentRepository(
            IFolderRepository folderRepository,
            IFileRepository fileRepository,
            IDataMapper<Content, LocalData.Content> contentDataMapper,
            IDataMapper<Folder, LocalData.Folder> folderMapper,
            IDataMapper<File, LocalData.File> fileMapper,
            IDatabaseProvider databaseProvider
        ) : base(contentDataMapper, databaseProvider)
        {
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _folderMapper = folderMapper;
            _fileMapper = fileMapper;
        }

        public void Add(Content content)
        {
            try
            {
                TryAdd(content);
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to add a content with id {content.Id} to local storage.", ex);
            }
        }

        private void TryAdd(Content content)
        {
            if (TryCastToFile(content, out File file))
                _fileRepository.Add(file);
            else if (TryCastToFolder(content, out Folder folder))
                _folderRepository.Add(folder);
            else
                throw new ArgumentException($"{nameof(content)} is an unsupported content type.");

            AddObject(content);
        }

        public IEnumerable<Content> GetAllWithCourseId(string courseId)
        {
            try
            {
                var content = GetContentFromDb(courseId).Select(c =>
                {
                    return BuildContent(c);
                }).ToList();

                return content;
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to get a collection of content from local storage for the course with id: {courseId}", ex);
            }
        }

        private IEnumerable<LocalData.Content> GetContentFromDb(string courseId)
        {
            return DatabaseProvider.QueryDb<LocalData.Content>("SELECT * FROM Content WHERE CourseId = ? AND ParentId is null", courseId).ToList();
        }

        private Content BuildContent(LocalData.Content contentDataObject)
        {
            var contentType = contentDataObject.ContentType;

            if (contentType == typeof(LocalData.File).Name)
                return BuildFile(contentDataObject);

            if (contentType == typeof(LocalData.Folder).Name)
                return BuildFolder(contentDataObject);

            throw new ArgumentException($"{nameof(contentDataObject)} has an unsupported content type.");
        }

        private Content BuildFolder(LocalData.Content contentDataObject)
        {
            try
            {
                var folderFromDb = DatabaseProvider.GetItem<LocalData.Folder, string>(contentDataObject.Id);
                var folder = _folderMapper.ToDomain(folderFromDb);

                InsertContentMetadata(folder, contentDataObject);

                return folder;
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to retrieve the folder from local storage with content id {contentDataObject.Id}", ex);
            }
        }

        private Content BuildFile(LocalData.Content contentDataObject)
        {
            try
            {
                var fileFromDb = DatabaseProvider.GetItem<LocalData.File, string>(contentDataObject.Id);
                var file = _fileMapper.ToDomain(fileFromDb);

                InsertContentMetadata(file, contentDataObject);

                return file;
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to retrieve and build a file from local storage with id {contentDataObject.Id}", ex);
            }
        }

        private void InsertContentMetadata(Content content, LocalData.Content contentDataObject)
        {
            content.Title = contentDataObject.Title;
            content.CourseId = contentDataObject.CourseId;
            content.ParentId = contentDataObject.ParentId;
        }


        public void Remove(Content content)
        {
            try
            {
                TryRemove(content);
            }
            catch (LocalStorageException)
            {
                throw;
            }
            catch (DataRepositoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove the content with id {content.Id} from local storage.", ex);
            }
        }

        private void TryRemove(Content content)
        {
            if (TryCastToFile(content, out File file))
                _fileRepository.Remove(file);
            else if (TryCastToFolder(content, out Folder folder))
                _folderRepository.Remove(folder);
            else
                throw new ArgumentException($"{nameof(content)} is of an unsupported file type.");

            RemoveObject(content);
        }

        public void Update(Content content)
        {
			try
            {
                TryUpdate(content);
            }
            catch (LocalStorageException)
            {
                throw;
            }
			catch (DataRepositoryException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new DataRepositoryException($"An error occurred when an attempt was made to update the content with id {content.Id} in local storage.", ex);
			}
        }

        private void TryUpdate(Content content)
        {
            if (TryCastToFile(content, out File file))
                _fileRepository.Update(file);
            else if (TryCastToFolder(content, out Folder folder))
                _folderRepository.Update(folder);
            else
                throw new ArgumentException($"{nameof(content)} is of an unsupported file type.");

            UpdateObject(content);
        }

        private bool TryCastToFile(Content content, out File file)
        {
            file = null;
            return TryCast<File>(content, out file);
        }

        private bool TryCastToFolder(Content content, out Folder folder)
        {
            folder = null;
            return TryCast<Folder>(content, out folder);
        }

        private bool TryCast<TContent>(Content content, out TContent result) where TContent : Content, new()
        {
            result = null;

            if (!(content is TContent castedContent))
                return false;

            result = castedContent;
            return true;
        }

        public void RemoveAll()
        {
            try
            {
                 RemoveAllObjects();
                _folderRepository.RemoveAll();
                _fileRepository.RemoveAll();
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
                throw new DataRepositoryException($"An error occurred when an attempt was made to remove all the course content from local storage.", ex);
            }
        }

        public bool HasContentWithCourseId(string courseId)
        {
            return GetContentFromDb(courseId).Any();
        }
    }
}
