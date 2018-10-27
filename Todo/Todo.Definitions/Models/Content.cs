namespace NsuGo.Definition.Models
{
    public abstract class Content
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

        public string Title
        {
            get;
            set;
        }

        public string CourseId
        {
            get;
            set;
        }

        public abstract string DisplayIcon
        {
            get;
        }
    }
}
