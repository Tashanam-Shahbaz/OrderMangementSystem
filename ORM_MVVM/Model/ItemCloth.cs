using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ORM_MVVM.Model
{
    public class ItemCloth : Items
    {
        public int Size { get; set; }
        public string Material { get; set; }

        public override string Type => ItemType();

        public override string ItemType()
        {
            return "cloth";
        }

        public ItemCloth()
        { 
        
        }
    }
}
