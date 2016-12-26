namespace blogum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iletisimTarih : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.iletisims", "Tarih", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.iletisims", "Tarih");
        }
    }
}
