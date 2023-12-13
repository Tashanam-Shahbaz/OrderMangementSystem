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

        public static T GetValidInput<T>(string fieldName) where T : struct
        {
            while (true)
            {
                string input = GetNonEmptyInput(fieldName);
                T value;

                if (typeof(T) == typeof(int) && int.TryParse(input, out var intValue))
                {
                    value = (T)(object)intValue;
                    return value;
                }
                else if (typeof(T) == typeof(float) && float.TryParse(input, out var floatValue))
                {
                    value = (T)(object)floatValue;
                    return value;
                }
                else if (typeof(T) == typeof(decimal) && decimal.TryParse(input, out var decimalValue))
                {
                    value = (T)(object)decimalValue;
                    return value;
                }
                else
                {
                    Console.WriteLine($"The input for {fieldName} is not a valid {typeof(T).Name.ToLower()}.");
                }
            }
        }


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
