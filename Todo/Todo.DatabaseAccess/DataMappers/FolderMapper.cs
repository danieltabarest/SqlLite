using System;
using Todo.LocalData.Models;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Interfaces;

namespace NsuGo.DatabaseAccess.DataMappers
{
    public class FolderMapper : IDataMapper<Definition.Models.Folder, Folder>
    {
        public Folder ToData(Definition.Models.Folder domain)
        {
            return new Folder
            {
                Id = domain.Id,
                FolderType = domain.Type.ToString(),
                ItemCount = domain.ItemCount ?? 0,
                ApplicationType = domain.ApplicationType.ToString(),
            };
        }

        public Definition.Models.Folder ToDomain(Folder data)
        {
            return new Definition.Models.Folder
            {
                Id = data.Id,
                Type = ConvertToFolderType(data.FolderType),
                ItemCount = data.ItemCount,
                ApplicationType = ConvertToApplicationType(data.ApplicationType)
            };
        }

        private FolderType ConvertToFolderType(string folderType)
        {
			try
			{
                return (FolderType)Enum.Parse(typeof(FolderType), folderType);
			}
			catch (Exception)
			{
                return FolderType.General;
			}
        }

        private ApplicationType ConvertToApplicationType(string applicationType)
        {
            try
            {
                return (ApplicationType)Enum.Parse(typeof(ApplicationType), applicationType);
            }
            catch (Exception)
            {
                return ApplicationType.None;
            }
        }
    }
}
