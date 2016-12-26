namespace blogum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etikets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Makales",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Ozet = c.String(),
                        Icerik = c.String(),
                        Tarih = c.DateTime(nullable: false),
                        url = c.String(),
                        Kategori_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Kategoris", t => t.Kategori_id)
                .Index(t => t.Kategori_id);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        url = c.String(),
                        Sira = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Email = c.String(),
                        Tarih = c.DateTime(nullable: false),
                        Icerik = c.String(),
                        onay = c.Boolean(nullable: false),
                        Makale_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Makales", t => t.Makale_id)
                .Index(t => t.Makale_id);
            
            CreateTable(
                "dbo.iletisims",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Email = c.String(),
                        Mesaj = c.String(),
                        Onay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Sifre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MakaleEtikets",
                c => new
                    {
                        Makale_id = c.Int(nullable: false),
                        Etiket_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Makale_id, t.Etiket_id })
                .ForeignKey("dbo.Makales", t => t.Makale_id, cascadeDelete: true)
                .ForeignKey("dbo.Etikets", t => t.Etiket_id, cascadeDelete: true)
                .Index(t => t.Makale_id)
                .Index(t => t.Etiket_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorums", "Makale_id", "dbo.Makales");
            DropForeignKey("dbo.Makales", "Kategori_id", "dbo.Kategoris");
            DropForeignKey("dbo.MakaleEtikets", "Etiket_id", "dbo.Etikets");
            DropForeignKey("dbo.MakaleEtikets", "Makale_id", "dbo.Makales");
            DropIndex("dbo.MakaleEtikets", new[] { "Etiket_id" });
            DropIndex("dbo.MakaleEtikets", new[] { "Makale_id" });
            DropIndex("dbo.Yorums", new[] { "Makale_id" });
            DropIndex("dbo.Makales", new[] { "Kategori_id" });
            DropTable("dbo.MakaleEtikets");
            DropTable("dbo.Kullanicis");
            DropTable("dbo.iletisims");
            DropTable("dbo.Yorums");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Makales");
            DropTable("dbo.Etikets");
        }
    }
}
