using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_MVVM.Model
{
    public class Check : IPayment
    {
        public string AccountNumber { get; private set; }
        public string BankName { get; private set; }

        public Check(string accountNumber, string bankName)
        {
            AccountNumber = accountNumber;
            BankName = bankName;
        }

        public bool ProcessPayment()
        {
            return true;
        
        }
    }
}
