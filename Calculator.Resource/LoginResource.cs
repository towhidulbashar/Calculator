using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Calculator.Resource
{
    public class LoginResource
    {
        [Required(ErrorMessage = "UserName is required.", AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.", AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
