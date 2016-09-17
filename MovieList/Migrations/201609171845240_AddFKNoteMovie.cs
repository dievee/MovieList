namespace MovieList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKNoteMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "MovieId", c => c.Int());
            CreateIndex("dbo.Notes", "MovieId");
            AddForeignKey("dbo.Notes", "MovieId", "dbo.Movies", "MovieId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "MovieId", "dbo.Movies");
            DropIndex("dbo.Notes", new[] { "MovieId" });
            DropColumn("dbo.Notes", "MovieId");
        }
    }
}
