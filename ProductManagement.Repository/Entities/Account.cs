using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository.Entities
{
    /// <summary>
    /// Represents a bank account.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Unique identifier for the account.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Name associated with the account.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Current balance in the account.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Type of the account (e.g., savings, checking).
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// Collection of transactions associated with this account.
        /// </summary>
        public ICollection<Transaction> Transactions { get; set; }
    }


}
