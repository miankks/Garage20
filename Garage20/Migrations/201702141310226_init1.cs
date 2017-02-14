namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fordons", "RegNr", c => c.String(nullable: false));
            AlterColumn("dbo.Fordons", "Färg", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Fordons", "Märke", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Fordons", "Modell", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fordons", "Modell", c => c.String(nullable: false));
            AlterColumn("dbo.Fordons", "Märke", c => c.String(nullable: false));
            AlterColumn("dbo.Fordons", "Färg", c => c.String());
            AlterColumn("dbo.Fordons", "RegNr", c => c.String());
        }
    }
}
