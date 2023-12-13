using ORM_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_MVVM.ModelView
{
    internal class Authentication
    {
        public static bool SignUp(string name , string email, string password,int age, CustomerType type)
        {
            try
            {
                List<User> usersList = Serialization.DeSerializeUserList();
                if (usersList != null)
                {
                    Customer customer = new Customer();

                    if (usersList.OfType<Customer>().Any())
                    {
                        customer.CustomerID = usersList.OfType<Customer>().Max(user => user.CustomerID) + 1;
                    }
                    else 
                    {
                        customer.CustomerID = 1;
                    }
                    customer.Email = email; 
                    customer.Password = password;
                    customer.Age = age;
                    customer.CustomerType = type;

                    usersList.Add(customer);
                    Serialization.SerializeUserList(usersList);
                    return true;
                }
                else
                {
                    Console.WriteLine("SignUp fail.");
                    return false;
                }
                
            }
            catch 
            {
                return false;
            }        
        }


        public static User Login(string password, string email ) 
        {
            List<User> usersList  = null;
            try
            {

                usersList = Serialization.DeSerializeUserList();
                User user = usersList.Find(u => u.Email == email && u.Password == password);
                return user;
            }
            catch 
            {
                return null;
            }
        }
    }
}
