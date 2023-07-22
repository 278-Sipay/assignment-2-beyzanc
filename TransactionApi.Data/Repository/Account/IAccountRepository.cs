using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransactionApi.Data.Domain;
using TransactionApi.Data.Repository.Base;

namespace TransactionApi.Data.Repository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {

    }
}
