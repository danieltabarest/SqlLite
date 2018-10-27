using System;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    public class ContentDto : Base.JsonObject<Content>
    {
        public string Id
        {
            get;
            set;
        }

        public string ParentId
        {
            get;
            set;
        }

        public string CourseId
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public string ContentType
        {
            get;
            set;
        }

        public string FileSize
        {
            get;
            set;
        }

        public string FileType
        {
            get;
            set;
        }

        public string ApplicationType
        {
            get;
            set;
        }

        public override Content ToDomainModel()
        {
            if (ContentType == "Folder")
                return new Folder(Id, Title, CourseId)
                {
                    ApplicationType = ApplicationTypeConverter()
                };
            
            return new File(Id, Title, CourseId, FileTypeConverter())
            {
                SizeInBytes = Convert.ToDouble(FileSize),
                Extension = FileType,
                Filename = FileName,
                Body = Body,
                Url = Url
            };
        }

        private Enums.FileType FileTypeConverter()
        {
            Enums.FileType type;

			try
			{
                type = (Enums.FileType)Enum.Parse(typeof(Enums.FileType), ContentType);
			}
			catch (Exception)
			{
                type = Enums.FileType.Other;
			}

            return type;
        }

        private Enums.ApplicationType ApplicationTypeConverter()
        {
            Enums.ApplicationType type;

            try
            {
                type = (Enums.ApplicationType)Enum.Parse(typeof(Enums.ApplicationType), ApplicationType);
            }
            catch (Exception)
            {
                type = Enums.ApplicationType.None;
            }

            return type;
        }
    }
}
