using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DashBoard.Models.Login
{
    public class Login
    {
        public  string UserName { get; set; }
        public  string Password { get; set; }
    }

    public static class LoginStatic
    {
        public static string UserName { get; set; }
        public static string Password { get; set; }
    }
}