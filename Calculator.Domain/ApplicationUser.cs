using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Domain
{
    public class ApplicationUser
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
