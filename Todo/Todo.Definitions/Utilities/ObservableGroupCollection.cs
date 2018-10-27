using System.Collections.ObjectModel;

namespace NsuGo.Definition.Utilities
{
    public class ObservableGroupCollection<S, T> : ObservableCollection<T>
	{
		private readonly S _key;

		public ObservableGroupCollection(System.Linq.IGrouping<S, T> group)
			: base(group)
		{
			_key = group.Key;
		}

		public S Key
		{
			get { return _key; }
		}
	}
}
