using ORM_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_MVVM.ModelView
{
    internal class OrderViewModel
    {

        public string PlaceOrder(int customer_id,string itemIds) 
        {

            List<Items> itemList = Serialization.DeSerializeItemList();
            List<Order> orderList = Serialization.DeSerializeOrderList(); 

            Order order = new Order();
            if(orderList.Any())
            {
                order.Id = orderList.Max(user=>  user.Id) + 1;
            }
            else
            {
                order.Id = 1;
            }
            order.OrderDate = DateTime.Now;
            order.customer_id = customer_id;
            List<string> itemIDsList = itemIds.Split(',').ToList();
            order.OrdersItemsByCustomer = new List<Items>();

            foreach (var num in itemIDsList)
            {
                if( num == "")
                {
                    continue;
                }
                Items item2 = itemList.Find(item => item.Id == Convert.ToInt32(num));
                if (item2 == null)
                {
                    Console.WriteLine("Item Id {0} does not exist", num);
                }
                else
                {
                    order.OrdersItemsByCustomer.Add(item2);
                }
            }

            orderList.Add(order);
            bool result = Serialization.SerializeOrderList(orderList);
            return result ? "Order place Successfully" : "We encountered an issue while processing your order.";
        }

        public void ViewOrders(int customerid)
        {
            List<Order> orders = Serialization.DeSerializeOrderList();
            List<Order> ordersOfSpecificCustomer = orders
                            .Where(order => order.customer_id == customerid)
                            .ToList();

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("| Order ID | Order Status | Payment Status | Item Name |");
            Console.WriteLine("-------------------------------------------------------------");

            StringBuilder table = new StringBuilder();

            foreach (var order in ordersOfSpecificCustomer)
            {
                string itemList = "";
                foreach (var items in order.OrdersItemsByCustomer)
                {
                    itemList += items.Name + ",";
                }
                itemList = itemList.Substring(0, itemList.Length - 2);

                table.AppendFormat("| {0,-8} | {1,-11} | {2,-16} |{3, -50}\n",
                    order.Id, order.OrderStatus, order.PaymentStatus, itemList);
            }

            Console.WriteLine(table.ToString());
        }

        public void ViewOrders()
        {
            List<Order> orders = Serialization.DeSerializeOrderList();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("| Order ID | Order Status | Payment Status | Item Name |");
            Console.WriteLine("-------------------------------------------------------------");

            StringBuilder table = new StringBuilder();

            foreach (var order in orders)
            {
                string itemList = "";
                foreach (var items in order.OrdersItemsByCustomer)
                {
                    itemList += items.Name + ",";
                }
                itemList = itemList.Substring(0, itemList.Length - 2);

                table.AppendFormat("| {0,-8} | {1,-11} | {2,-16} |{3, -50}\n",
                    order.Id, order.OrderStatus, order.PaymentStatus, itemList);
            }

            Console.WriteLine(table.ToString());
        }

        public string UpdateOrder()
        {

            Dictionary<string, string> val = viewforUpdateOrder();

            List<Order> orders = Serialization.DeSerializeOrderList();
            int index = orders.FindIndex(order => order.Id == Convert.ToInt32(val["orderid"]));

            switch (val["type"])
            {
                case "2":

                    switch (val["value"]?.ToLower())
                    {
                        case "1":
                            orders[index].ProcessPayment();
                            break;

                        case "2":
                            // Dont do any thing as the start is already set pending as a default value.
                            break;

                        default:
                            return "Please provide a valid Payment Status";
                    }
                    break;

                case "1":
                    switch (val["value"]?.ToLower())
                    {
                        case "1":
                            orders[index].OrderStatus = OrderStatus.Pending;
                            break;
                        case "2":
                            orders[index].OrderStatus = OrderStatus.Approved;
                            break;
                        case "3":
                            orders[index].OrderStatus = OrderStatus.Shipped;
                            break;
                        case "4":
                            orders[index].OrderStatus = OrderStatus.Delivered;
                            break;
                        case "5":
                            orders[index].OrderStatus = OrderStatus.Cancelled;
                            break;
                        default:
                            return "Please provide a valid Order Status";
                            
                    }
                    break;
                default:
                    return "Please enter a valid field type";
            }


            Serialization.SerializeOrderList(orders);
            return "Order Updated Successfully";


        }


        private Dictionary<string, string> viewforUpdateOrder()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Enter Order Id");
            string orderid = Console.ReadLine();
            Console.WriteLine("\nChoose an option. \n1. Order Status \n2. Payment Status ");
            string type = Console.ReadLine();

            if (type == "1")
            {
                Console.WriteLine("\nChoose an option. \n1. Pending \n2. Approved, \n3. Shipped \n4. Delivered \n5. Cancelled");
            }
            else if (type == "2")
            {
                Console.WriteLine("\nDo you want ot process Payment \n1. Yes \n2. No");
            }

            string value = Console.ReadLine();


            // use of dictionary
            Dictionary<string, string> val = new Dictionary<string, string>();
            val["orderid"] = orderid;
            val["type"] = type;
            val["value"] = value;

            return val;
        }


    }
}
