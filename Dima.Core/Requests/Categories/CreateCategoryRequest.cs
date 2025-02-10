using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dima.Core.Requests.Categories
{
    public class CreateCategoryRequest : BaseRequest
    {
        [Required(ErrorMessage = "Titulo inválido")]
        [MaxLength(80, ErrorMessage = "Otítulo deve conter até 80 caracteres")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Descrição inválida")]
        public string Description { get; set; } = string.Empty;
    }
}