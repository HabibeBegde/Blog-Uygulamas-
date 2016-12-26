using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blogum.veritabani
{
    public class Makale
    {
        [Key]
        public int id { get; set; }
        public String Baslik { get; set;  }
        public String Ozet { get; set; }
        public String Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public String url { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual List<Etiket> Etiket { get; set; }
        public virtual List<Yorum> Yorum { get; set; }

    }
}