using System;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    public class VideoDto : Base.JsonObject<Video>
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

        public string DownloadUrl 
        { 
            get; 
            set; 
        }

        public string ThumbnailUrl 
        { 
            get; 
            set; 
        }

        public string VideoUrl
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

        public override Video ToDomainModel()
        {
            return new Video(EntryId, ProviderId, VideoUrl, Name)
            {
                Description = Description ?? string.Empty,
                DownloadUri = new Uri(DownloadUrl),
                ThumbnailUri = new Uri(ThumbnailUrl),
                Duration = GetDuration(),
                CreatedAt = CreatedAt,
                UpdatedAt = UpdatedAt
            };
        }


        //TODO: Needs refactoring, does this makes sense?
        private string GetDuration()
        {
            if (!String.IsNullOrEmpty(Duration))
            {
                var time = Convert.ToInt16(Duration);
                string hr, min;
                min = Convert.ToString((time % 100));
                hr = Convert.ToString(time / 100);
                if (hr.Length == 1) hr = "0" + hr;
                if (min.Length == 1) min = "0" + min;
                return hr + ":" + min;
            }
            else
            {
                return 0 + ":" + 0;
            }
        }
    }
}
