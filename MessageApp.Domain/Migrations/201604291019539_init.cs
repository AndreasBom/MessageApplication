namespace MessageApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Message", "ApiKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "ApiKey", c => c.String());
        }
    }
}
