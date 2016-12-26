using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogum.veritabani
{
    public class Gosterim
    {
        public List<Etiket> EtiketGoster()
        {
            using (var db = new blog())
            {
                var etiketlerim = db.Etiket.ToList();
                return etiketlerim;
            }
        }
        
        public List<Kategori> KategoriGoster()
        {
            using (var db = new blog())
            {
                var kategorilerim = db.Kategori.OrderBy( p => p.Sira).ToList();
                return kategorilerim;
            }
        }
        public List<Makale> MakaleGoster()
        {
            using (var db = new blog())
            {
                var makalelerim = db.Makale.OrderBy( p => p.Tarih).Take(5).ToList();
                return makalelerim;
            }
        }
        public List<Makale> MakaleGetir()
        {
            using (var db = new blog())
            {
                var makale = db.Makale.OrderBy(p => p.Tarih).ToList();
                return makale;
            }
        }
        public List<Makale> KategoriIcin(string url)
        {
            using (var db = new blog())
            {
                var s = db.Kategori.Where(p => p.url == url).FirstOrDefault();
                
                var makale = db.Makale.Where(p => p.Kategori.id == s.id).ToList();                
                
                return makale;
            }           
        }
        
        public List<Makale> EtiketIcin(int id)
        {
            using (var db = new blog())
            {
                List<Makale> etiketiceren = new List<Makale>();
                var e = db.Etiket.Where(p => p.id  == id).First();
                var makaleler = db.Makale.ToList();
                foreach (var item in makaleler)
                {
                    if (item.Etiket.Contains(e))
                    {
                        etiketiceren.Add(item);
                    }

                }
                return etiketiceren;
            }
        }
        public Makale makaleGetir(string url)
        {
            using (var db = new blog())
            {
                var mkl = db.Makale.Where(p => p.url == url).FirstOrDefault();
                return mkl;
            }
        }
        public bool YorumKaydet(string url, Yorum yrm)
        {
            bool degisken=true;
            using (var db = new blog())
            {
                var mkl = db.Makale.Where(p => p.url == url).FirstOrDefault();
                db.Yorum.Add(yrm);
                db.SaveChanges();
                mkl.Yorum.Add(yrm);
                if (db.SaveChanges() <= 0)
                {
                    degisken = false;
                }
                return degisken;
            }

        }
        public List<Yorum> YorumlariGetir(string url)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            using (var db = new blog())
            {
                
                var m = db.Makale.Where(p => p.url == url).FirstOrDefault();
                if (m.Yorum.Count() <= 0)
                {
                    yorumlar = null;

                }
                else
                {
                    foreach (var item in m.Yorum)
                    {
                        if (item.onay == true)
                            yorumlar.Add(item);

                    }
                }
                return yorumlar;
            }
        }
        public List<Etiket> EtiketGetir(string url)
        {
            using (var db= new blog())
            {
                var m = db.Makale.Where(p => p.url == url).FirstOrDefault();
                List<Etiket> etiketler = m.Etiket;
                return etiketler;
            }
        }
        public bool IletisimKaydet(iletisim ilt)
        {
            bool degisken = true;
            using (var db = new blog())
            {
                db.iletisim.Add(ilt);
                if (db.SaveChanges() <= 0)
                    degisken = false;
                return degisken;
            }
        }
    }
}