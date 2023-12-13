using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ORM_MVVM.Model
{
    public class Admin : User
    {

        public string AdminRole { get; set; }
        public string Department { get; set; }

        public override string Role => GetRole();

        public override string GetRole()
        {
            return "admin";
        }
        public Admin() 
        {

        }
    }
}
