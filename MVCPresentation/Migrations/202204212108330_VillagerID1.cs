namespace MVCPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VillagerID1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "LoginName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LoginName", c => c.String());
        }
    }
}
