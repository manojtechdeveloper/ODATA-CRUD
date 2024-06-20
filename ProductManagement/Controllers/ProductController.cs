using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ProductManagement.Common;
using ProductManagement.Common.Models;
using ProductManagement.Repository.Entities;
using ProductManagement.Service.IServices;

namespace ProductManagement.Controllers
{
    public class ProductController : ODataController
    {
        private IProductService _productService;
        private IAccountService _accountService;


        public ProductController(IProductService productService, IAccountService accountService) {
            _productService = productService;
            _accountService = accountService;
        } 
        [EnableQuery]
        public ActionResult<IEnumerable<Account>> Get()
        {
            //var products = _productService.GetProducts();
            var accounts = _accountService.GetAccountsAsync();
            return Ok(accounts);
        }

        [HttpPost]
        public ActionResult Post([FromBody]Account account)
        {
            var Transactions = new List<Transaction>();
            Transactions.Add(new Transaction()
            {
                Description = "test desc"
            });
            account = new Account()
            {
                AccountName = "new",
                AccountType = "saving",
                Balance = 3433.20m,
                Transactions = Transactions
            };
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                _accountService.CreateAccountAsync(account);
                return Ok(account);
            }
        }
    }
}
