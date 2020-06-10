using System;
using System.Collections.Generic;
using System.Text;

namespace EpidemicTracker.data.Models
{
    public class Login
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
