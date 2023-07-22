using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using TransactionApi.Data.Domain;
using TransactionApi.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;



namespace TransactionApi.Data.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly SimDbContext dbContext;
 
        public TransactionRepository(SimDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Transaction> GetByFilter(int? accountNumber,
                                                    decimal? minAmountCredit,
                                                    decimal? maxAmountCredit,
                                                    decimal? minAmountDebit,
                                                    decimal? maxAmountDebit,
                                                    string description,
                                                    DateTime? beginDate,
                                                    DateTime? endDate,
                                                    string referenceNumber)
        {
            Expression<Func<Transaction, bool>> filter = t =>
            (!accountNumber.HasValue || t.AccountNumber == accountNumber.Value) &&
            (!minAmountCredit.HasValue || t.CreditAmount >= minAmountCredit.Value) &&
            (!maxAmountCredit.HasValue || t.CreditAmount <= maxAmountCredit.Value) &&
            (!minAmountDebit.HasValue || t.DebitAmount >= minAmountDebit.Value) &&
            (!maxAmountDebit.HasValue || t.DebitAmount <= maxAmountDebit.Value) &&
            (string.IsNullOrEmpty(description) || t.Description.Contains(description)) &&
            (!beginDate.HasValue || t.TransactionDate >= beginDate.Value) &&
            (!endDate.HasValue || t.TransactionDate <= endDate.Value)&&
            (string.IsNullOrEmpty(referenceNumber) || t.ReferenceNumber.Contains(referenceNumber));

            return dbContext.Transaction.Where(filter).ToList();
        }


    }

    }

