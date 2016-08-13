namespace MovieList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConnectionWithMovieAndUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Poster = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        IMDBRating = c.String(),
                        EventDate = c.String(),
                        IMDBLink = c.String(),
                        Comment = c.String(),
                        Mark = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Movies", new[] { "User_Id" });
            DropTable("dbo.Movies");
        }
    }
}
