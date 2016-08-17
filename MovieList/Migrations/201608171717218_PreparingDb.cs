namespace MovieList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreparingDb : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Movies", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Movies", name: "UserId", newName: "User_Id");
        }
    }
}
