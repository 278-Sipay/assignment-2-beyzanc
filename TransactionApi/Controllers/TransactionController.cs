using Microsoft.AspNetCore.Mvc;
using TransactionApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using TransactionApi.Data.Domain;


namespace TranactionApi.Controllers
{
    [ApiController]
    [Route("sipay/api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository repository;
        public TransactionController(ITransactionRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet("GetByParameter")]
        public IActionResult GetByParameter([FromQuery] int? accountNumber,
                                            [FromQuery] decimal? minAmountCredit,
                                            [FromQuery] decimal? maxAmountCredit,
                                            [FromQuery] decimal? minAmountDebit,
                                            [FromQuery] decimal? maxAmountDebit,
                                            [FromQuery] string description,
                                            [FromQuery] DateTime? beginDate,
                                            [FromQuery] DateTime? endDate,
                                            [FromQuery] string referenceNumber
                                            )
        {
            var transactions = repository.GetByFilter(accountNumber,
                                                      minAmountCredit,
                                                      maxAmountCredit,
                                                      minAmountDebit,
                                                      maxAmountDebit,
                                                      description,
                                                      beginDate,
                                                      endDate,
                                                      referenceNumber
                                                      );

            return Ok(transactions);

        }
    }
}

