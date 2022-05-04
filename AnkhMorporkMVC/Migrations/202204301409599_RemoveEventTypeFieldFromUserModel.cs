namespace AnkhMorporkMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEventTypeFieldFromUserModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserModels", "EventType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserModels", "EventType", c => c.String());
        }
    }
}
