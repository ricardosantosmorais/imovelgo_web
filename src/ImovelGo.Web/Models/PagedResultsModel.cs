using System;
using System.Collections.Generic;

namespace ImovelGo.Web.Models
{
    public class PagedResultsModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
