using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blogum.veritabani
{
    public class Kullanici
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String Ad { get; set; }
        [Required]
        public String Sifre { get; set; }

    }
}