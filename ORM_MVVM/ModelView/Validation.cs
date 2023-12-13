using ORM_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_MVVM.ModelView
{
    internal class Validation
    {
        public static string GetNonEmptyInput(string fieldName)
        {
            string userInput = string.Empty;

            while (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine($"Enter {fieldName}:");
                userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine($"{fieldName} cannot be empty. Please enter {fieldName.ToLower()}.");
                }
            }

            return userInput;
        }

        //public static int GetValidInteger(string filedName)
        //{
        //    string integer1 = GetNonEmptyInput(filedName);
        //    int integer2;

        //    try
        //    {   
        //    }
        //    catch
        //    { 
        //    }
        //}
        public static int GetValidAge(string fieldName)
        {
            int age = 0;

            while (age <= 0)
            {
                Console.WriteLine($"Enter {fieldName}:");
                string ageInput = Console.ReadLine();

                if (!int.TryParse(ageInput, out age) || age <= 0)
                {
                    Console.WriteLine($"Invalid {fieldName}. Please enter a valid {fieldName.ToLower()}.");
                    age = 0;
                }
            }

            return age;
        }

        public static CustomerType GetValidCustomerType()
        {
            while (true)
            {
                Console.WriteLine("Select Customer Type: \n1. Regular \n2. Premium");
                string type = Console.ReadLine();

                if (type == "1")
                {
                    return CustomerType.regular;
                }
                else if (type == "2")
                {
                    return CustomerType.premium;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 for Regular or 2 for Premium.");
                }
            }
        }

    }
}
