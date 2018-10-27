using System;
using System.Collections.Generic;
using System.Linq;
using NsuGo.Definition.Exceptions;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Data;

namespace NsuGo.DatabaseAccess.Repositories.Base
{
    public abstract class LocalStorageRepository<TDomainModel, TDataModel>
        where TDomainModel : class
        where TDataModel : IPersistableEntity, new()
    {
        
        protected IDataMapper<TDomainModel, TDataModel> DataMapper
        {
            get;
            private set;
        }

        protected IDatabaseProvider DatabaseProvider
        {
            get;
            private set;
        }

        protected LocalStorageRepository(
            IDataMapper<TDomainModel, TDataModel> dataMapper, 
            IDatabaseProvider databaseProvider
        )
        {
            DataMapper = dataMapper;
            DatabaseProvider = databaseProvider;
        }

        protected virtual TDataModel MapToDataModel(TDomainModel domain)
		{
            if (domain == null)
                throw new ArgumentNullException(nameof(domain));
            
            return DataMapper.ToData(domain);
		}

        protected virtual TDomainModel MapToDomainModel(TDataModel data)
		{
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return DataMapper.ToDomain(data);
		}

        protected virtual IEnumerable<TDomainModel> MapAllToDomainModel(IEnumerable<TDataModel> data)
        {
            try
            {
				var domainObjects = data.Select(domainObject =>
				{
                    return MapToDomainModel(domainObject);
				});

                return domainObjects;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual void AddObject(TDomainModel domainObject)
        {
            var dataObject = MapToDataModel(domainObject);
            DatabaseProvider.InsertOrReplaceItem(dataObject);
        }

        protected virtual void RemoveAllObjects()
        {
            var count = DatabaseProvider.GetItems<TDataModel>().Count();
            var removedCount = DatabaseProvider.DeleteItems<TDataModel>();

            if (count != removedCount)
                throw new DataRepositoryException($"{removedCount}/{count} {typeof(TDomainModel).Name}s were removed from local storage when an attempt was made to remove all {typeof(TDomainModel).Name}s.");
        }

        protected virtual void RemoveObject(TDomainModel domainObject)
        {
            var dataObject = MapToDataModel(domainObject);
            var removedCount = DatabaseProvider.DeleteItem(dataObject);

			if (removedCount != 1)
                throw new DataRepositoryException($"{removedCount} {typeof(TDomainModel).Name}s were removed from local storage when an attempt was made to remove the {typeof(TDomainModel).Name} having the id: {dataObject.Id}");
        }

        protected virtual void UpdateObject(TDomainModel domainObject)
        {
            var dataObject = MapToDataModel(domainObject);
            var updatedCount = DatabaseProvider.UpdateItem(dataObject);

			if (updatedCount != 1)
                throw new DataRepositoryException($"{updatedCount} {typeof(TDomainModel).Name}s were updated in local storage when an attempt was made to update the {typeof(TDomainModel).Name} having the id: {dataObject.Id}");
        }
    }
}
