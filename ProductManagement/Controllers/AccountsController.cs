using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ProductManagement.Repository.Entities;
using ProductManagement.Service.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ODataController
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Account>))]
        public async Task<ActionResult<IEnumerable<Account>>> Get()
        {
            var accounts = await _accountService.GetAccountsAsync();
            return Ok(accounts);
        }

        [HttpGet("{key}")]
        [EnableQuery]
        [ProducesResponseType(200, Type = typeof(Account))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Account>> Get([FromRoute] int key)
        {
            var account = await _accountService.GetAccountByIdAsync(key);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> Post([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest("Account data is null.");
            }

            _accountService.CreateAccountAsync(account);
            return Ok(account.AccountId);
        }

        [HttpPut("{key}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> Put([FromRoute] int key, [FromBody] Account account)
        {
            if (account == null || key != account.AccountId)
            {
                return BadRequest("Invalid account data or ID mismatch.");
            }

            await _accountService.UpdateAccountAsync(key, account);
            return Ok(account.AccountId);
        }

        [HttpDelete("{key}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> Delete([FromRoute] int key)
        {
            await _accountService.DeleteAccountAsync(key);
            return Ok(key);
        }
    }
}
