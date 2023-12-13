using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_MVVM.Model
{
    public class Customer : User
    {
        public CustomerType CustomerType { get; set; }
        public int CustomerID { get; set; }
        public override string Role => GetRole();
        public override string GetRole()
        {
            return "customer"; 
        }

        public Customer()  
        {
        }
    }
}
