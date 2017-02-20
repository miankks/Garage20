namespace Garage20.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fordonstyps", "Typ", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Medlems", "Förnamn", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Medlems", "Efternamn", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Medlems", "Efternamn", c => c.String());
            AlterColumn("dbo.Medlems", "Förnamn", c => c.String());
            AlterColumn("dbo.Fordonstyps", "Typ", c => c.String());
        }
    }
}
