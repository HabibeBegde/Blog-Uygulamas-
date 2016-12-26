using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Data.Entity;



namespace blogum.veritabani
{
    public class islemler
    {
        public bool GirisYap(Kullanici k)
        {
            bool degisken = true;
            using (var db = new blog())
            {
                var sayi = db.Kullanici.Where(p => p.Ad == k.Ad && p.Sifre == k.Sifre).Count();
                if (sayi <= 0)
                {
                    degisken = false;
                }
                else
                {
                    HttpContext.Current.Session["online"] = "Admin";

                }
                return degisken;
            }
        }
        public List<String> KategoriIsim()
        {
            List<String> isim = new List<string>();
            using (var db = new blog())
            {
                var liste = db.Kategori.ToList(); ;
                foreach (var item in liste)
                {
                    isim.Add(item.Ad);
                }
                return isim;
            }

        }
        public bool KategoriKaydet(Kategori k)
        {
            bool degisken = true;
            using (var db = new blog())
            {
                db.Kategori.Add(k);
                if (db.SaveChanges() <= 0)
                    degisken = false;
                return degisken;
            }
        }
        public Kategori KategoriGetir(string ad)
        {
            using (var db = new blog())
            {
                var kategori = db.Kategori.Where(p => p.Ad == ad).FirstOrDefault();
                return kategori;
            }
        }
        public bool KategoriDuzenle(Kategori k)
        {
            bool degisken = true;
            using (var db = new blog())
            {
                var kategori = db.Kategori.Where(p => p.id == k.id).FirstOrDefault();
                kategori.Ad = k.Ad;
                kategori.Sira = k.Sira;
                kategori.url = k.url;
                if (db.SaveChanges() <= 0)
                {
                    degisken = false;
                }
                return degisken;

            }
        }
        public bool KategoriSil(int id)
        {
            bool degisken = true;
            using (var db = new blog())
            {
                var kt = db.Kategori.Where(x => x.id == id).FirstOrDefault();
                db.Entry(kt).State = System.Data.Entity.EntityState.Deleted;
                if (db.SaveChanges() <= 0)
                {
                    degisken = false;
                }
                return degisken;

            }
        }
        public List<String> EtiketIsim()
        {
            List<String> isim = new List<string>();
            using (var db = new blog())
            {
                var liste = db.Etiket.ToList(); ;
                foreach (var item in liste)
                {
                    isim.Add(item.Ad);
                }
                return isim;
            }

        }
        public Etiket EtiketiGetir(string ad)
        {
            using (var db = new blog())
            {
                var etiket = db.Etiket.Where(p => p.Ad == ad).FirstOrDefault();
                return etiket;
            }
        }
        public bool EtiketDuzenle(Etiket etk)
        {
            bool degisken = true;
            using (var db = new blog())
            {
                var etiket = db.Etiket.Where(p => p.id == etk.id).FirstOrDefault();
                etiket.Ad = etk.Ad;
                
                if (db.SaveChanges() <= 0)
                {
                    degisken = false;
                }
                return degisken;

            }
        }
        public bool EtiketSil(int id)
        {
            bool degisken = true;
            using (var db = new blog())
            {
                var etk = db.Etiket.Where(x => x.id == id).FirstOrDefault();
                db.Entry(etk).State = System.Data.Entity.EntityState.Deleted;
                if (db.SaveChanges() <= 0)
                {
                    degisken = false;
                }
                return degisken;

            }
        }
        public List<iletisim> iletisimGetir()
        {
            using (var db = new blog())
            {
                var s = db.iletisim.Where(p => p.Onay == false).ToList();
                return s;
            }
        }
        public iletisim iletisimGetir(int id)
        {
            using (var db = new blog())
            {
                var s = db.iletisim.Where(p => p.id == id).FirstOrDefault() ;
                return s;
            }
        }
        public bool iletisimSil()
        {
            bool degisken = true;
            using (var db = new blog())
            {
                 var s = db.iletisim.Where(x => x.Onay == true).ToList();
                foreach (var item in s)
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                if (db.SaveChanges() <= 0)
                {
                    degisken = false;
                }
                return degisken;
                  
            }
        }
        public void iletisimOnay(int id)
        {
            using (var db = new blog())
            {
                var mail = db.iletisim.Where(p => p.id == id).FirstOrDefault();
                mail.Onay = true;
                db.SaveChanges();

            }
        }

        public void MailGonder(cevapla cvp)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress("habibebegdee@gmail.com");
            email.To.Add(cvp.MailAdresi);
            email.IsBodyHtml = true;
            email.Subject = cvp.Konu;
            string mesaj = string.Format("bana göndermiş oldugunuz mesaj : <br/> {0} <br/> benim gönderdiğim mesaj : <br/> {1} <br/>  <hr/>  <a href='{2}' > sitem </a>", cvp.iletisimMesaji, cvp.Mesaj, @"http://sitelinki");
            email.Body = mesaj;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("habibebegdee@gmail.com", "begde.517");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.Send(email);

        }
        public List<Yorum> YorumGetir()
        {
            using (var db = new blog())
            {
                var s = db.Yorum.Where(p => p.onay == false).ToList();
                return s;
            }
        }
        public void YorumOnayla(int id)
        {
            using (var db = new blog())
            {
                var y = db.Yorum.Where(p => p.id == id).FirstOrDefault();
                y.onay = true;
                db.SaveChanges();
            }
        }
        public void YorumSil(int id)
        {
            using (var db = new blog())
            {
                var y = db.Yorum.Where(p => p.id == id).FirstOrDefault();
                db.Entry(y).State = EntityState.Deleted;
                db.SaveChanges();

            }
        }

        public bool MakaleKaydet(Makale mkl, List<string> olmayanEtiketler, List<string> varolanEtiketler, String kategori)
        {
            bool degisken = true;
            using (var db = new blog())
            {
                List<Etiket> etiketlerim = new List<Etiket>();
                if (olmayanEtiketler != null)
                {
                    foreach (var item in olmayanEtiketler)
                    {
                        Etiket etk = new Etiket()
                        {
                            Ad = item
                        };
                        db.Etiket.Add(etk);
                        db.SaveChanges();
                        etiketlerim.Add(etk);
                    }
                }
                foreach (var item in varolanEtiketler)
                {
                    var s = db.Etiket.Where(p => p.Ad == item).FirstOrDefault();
                    etiketlerim.Add(s);

                }
                var s1 = db.Kategori.Where(p => p.Ad == kategori).FirstOrDefault();
                mkl.Etiket = etiketlerim;
                mkl.Kategori = s1;
                db.Makale.Add(mkl);
                if (db.SaveChanges() <= 0)
                {
                    degisken = false;
                }
                return degisken;
            }

        }
        public List<Makale> MakaleIsim()
        {
            using (var db = new blog())
            {
                var mkl = db.Makale.ToList();
                return mkl;
            }
        }
        public bool MakaleSil(List<int> id)
        {
            bool degisken =true;
            using (var db = new blog())
            {
                foreach (var item in id)
                {
                    var s = db.Makale.Where(p => p.id == item).FirstOrDefault();
                    db.Entry(s).State= EntityState.Deleted;
                }
                if (db.SaveChanges() <= 0)
                
                    degisken = false;
                
            }
            return degisken;
        }
        public bool MakaleDuzenle(Makale mkl)
        {
            bool degisken = true;
            using (var db  = new blog())
            {
                var s = db.Makale.Where(p => p.id == mkl.id).FirstOrDefault();
                s.Baslik = mkl.Baslik; s.Ozet = mkl.Ozet; s.Icerik = mkl.Icerik; s.url = mkl.url;
                if (db.SaveChanges() <= 0)
                {
                    degisken = false;
                }
                return degisken;
                
            }
        }
    }
}