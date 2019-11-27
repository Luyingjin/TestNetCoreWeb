using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class GetSearchBaseInput
    {
        private int _pageIndex = 0;
        private int _pageSize = 10;
        public int PageIndex { get { return _pageIndex; } set { _pageIndex = value; } }
        public int PageSize { get { return _pageSize; } set { _pageSize = value; } }
        public string Sort { get; set; }
        public string Order { get; set; }
    }
}
