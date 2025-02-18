using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dima.Core.Requests.Transactions;

namespace Dima.Core.Requests.Transactions
{
    public class UpdateTransactionRequest : CreateTransactionRequest
    {
        public long Id { get; set; }
    }
}