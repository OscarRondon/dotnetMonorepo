using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace BankOperationsLibrary
{
    public class Transaction
    {
        public decimal Amount { get; }

        public string AmmountInLetters
        {
            get
            {
                return ((int)Amount).ToWords();
            }
        }

        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Notes = note;
        }
    }
}
