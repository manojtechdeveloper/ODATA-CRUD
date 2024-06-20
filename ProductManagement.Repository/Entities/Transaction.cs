using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }  
        public string Description { get; set; }
        public DateTime Date {  get; set; }
        public int SourceAccountID { get; set; }
        public int DestinationAccountID { get; set; }

        //Foreign keys 
        public int AccountId { get; set; }
       // public Account Account { get; set; }
    }
}
