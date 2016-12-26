using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace blogum.veritabani
{
    public class blog : DbContext
    {
        public DbSet<Etiket> Etiket { get; set; }
        public DbSet<iletisim> iletisim { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Makale> Makale { get; set; }
        public DbSet<Yorum> Yorum { get; set; }

    }
}