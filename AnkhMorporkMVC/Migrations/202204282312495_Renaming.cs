namespace AnkhMorporkMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renaming : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GameEntities", newName: "GameEntityModels");
            RenameTable(name: "dbo.Users", newName: "UserModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserModels", newName: "Users");
            RenameTable(name: "dbo.GameEntityModels", newName: "GameEntities");
        }
    }
}
