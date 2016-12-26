using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blogum.veritabani
{
    public class iletisim
    {
        [Key]
        public int id { get; set; }
        public String Ad { get; set; }
        public String Email { get; set; }
        public String Mesaj { get; set; }
        public bool Onay { get; set; }
        public DateTime Tarih { get; set; }


    }
}