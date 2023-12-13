using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ORM_MVVM.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public virtual string Role => GetRole();
        public virtual string GetRole()
        {
            return "user";
        }
        public User() {
        }
    }
}
