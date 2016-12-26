using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blogum.veritabani
{
    public class Kategori
    {
        [Key]
        public int id { get; set;}
        public String Ad { get; set; }
        public String url { get; set; }
        public int Sira { get; set;  }

        public virtual List<Makale> Makale { get; set; }


    }
}