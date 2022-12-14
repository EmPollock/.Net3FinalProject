namespace MVCPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LoginName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LoginName");
        }
    }
}
