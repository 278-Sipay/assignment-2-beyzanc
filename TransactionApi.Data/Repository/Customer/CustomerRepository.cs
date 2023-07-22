using TransactionApi.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionApi.Data.Domain;
using Microsoft.EntityFrameworkCore;
using TransactionApi.Data.Repository;

namespace TransactionApi.Data.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly SimDbContext dbContext;
        public CustomerRepository(SimDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Customer> GetAll()
        {
            return dbContext.Set<Customer>().Include(x => x.Accounts).ThenInclude(x => x.Transactions).ToList();
        }

        public Customer GetById(int id)
        {
            return dbContext.Set<Customer>().Include(x => x.Accounts).ThenInclude(x => x.Transactions).FirstOrDefault(x => x.CustomerNumber == id);
        }

    }
}
