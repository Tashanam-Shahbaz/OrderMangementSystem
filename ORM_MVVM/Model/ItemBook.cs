using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ORM_MVVM.Model
{
    public class ItemBook : Items
    {
        public string Author { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public override string Type => ItemType();

        public override string ItemType()
        {
            return "book";
        }
        public ItemBook()
        {
        }

    }
}
