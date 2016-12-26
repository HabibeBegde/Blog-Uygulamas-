using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blogum.veritabani
{
    public class Yorum
    {
        [Key]
        public int id { get; set; }
        public String Ad { get; set; }
        public String Email { get; set; }
        public DateTime Tarih { get; set; }
        public String Icerik { get; set; }
        public bool onay { get; set; }

        public virtual Makale Makale { get; set; }

    }
}