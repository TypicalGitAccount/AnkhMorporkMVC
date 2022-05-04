namespace AnkhMorporkMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEventAnswerFomUserModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserModels", "EventAnswer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserModels", "EventAnswer", c => c.String());
        }
    }
}
