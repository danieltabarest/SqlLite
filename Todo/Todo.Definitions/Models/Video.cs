using System;

namespace NsuGo.Definition.Models
{

    public class Video
    {
        public string EntryId
        { 
            get; 
            set; 
        }

        public string ProviderId 
        { 
            get;
            set; 
        }

        public string Name 
        { 
            get; 
            set; 
        }

        public string Description 
        { 
            get; 
            set; 
        }

        public Uri DownloadUri 
        { 
            get; 
            set; 
        }

        public Uri ThumbnailUri 
        { 
            get; 
            set; 
        }

        public Uri StreamUri 
        { 
            get; 
            set; 
        }

        public string Duration 
        { 
            get; 
            set; 
        }

        public DateTime CreatedAt 
        { 
            get; 
            set; 
        }

        public DateTime UpdatedAt 
        { 
            get; 
            set; 
        }

         
        public  string DatePosted
        {
            get
            {
                return $"Date Posted: {CreatedAt.ToDateFormattedString()}";
            }
        }

        public Video(string entryId, string providerId, string url, string name)
        {
            EntryId = entryId;
            ProviderId = providerId;
            StreamUri = new Uri(url);
            Name = name;
        }

        public Video() 
        {
        }
    }

}
