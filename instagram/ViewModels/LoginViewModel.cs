using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace instagram.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
    
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }
    
        [Display(Name ="Remeber me")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
        public string Email { get; internal set; }
    }

}
