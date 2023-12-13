using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_MVVM.Model
{
    public class Credict : IPayment
    {
        public string CardNumber { get; private set; }
        public string CardHolderName { get; private set; }
        public Credict(string cardNumber, string cardHolderName)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
        }

        public bool ProcessPayment()
        {
            return true;
        }
    }
}
