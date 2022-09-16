namespace MVCPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VillagerID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "VillagerID", c => c.Int());
            DropColumn("dbo.AspNetUsers", "EmployeeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "EmployeeID", c => c.Int());
            DropColumn("dbo.AspNetUsers", "VillagerID");
        }
    }
}
