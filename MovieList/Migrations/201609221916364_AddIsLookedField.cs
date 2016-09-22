namespace MovieList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsLookedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "IsLooked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "IsLooked");
        }
    }
}
