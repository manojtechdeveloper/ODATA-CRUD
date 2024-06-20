using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository.Entities
{
    /// <summary>
    /// Represents a financial transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Unique identifier for the transaction.
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// Description of the transaction.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date and time when the transaction occurred.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Identifier of the source account for the transaction.
        /// </summary>
        public int SourceAccountID { get; set; }

        /// <summary>
        /// Identifier of the destination account for the transaction.
        /// </summary>
        public int DestinationAccountID { get; set; }

        /// <summary>
        /// Foreign key referencing the account involved in the transaction.
        /// </summary>
        public int AccountId { get; set; }
    }

}
