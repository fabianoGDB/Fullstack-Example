using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Core.Requests
{
    public abstract class PagedRequest : BaseRequest
    {
        public int PageNumber { get; set; } = Configration.PageNumber;
        public int PageSize { get; set; } = Configration.PageSize;

    }
}