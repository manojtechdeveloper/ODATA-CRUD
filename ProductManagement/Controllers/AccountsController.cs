using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ProductManagement.Repository.Entities;
using ProductManagement.Service.IServices;

namespace ProductManagement.Controllers
{
    public class AccountsController : ODataController
    {

        private IAccountService _accountService;


        public AccountsController(IAccountService accountService)
        {

            _accountService = accountService;
        }

        /// <summary>
        /// Return list of all accounts
        /// </summary>
        /// <returns>A list of all accounts</returns>
        
        [EnableQuery]
        public ActionResult<IEnumerable<Account>> Get()
        {
            var account = _accountService.GetAccountsAsync().Result;
            return Ok(account);
        }

        /// <summary>
        /// Return account by id
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Regurn single account</returns>
        [EnableQuery]
        public ActionResult<Account> Get([FromRoute] int key)
        {
            var item = _accountService.GetAccountByIdAsync(key).Result;

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        /// <summary>
        /// Save new account
        /// </summary>
        /// <param name="account"></param>
        /// <returns>Return account id</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        public ActionResult Post([FromBody] Account account)
        {

            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                _accountService.CreateAccountAsync(account);
                return Ok(account.AccountId);
            }
        }


        /// <summary>
        /// Update existing account
        /// </summary>
        /// <param name="key">Account Id</param>
        /// <param name="account">Details of account</param>
        /// <returns>Return account id</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPut]
        [EnableQuery]
        [Route("Account{{key}}")]
        public ActionResult Put([FromODataUri] int key, [FromBody] Account account)
        {

            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            else
            {
                _accountService.UpdateAccountAsync(key, account);
                return Ok(account.AccountId);
            }
        }

        /// <summary>
        /// Delete account 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Return deleted account id</returns>
        [HttpDelete]
        [EnableQuery]
        [Route("Account{{key}}")]
        public ActionResult Delete([FromODataUri] int key)
        {
            _accountService.DeleteAccountAsync(key);
            return Ok(key);

        }
    }
}

