using System;
using Todo.LocalData.Models;
using NsuGo.Definition.Enums;
using NsuGo.Definition.Interfaces;

namespace NsuGo.DatabaseAccess.DataMappers
{
    public class FileMapper : IDataMapper<Definition.Models.File, File>
    {
        public File ToData(Definition.Models.File domainObject)
        {
            return new File
            {
                Id = domainObject.Id,
                FileType = domainObject.Type.ToString(),
                Url = domainObject.Url,
                Body = domainObject.Body,
                Filename = domainObject.Filename,
                Extension = domainObject.Extension,
                SizeInBytes = domainObject.SizeInBytes
            };
        }

        public Definition.Models.File ToDomain(File dataObject)
        {
            return new Definition.Models.File
            {
                Type = ConvertToFileType(dataObject.FileType),
                Url = dataObject.Url,
                Body = dataObject.Body,
                Filename = dataObject.Filename,
                Extension = dataObject.Extension,
                SizeInBytes = dataObject.SizeInBytes
            };
        }

        private FileType ConvertToFileType(string fileType)
        {
            try
            {
                return (FileType)Enum.Parse(typeof(FileType), fileType);
            }
            catch (Exception)
            {
                return FileType.Other;
            }
        }
    }
}
