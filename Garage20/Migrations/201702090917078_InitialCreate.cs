namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fordons",
                c => new
                    {
                        RegNr = c.String(nullable: false, maxLength: 128),
                        Typ = c.Int(nullable: false),
                        Färg = c.String(),
                        Märke = c.String(),
                        Modell = c.String(),
                        AntalHjul = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegNr);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fordons");
        }
    }
}
