using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dima.Core.Models;

namespace Dima.Core.Requests.Transactions
{
    public class CreateTransactionRequest : BaseRequest
    {
        [Required(ErrorMessage = "Titulo inválido")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tipo inválido")]
        public ETransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public long CategoryId { get; set; }
        public DateTime? PaidOrReceivedAt { get; set; }

    }
}