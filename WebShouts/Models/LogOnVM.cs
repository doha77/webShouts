using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShouts.Models
{
    public class LogOnVM
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
