namespace MVCPresntationLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notsure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Critters",
                c => new
                    {
                        CritterId = c.String(nullable: false, maxLength: 128),
                        RainNeeded = c.Boolean(nullable: false),
                        InMuseum = c.Boolean(nullable: false),
                        Price = c.Int(nullable: false),
                        CritterTypeId = c.String(),
                        Active = c.Boolean(nullable: false),
                        MuseumBy = c.String(),
                        CatchDescription = c.String(),
                        CatchableMonthString = c.String(),
                        CatchableHourString = c.String(),
                        UserCaughtDateString = c.String(),
                        CaughtByCurrentUser = c.Boolean(),
                        SpotId = c.String(),
                        SpotDescription = c.String(),
                        LocationId = c.String(),
                        ShadowSizeId = c.String(),
                        LocationDescription = c.String(),
                        ShadowSizeId1 = c.String(),
                        movementId = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CritterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Critters");
        }
    }
}
