namespace MovieList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotedDateField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NotedDate", c => c.DateTime());

        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NotedDate");
        }
    }
}
