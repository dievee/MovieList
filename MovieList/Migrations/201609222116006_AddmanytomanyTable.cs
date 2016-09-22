namespace MovieList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddmanytomanyTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Movies", newName: "Movie");
            RenameTable(name: "dbo.Notes", newName: "Note");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            CreateTable(
                "dbo.UserMovie",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        MovieId = c.Int(nullable: false),
                        IsLooked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.MovieId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Movie", t => t.MovieId)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            AddColumn("dbo.Movie", "UserMovie_UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Movie", "UserMovie_MovieId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "UserMovie_UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "UserMovie_MovieId", c => c.Int());
            CreateIndex("dbo.Movie", new[] { "UserMovie_UserId", "UserMovie_MovieId" });
            CreateIndex("dbo.AspNetUsers", new[] { "UserMovie_UserId", "UserMovie_MovieId" });
            AddForeignKey("dbo.Movie", new[] { "UserMovie_UserId", "UserMovie_MovieId" }, "dbo.UserMovie", new[] { "UserId", "MovieId" });
            AddForeignKey("dbo.AspNetUsers", new[] { "UserMovie_UserId", "UserMovie_MovieId" }, "dbo.UserMovie", new[] { "UserId", "MovieId" });
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserMovie", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.AspNetUsers", new[] { "UserMovie_UserId", "UserMovie_MovieId" }, "dbo.UserMovie");
            DropForeignKey("dbo.UserMovie", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Movie", new[] { "UserMovie_UserId", "UserMovie_MovieId" }, "dbo.UserMovie");
            DropIndex("dbo.AspNetUsers", new[] { "UserMovie_UserId", "UserMovie_MovieId" });
            DropIndex("dbo.UserMovie", new[] { "MovieId" });
            DropIndex("dbo.UserMovie", new[] { "UserId" });
            DropIndex("dbo.Movie", new[] { "UserMovie_UserId", "UserMovie_MovieId" });
            DropColumn("dbo.AspNetUsers", "UserMovie_MovieId");
            DropColumn("dbo.AspNetUsers", "UserMovie_UserId");
            DropColumn("dbo.Movie", "UserMovie_MovieId");
            DropColumn("dbo.Movie", "UserMovie_UserId");
            DropTable("dbo.UserMovie");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Note", newName: "Notes");
            RenameTable(name: "dbo.Movie", newName: "Movies");
        }
    }
}
