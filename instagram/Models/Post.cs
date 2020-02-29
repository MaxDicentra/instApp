using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace instagram.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Coment { get; set; }

        public DateTime dateTime { get; set; }
        public byte[] Photo { get; set; }
    }
}
