using TransactionApi.Data;
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
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly SimDbContext dbContext;
        public AccountRepository(SimDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<Account> GetAll()
        {
            return dbContext.Set<Account>().Include(x => x.Transactions).ToList();
        }

        public Account GetById(int id)
        {
            return dbContext.Set<Account>().Include(x => x.Transactions).FirstOrDefault(x => x.CustomerNumber == id);
        }
    }
}
