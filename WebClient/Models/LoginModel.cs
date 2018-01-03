using DMODTO;
using DMOEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class LoginModel
    {
        public UsersDTO User { get; set; }
        public string Password { get; set; }
        public string msg { get; set; }

    }
}