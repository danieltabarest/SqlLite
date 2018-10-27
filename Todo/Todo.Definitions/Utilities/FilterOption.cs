namespace NsuGo.Definition.Utilities
{
	public class FilterOption
	{
		public string Key
		{
			get;
			private set;
		}

		public bool Selected
		{
			get;
			private set;
		}

        public FilterOption(string key)
        {
            Key = key;
        }

        public void Select()
        {
            Selected = true;
        }

        public void Reset()
        {
            Selected = false;
        }
	}
}
