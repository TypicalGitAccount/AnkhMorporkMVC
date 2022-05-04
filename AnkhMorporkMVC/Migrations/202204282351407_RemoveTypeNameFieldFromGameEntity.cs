namespace AnkhMorporkMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTypeNameFieldFromGameEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameEntityModels", "IsOccupied", c => c.Boolean());
            DropColumn("dbo.GameEntityModels", "TypeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameEntityModels", "TypeName", c => c.String(nullable: false));
            DropColumn("dbo.GameEntityModels", "IsOccupied");
        }
    }
}
