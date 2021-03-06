namespace WebApplication.ContextBMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BValue1 = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BModels");
        }
    }
}
