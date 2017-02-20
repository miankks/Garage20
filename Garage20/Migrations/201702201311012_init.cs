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
                        RegNr = c.String(nullable: false),
                        Färg = c.String(nullable: false, maxLength: 30),
                        Märke = c.String(nullable: false, maxLength: 30),
                        Modell = c.String(nullable: false, maxLength: 30),
                        AntalHjul = c.Int(nullable: false),
                        Tid = c.DateTime(nullable: false),
                        MedlemsId = c.Int(nullable: false),
                        FordonstypId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fordonstyps", t => t.FordonstypId, cascadeDelete: true)
                .ForeignKey("dbo.Medlems", t => t.MedlemsId, cascadeDelete: true)
                .Index(t => t.MedlemsId)
                .Index(t => t.FordonstypId);
            
            CreateTable(
                "dbo.Fordonstyps",
                c => new
                    {
                        FordonstypId = c.Int(nullable: false, identity: true),
                        Typ = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.FordonstypId);
            
            CreateTable(
                "dbo.Medlems",
                c => new
                    {
                        MedlemsId = c.Int(nullable: false, identity: true),
                        Förnamn = c.String(nullable: false, maxLength: 30),
                        Efternamn = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.MedlemsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fordons", "MedlemsId", "dbo.Medlems");
            DropForeignKey("dbo.Fordons", "FordonstypId", "dbo.Fordonstyps");
            DropIndex("dbo.Fordons", new[] { "FordonstypId" });
            DropIndex("dbo.Fordons", new[] { "MedlemsId" });
            DropTable("dbo.Medlems");
            DropTable("dbo.Fordonstyps");
            DropTable("dbo.Fordons");
        }
    }
}
