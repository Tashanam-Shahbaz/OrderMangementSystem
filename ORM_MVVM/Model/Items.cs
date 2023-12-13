using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_MVVM.Model
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public virtual string Type => ItemType();
        public virtual string ItemType()
        {
            return "general";
        }

        public Items()
        {

        }
    }
}
