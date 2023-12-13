using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ORM_MVVM.Model
{

    public enum Brand
    {
        sony,
       samsung,
        lg
    }
    public class ItemElectronic : Items
    {
        public Brand Brand { get; set; }
        public override string Type => ItemType();

        public override string ItemType()
        {
            return "electronic";
        }
        public ItemElectronic()
        {  
        
        }
    }
}
