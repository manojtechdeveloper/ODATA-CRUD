using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ProductManagement.Repository.Entities;
using ProductManagement.Service.IServices;
using System;
using System.Collections.Generic;

namespace ProductManagement.Controllers
{
    /// <summary>
    /// API endpoints for managing accounts.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ODataController
    {
        private readonly IAccountService _accountService;
        /// <summary>
        /// Constructor for <see cref="AccountsController"/>.
        /// </summary>
        /// <param name="accountService">The service providing account operations.</param>
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        /// <summary>
        /// Returns a list of all accounts.
        /// </summary>
        /// <returns>A list of all accounts.</returns>
        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Account>))]
        public ActionResult<IEnumerable<Account>> Get()
        {
            var accounts = _accountService.GetAccountsAsync().Result;
            return Ok(accounts);
        }

        /// <summary>
        /// Returns an account by its ID.
        /// </summary>
        /// <param name="key">The ID of the account.</param>
        /// <returns>The account details.</returns>
        [HttpGet("{key}")]
        [EnableQuery]
        [ProducesResponseType(200, Type = typeof(Account))]
        [ProducesResponseType(404)]
        public ActionResult<Account> Get([FromRoute] int key)
        {
            var account = _accountService.GetAccountByIdAsync(key).Result;
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        /// <summary>
        /// Creates a new account.
        /// </summary>
        /// <param name="account">The account to create.</param>
        /// <returns>The ID of the created account.</returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public ActionResult<int> Post([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest("Account data is null.");
            }
            _accountService.CreateAccountAsync(account);
            return Ok(account.AccountId);
        }

        /// <summary>
        /// Updates an existing account by ID.
        /// </summary>
        /// <param name="key">The ID of the account to update.</param>
        /// <param name="account">The updated details of the account.</param>
        /// <returns>The ID of the updated account.</returns>
        [HttpPut("{key}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<int> Put([FromRoute] int key, [FromBody] Account account)
        {
            if (account == null || key != account.AccountId)
            {
                return BadRequest("Invalid account data or ID mismatch.");
            }
            _accountService.UpdateAccountAsync(key, account);
            return Ok(account.AccountId);
        }

        /// <summary>
        /// Deletes an account by ID.
        /// </summary>
        /// <param name="key">The ID of the account to delete.</param>
        /// <returns>The ID of the deleted account.</returns>
        [HttpDelete("{key}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(404)]
        public ActionResult<int> Delete([FromRoute] int key)
        {
            _accountService.DeleteAccountAsync(key);
            return Ok(key);

        }
    }
}

