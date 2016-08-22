namespace MovieList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableNotedDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "NotedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NotedDate", c => c.DateTime(nullable: false));
        }
    }
}
