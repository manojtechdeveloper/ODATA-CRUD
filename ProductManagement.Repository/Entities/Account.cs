using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }

        // Navigation property for transations 
        public ICollection<Transaction> Transactions { get; set; }  

    }
     
}
