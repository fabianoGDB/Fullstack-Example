using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Core.Requests
{
    public abstract class PagedRequest : BaseRequest
    {
        public int PageNumber { get; set; } = Configuration.PageNumber;
        public int PageSize { get; set; } = Configuration.PageSize;

    }
}