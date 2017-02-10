namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fordons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNr = c.String(),
                        Typ = c.Int(nullable: false),
                        Färg = c.String(),
                        Märke = c.String(nullable: false),
                        Modell = c.String(nullable: false),
                        AntalHjul = c.Int(nullable: false),
                        Tid = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fordons");
        }
    }
}
