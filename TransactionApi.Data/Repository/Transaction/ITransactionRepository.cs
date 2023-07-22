using TransactionApi.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionApi.Data.Domain;
using System.Linq.Expressions;

namespace TransactionApi.Data.Repository
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        IEnumerable<Transaction> GetByFilter(int? accountNumber,
                                             decimal? minAmountCredit,
                                             decimal? maxAmountCredit,
                                             decimal? minAmountDebit,
                                             decimal? maxAmountDebit,
                                             string description,
                                             DateTime? beginDate,
                                             DateTime? endDate,
                                             string referenceNumber);

    }
}
