using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Core.Requests.Categories
{
    public class UpdateCategoryRequest : CreateCategoryRequest
    {
        public long Id { get; set; }
    }
}