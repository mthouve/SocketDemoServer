using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocketDemo.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public UserViewModel(string name)
        {
            Name = name;
        }
    }
}