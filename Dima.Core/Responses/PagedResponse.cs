using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dima.Core.Responses
{
    public class PagedResponse<TData> : Response<TData>
    {
        public PagedResponse()
        {
        }

        public PagedResponse(TData? data, int code = 200, string? message = null) : base(data, code, message)
        {
        }


        [JsonConstructor]
        public PagedResponse(TData? data, int totalCount, int currentPage = 1, int pageSize = Configration.PageSize) : base(data)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public int CurrentPage { get; set; }
        public int TotalPage => (int)Math.Ceiling(TotalPage / (double)PageSize);
        public int PageSize { get; set; } = Configration.PageSize;
        public int TotalCount { get; set; }

    }
}