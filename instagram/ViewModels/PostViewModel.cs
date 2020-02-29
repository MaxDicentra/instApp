using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace instagram.ViewModels
{
    public class PostViewModel
    {
        [Required]
        [Display(Name = "Coment")]
        public string Coment{ get; }

        [Required]
        [Display(Name = "Photo")]
        public byte[] Photo { get; }
    }
}
