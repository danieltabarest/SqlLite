using System.Collections.Generic;
using NsuGo.Definition.Utilities;

namespace NsuGo.Definition.Dtos
{
    public class FilterPageDto
    {
        public string PageTitle
        {
            get;
            set;
        }

        public IEnumerable<FilterOption> FilterOptions
        {
            get;
            set;
        }

        public FilterPageDto(string pageTitle, IEnumerable<FilterOption> filterOptions)
        {
            PageTitle = pageTitle;
            FilterOptions = filterOptions;
        }
    }
}
