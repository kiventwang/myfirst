using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceToolTest
{
    public class UserInformation
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public Role[] Roles { get; set; }
    }


    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }
    }
}
