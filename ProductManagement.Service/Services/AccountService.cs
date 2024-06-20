using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Repository.BaseRepository;
using ProductManagement.Repository.Entities;
using ProductManagement.Service.IServices;

namespace ProductManagement.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Transaction> _transactionRepository;

        public AccountService(IRepository<Account> accountRepository, IRepository<Transaction> transactionRepository = null)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            try
            {
                var accounts =  await _accountRepository.GetAll();
                return accounts;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            return await _accountRepository.GetById(accountId);
        }

        public void CreateAccountAsync(Account account)
        {
             _accountRepository.Create(account);
            _transactionRepository.CreateMany(account.Transactions);
           // await _transactionRepository.CreateMany(account.Transactions);
        }

        public async Task UpdateAccountAsync(int accountId,Account account)
        {
            Expression<Func<Transaction, bool>> predicate = a => a.AccountId == accountId;
            var Transactions =  _transactionRepository.GetMany(predicate);
            if (Transactions.Any())
            {
                await _transactionRepository.DeleteMany(Transactions);
            }

            account.AccountId = accountId;
            await _accountRepository.Update(accountId, account);
            foreach (var item in account.Transactions)
            {
                item.AccountId = accountId;
                item.TransactionId = 0;
            }
            await _transactionRepository.CreateMany(account.Transactions);
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            Expression<Func<Transaction, bool>> predicate = a => a.AccountId == accountId;
            var Transactions = _transactionRepository.GetMany(predicate);
            if (Transactions.Any())
            {
                await _transactionRepository.DeleteMany(Transactions);
            }
            await _accountRepository.Delete(accountId);
        }
    }
}
