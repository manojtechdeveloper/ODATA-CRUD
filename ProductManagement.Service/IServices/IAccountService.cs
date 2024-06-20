using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Repository.Entities;

namespace ProductManagement.Service.IServices
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetAccountByIdAsync(int accountId);
        void CreateAccountAsync(Account account);
        Task UpdateAccountAsync(int accountId, Account account);
        Task DeleteAccountAsync(int accountId);

    }
}
