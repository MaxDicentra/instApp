using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace instagram.ViewModels
{
    public class CreatePublicationViewModel
    {
        [Required]
        //[Display(Name = "Comment")]
        public string Coment{ get; set; }

        [Required]
        //[Display(Name = "User")]
        public string UserName { get; set; }

        [Required]
        //[Display(Name = "User")]
        public DateTime dateTime { get; set; }

        [Required]
        //[Display(Name = "Photo")]
        public IFormFile Photo { get; set; }
    }
}
