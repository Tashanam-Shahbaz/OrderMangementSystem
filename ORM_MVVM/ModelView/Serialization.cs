using ORM_MVVM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ORM_MVVM.ModelView
{
    internal class Serialization
    {
        public static List<Items> DeSerializeItemList()
        {
            string filePath = "items.xml";

            List<Items> itemList = new List<Items>();
            if (File.Exists(filePath)) 
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Items>), new[] { typeof(ItemBook), typeof(ItemCloth), typeof(ItemElectronic) });
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    itemList = (List<Items>)serializer.Deserialize(fileStream);
                }
            }

            return itemList;

        }
        public static List<User> DeSerializeUserList()
        {
            string filePath = "users.xml";

            List<User> itemList = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>), new[] { typeof(Admin) ,typeof(Customer)});
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                itemList = (List<User>)serializer.Deserialize(fileStream);
            }
            return itemList;

        }
        public static List<Order> DeSerializeOrderList()
        {
            string filePath = "orders.xml";

            List<Order> orderList = new List<Order>();
            if (File.Exists(filePath)) 
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Order>), new[] { typeof(ItemBook), typeof(ItemCloth), typeof(ItemElectronic) });
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    orderList = (List<Order>)serializer.Deserialize(fileStream);
                }
            }
            return orderList;

        }
        public static bool SerializeItemList(List<Items> itemList)
        {

            try
            {
                string filePath = "items.xml";
                XmlSerializer ser = new XmlSerializer(typeof(List<Items>), new[] { typeof(ItemBook), typeof(ItemCloth), typeof(ItemElectronic) });
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    ser.Serialize(writer, itemList);
                }
               
            }
            catch
            {
                return false;
            }
            return true;

        }

        public static bool SerializeUserList(List<User> itemList)
        {

            try
            {
                string filePath = "users.xml";
                XmlSerializer abc = new XmlSerializer(typeof(List<User>), new[] { typeof(Admin), typeof(Customer) });
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    abc.Serialize(writer, itemList);
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                 return false;
            }
            return true;
        }


        public static bool SerializeOrderList(List<Order> itemList)
        {

            try
            {
                string filePath = "orders.xml";
                XmlSerializer ser = new XmlSerializer(typeof(List<Order>), new[] { typeof(ItemBook), typeof(ItemCloth), typeof(ItemElectronic) });
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    ser.Serialize(writer, itemList);
                }
               
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
