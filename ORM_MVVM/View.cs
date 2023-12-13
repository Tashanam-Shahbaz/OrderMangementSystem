using ORM_MVVM.Model;
using ORM_MVVM.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ORM_MVVM
{
    internal class View
    {
        static void Main(string[] args)
        {
            //Adding Adming as a user in admin list
            Admin admin = new Admin();
            admin.Username = "admin";
            admin.Password = "admin";
            admin.Age = 1;
            admin.Email = "admin";
            admin.AdminRole = "add,update";
            admin.Department = "Operation";

            List<User> users = new List<User> 
            {
                admin
            };

            List<Items> items = new List<Items>();
            //Serialization.SerializeUserList(users);
            


            while (true)
            {

                Console.WriteLine(" --- Welcome to Order Management System --- \nChoose an otpion \n1. SignUp \n2. SignIn \n3. Exit");
                string action = Console.ReadLine();

                if (action == "1") // Signup 
                {
                    string name = Validation.GetNonEmptyInput("Name");
                    string email = Validation.GetNonEmptyInput("Email");
                    int age = Validation.GetValidAge("Age");
                    string password = Validation.GetNonEmptyInput("Password");
                    CustomerType type = Validation.GetValidCustomerType();
                    bool status = Authentication.SignUp(name, email, password, age, type);

                    switch (status)
                    {
                        case true: Console.WriteLine("User Register Sucessfully"); break;
                        case false: Console.WriteLine("User Register Sucessfully"); break;
                        default: Console.WriteLine("Something went wrong."); break;
                    }
                    Console.WriteLine();
                }
                else if (action == "2")  //SignIn
                {
                    string email = Validation.GetNonEmptyInput("Email");
                    string password = Validation.GetNonEmptyInput("Password");
                    User user = Authentication.Login(password, email);
                    if (user?.Role == "admin")
                    {
                        Authorization.AdminDashboard();
                    }
                    else if (user?.Role == "customer")
                    {
                        if (user is Customer customer)
                        {
                            Authorization.CustomerDashboard(customer.CustomerID);
                        }
                        else 
                        {
                            Console.WriteLine("This user is invalid");
                        }
                        
                    }
                    else 
                    {
                        Console.WriteLine("Wrong password or email");
                    }
                }
                else if (action == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid action");
                }

            }
        }


    }
}
