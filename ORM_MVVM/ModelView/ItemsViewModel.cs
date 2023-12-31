﻿using ORM_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace ORM_MVVM.ModelView
{
    internal abstract class BaseItemViewModel
    {
        // Rules for item addition
        public abstract bool AddItem(string itemname, string description, float pricesperitem, Brand brand);
        public abstract bool AddItem(string itemname, string description, float pricesperitem,int size, string material);
        public abstract bool AddItem(string itemname, string description, float pricesperitem, string Author );

     }
        internal class ItemsViewModel : BaseItemViewModel
        {

            public override bool AddItem(string itemname, string description, float pricesperitem, Brand brand)
            {

                List<Items> ItemList =  Serialization.DeSerializeItemList();

                ItemElectronic electronic = new ItemElectronic();

            if (ItemList.Any()) 
            {
                electronic.Id = ItemList.Max(item => item.Id) + 1;
            }
            else 
            {
                electronic.Id = 1;
            }
                electronic.Name = itemname;
                electronic.Description = description;
                electronic.Price = pricesperitem;
                electronic.Brand = brand;
           
                ItemList.Add(electronic);
                bool result = Serialization.SerializeItemList(ItemList);
                return result;   
            }

            public override bool  AddItem(string itemname, string description, float pricesperitem, int size, string material)
            {
                List<Items> ItemList = Serialization.DeSerializeItemList();
                ItemCloth cloth = new ItemCloth();


                if (ItemList.Any())
                {
                    cloth.Id = ItemList.Max(item => item.Id) + 1;
                }
                else
                {
                    cloth.Id = 1;
                }

                cloth.Name = itemname;
                cloth.Price = pricesperitem;
                cloth.Size = size;
                cloth.Price = pricesperitem;
                cloth.Material = material;

                ItemList.Add(cloth);
                bool result = Serialization.SerializeItemList(ItemList);
                return result;
            }

            public override bool AddItem(string itemname, string description, float pricesperitem, string author)
            {
                List<Items> ItemList = Serialization.DeSerializeItemList();
                ItemBook book = new ItemBook();


            if (ItemList.Any())
            {
                book.Id = ItemList.Max(item => item.Id) + 1;
            }
            else
            {
                book.Id = 1;
            }
            book.Name = itemname;
                book.Price = pricesperitem;
                book.Author = author;
                book.Description = description;

                ItemList.Add(book);
                bool result = Serialization.SerializeItemList(ItemList);
                return result;
            }

        // cannot override the updata method.
        public string UpdateItem(int itemid, string itemtype, string value)
        {
            List<Items> items = Serialization.DeSerializeItemList();
            string msg = "";

            int index = items.FindIndex(item => item.Id == itemid);

            if (index == -1)
            {
                return "Item with given ID not found.";
            }

            switch (itemtype?.Replace(" ", "").ToLower())
            {
                case "1":
                    msg += $"Updating Name for Item ID {itemid}...";
                    items[index].Name = value;
                    break;

                case "2":
                    msg += $"Updating Description for Item ID {itemid}...";
                    items[index].Description = value;
                    break;

                case "3":
                    msg += $"Updating Price for Item ID {itemid}...";
                    float newPrice;
                    if (float.TryParse(value, out newPrice))
                    {
                        items[index].Price = newPrice;
                    }
                    else
                    {
                        return "Invalid price format. Please enter a valid number.";
                    }
                    break;

                case "4":
                    msg += $"Updating Author for Item ID {itemid}...";
                    if (items[index] is ItemBook bookItem)
                    {
                        bookItem.Author = value;
                        items[index] = bookItem;
                    }
                    else
                    {
                        return "You cannot change the author field for this ID.";
                    }
                    break;

                case "5":
                    msg += $"Updating Size for Item ID {itemid}...";
                    int newSize;
                    if (int.TryParse(value, out newSize))
                    {
                        if (items[index] is ItemCloth itemCloth)
                        {
                            itemCloth.Size = newSize;
                            items[index] = itemCloth;
                        }
                        else
                        {
                            return "You cannot change the size field for this ID.";
                        }
                    }
                    else
                    {
                        return "Invalid size format. Please enter a valid number.";
                    }
                    break;

                case "6":
                    msg += $"Updating Material for Item ID {itemid}...";
                    if (items[index] is ItemCloth itemCloth1)
                    {
                        itemCloth1.Material = value;
                        items[index] = itemCloth1;
                    }
                    else
                    {
                        return "You cannot change the material field for this ID.";
                    }
                    break;

                case "7":
                    msg += $"Updating Brand for Item ID {itemid}...";
                    if (items[index] is ItemElectronic itemElectronic)
                    {
                        if (Enum.TryParse<Brand>(value, true, out Brand brandValue))
                        {
                            itemElectronic.Brand = brandValue;
                            items[index] = itemElectronic;
                        }
                        else
                        {
                            return "Invalid brand. Please provide a valid brand value.";
                        }
                    }
                    else
                    {
                        return "You cannot change the brand field for this ID.";
                    }
                    break;

                default:
                    return "Please provide a valid item type.";
            }

            bool ser = Serialization.SerializeItemList(items);
            msg = ser ? msg : "Serialization could not be done successfully";
            return msg;
        }

        public void ViewItems()
        {
            List<Items> items = Serialization.DeSerializeItemList();

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("| Item ID | Item Name | Item Description | Price Per Item | Item Brand | Item Author | Size | Material | Item Type |");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (var item in items)
            {
                StringBuilder tableRow = new StringBuilder("| ");

                if (item is ItemBook book)
                {
                    tableRow.Append($"{item.Id}".PadRight(10));
                    tableRow.Append(" | ");
                    tableRow.Append($"{item.Name}".PadRight(20));
                    tableRow.Append(" | ");
                    tableRow.Append($"{item.Description}".PadRight(25));
                    tableRow.Append(" | ");
                    tableRow.Append($"{item.Price}".PadRight(14));
                    tableRow.Append(" | ");
                    tableRow.Append("".PadRight(8));  // Item Brand column placeholder
                    tableRow.Append(" | ");
                    tableRow.Append($"{book.Author}".PadRight(8));
                    tableRow.Append(" | ");
                    tableRow.Append("".PadRight(8));  // Size column placeholder
                    tableRow.Append(" | ");
                    tableRow.Append("".PadRight(8));  // Material column placeholder
                    tableRow.Append(" | ");
                    tableRow.Append("Book".PadRight(8));
                    tableRow.Append(" |");
                }
                else if (item is ItemCloth cloth)
                {
                    tableRow.Append($"{item.Id}".PadRight(10));
                    tableRow.Append(" | ");
                    tableRow.Append($"{item.Name}".PadRight(20));
                    tableRow.Append(" | ");
                    tableRow.Append($" {item.Description}".PadRight(25));
                    tableRow.Append(" | ");
                    tableRow.Append($"{item.Price}".PadRight(14));
                    tableRow.Append(" | ");
                    tableRow.Append("".PadRight(8));  // Item Brand column placeholder
                    tableRow.Append(" | ");
                    tableRow.Append("".PadRight(8));  // Item Author column placeholder
                    tableRow.Append(" | ");
                    tableRow.Append($"{cloth.Size}".PadRight(8));
                    tableRow.Append(" | ");
                    tableRow.Append($"{cloth.Material}".PadRight(8));
                    tableRow.Append(" | ");
                    tableRow.Append("Cloth".PadRight(8));
                    tableRow.Append(" |");
                }
                else if (item is ItemElectronic electronic)
                {
                    tableRow.Append($"{item.Id}".PadRight(10));
                    tableRow.Append(" | ");
                    tableRow.Append($"{item.Name}".PadRight(20));
                    tableRow.Append(" | ");
                    tableRow.Append($" {item.Description}".PadRight(25));
                    tableRow.Append(" | ");
                    tableRow.Append($"{item.Price}".PadRight(14));
                    tableRow.Append(" | ");
                    tableRow.Append($"{electronic.Brand}".PadRight(8));
                    tableRow.Append(" | ");
                    tableRow.Append("".PadRight(8));  // Item Author column placeholder
                    tableRow.Append(" | ");
                    tableRow.Append("".PadRight(8));  // Size column placeholder
                    tableRow.Append(" | ");
                    tableRow.Append("".PadRight(8));  // Material column placeholder
                    tableRow.Append(" | ");
                    tableRow.Append("Electronic".PadRight(8));
                    tableRow.Append(" |");
                }

                Console.WriteLine(tableRow.ToString());
            }

            Console.WriteLine("-------------------------------------------------------------");
        }
        public void RemoveItem(int id)
        {
            List<Items> lst = Serialization.DeSerializeItemList();
            lst.RemoveAll(item => item.Id == id);
            Serialization.SerializeItemList(lst);
        }


    }
}
