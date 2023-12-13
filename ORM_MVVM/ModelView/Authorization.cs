using ORM_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ORM_MVVM.ModelView
{
    internal class Authorization
    {
        static ItemsViewModel ItemsViewModel = new ItemsViewModel();
        static OrderViewModel OrderViewModel = new OrderViewModel();



        public static void AdminDashboard()
        {

            while (true)
            {
                Console.WriteLine("\n\nAdmin Dashboard" +
                    "\n1. View Items " +
                    "\n2. Update Items" +
                    "\n3. Add Item" +
                    "\n4. Remove Item" +
                    "\n5. View Order" +
                    "\n6. Update Order" +
                    "\n7. Exit from Admin Dashboard");
                
                string action = Console.ReadLine();
                if (action == "1")
                {
                    ItemsViewModel.ViewItems();
                }
                else if (action == "2")
                {
                    ItemsViewModel.ViewItems();

                    int id = Convert.ToInt32(Validation.GetNonEmptyInput("Id"));
                    Console.WriteLine("\nSelect Column for change" +
                        "\n1. Name" +
                        "\n2. Description" +
                        "\n3. Price" +
                        "\n4. Author" +
                        "\n5. Size" +
                        "\n5. Material" +
                        "\n7. Brand"
                        );
                    string coulmnName = Console.ReadLine();
                    Console.WriteLine("Enter new Value.");

                    string newValue = Console.ReadLine();
                    Console.WriteLine(ItemsViewModel.UpdateItem(id, coulmnName, newValue));
                }
                else if (action == "3")
                {

                    Console.WriteLine("\n\nChoose a Catagory" +
                    "\n1. Books " +
                    "\n2. Electronic" +
                    "\n3.Cloth" +
                    "\n4.Exit");

                    string catogry = Console.ReadLine();
                    Console.WriteLine(ViewAddItem(catogry));

                }
                else if (action == "4")
                {
                    ItemsViewModel.ViewItems();
                    Console.WriteLine("Choose an Id:");
                    int id = Validation.GetValidInput<int>("ID");
                    ItemsViewModel.RemoveItem(id);
                }
                else if (action == "5")
                {


                    OrderViewModel.ViewOrders();
                }
                else if (action == "6")
                {

                    OrderViewModel.ViewOrders();
                    Console.WriteLine(OrderViewModel.UpdateOrder());
                }
                else if (action == "7")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }

            }
        }
        
        public static void CustomerDashboard(int customerid)
        {

            while (true)
            {
                Console.WriteLine("\n\nCustomer Dashboard" +
                    "\n1. View Items " +
                    "\n2. Place Order" +
                    "\n3. Update Order" +
                    "\n4. View Order" +
                    "\n5. Exit from Customer Dashboard");
                string action = Console.ReadLine();

                if (action == "1")
                {
                    ItemsViewModel.ViewItems();
                }
                else if (action == "2")
                {
                    Console.WriteLine(" ----- PLACE ORDER ----- ");
                    Console.WriteLine("Enter , seperated Item Ids : ");
                    string itemid = Console.ReadLine();
                    OrderViewModel.PlaceOrder(customerid, itemid);
                    Console.WriteLine("Sucessfully placed order");
                }
                else if (action == "4")
                {
                    OrderViewModel.ViewOrders(customerid);
                }
                else if (action == "5") 
                {
                    return;
                }
                else {
                    Console.WriteLine("Invalid option");
                }

            }
        }

        public static string  ViewAddItem(string cat)
        {

            if (cat == "1")
            {
                string Name = Validation.GetNonEmptyInput("Name");
                string Description = Validation.GetNonEmptyInput("Description");
                float Price = Convert.ToInt32(Validation.GetNonEmptyInput("Price"));
                string Author = Validation.GetNonEmptyInput("Author");

                ItemsViewModel.AddItem(Name, Description, Price, Author);
            }
            else if (cat == "2")
            {
                string Name = Validation.GetNonEmptyInput("Name");
                string Description = Validation.GetNonEmptyInput("Description");
                float Price = Convert.ToInt32(Validation.GetNonEmptyInput("Price"));
                string Brand = Validation.GetNonEmptyInput("Brand");

                Brand brand;
                Enum.TryParse(Brand, true, out brand);
                ItemsViewModel.AddItem(Name, Description, Price, brand);
            }
            else if (cat == "3")
            {
                string Name = Validation.GetNonEmptyInput("Name");
                string Description = Validation.GetNonEmptyInput("Description");
                float Price = Convert.ToInt32(Validation.GetNonEmptyInput("Price"));
                int Size = Convert.ToInt32(Validation.GetNonEmptyInput("Size"));
                string Material = Validation.GetNonEmptyInput("Material");
                ItemsViewModel.AddItem(Name, Description, Price, Size, Material);
            }
            else
            {
                Console.WriteLine("Enter Invalid option");
            }
            return "Item Add Sycessfully";
        }




    }


}
