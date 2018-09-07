using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinpaida.Entity.Entity
{
    public class StoreSearchRequest
    {
        public string Brand { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string SearchKey { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
