namespace MVCPresntationLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VillagerID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "VillagerID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "VillagerID");
        }
    }
}
