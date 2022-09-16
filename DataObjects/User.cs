using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class User
    {
        public int VillagerID { get; set; }
        public String CharacterName { get; set; }
        public String LoginName { get; set; }
        public String Email { get; set; }
        public String PasswordHash { get; set; }
        public bool Active { get; set; }
        public List<String> Roles { get; set; }
    }
}
