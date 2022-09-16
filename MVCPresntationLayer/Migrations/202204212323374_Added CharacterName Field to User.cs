namespace MVCPresntationLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCharacterNameFieldtoUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CharacterName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CharacterName");
        }
    }
}
