namespace Formule1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvirtualdriver : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProfileViewModels", "engineModel_ID", "dbo.EngineModels");
            DropIndex("dbo.ProfileViewModels", new[] { "engineModel_ID" });
            AlterColumn("dbo.ProfileViewModels", "EngineModel_ID", c => c.Int());
            CreateIndex("dbo.ProfileViewModels", "DriverID");
            CreateIndex("dbo.ProfileViewModels", "EngineModel_ID");
            AddForeignKey("dbo.ProfileViewModels", "DriverID", "dbo.DriverModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProfileViewModels", "EngineModel_ID", "dbo.EngineModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileViewModels", "EngineModel_ID", "dbo.EngineModels");
            DropForeignKey("dbo.ProfileViewModels", "DriverID", "dbo.DriverModels");
            DropIndex("dbo.ProfileViewModels", new[] { "EngineModel_ID" });
            DropIndex("dbo.ProfileViewModels", new[] { "DriverID" });
            AlterColumn("dbo.ProfileViewModels", "EngineModel_ID", c => c.Int());
            CreateIndex("dbo.ProfileViewModels", "engineModel_ID");
            AddForeignKey("dbo.ProfileViewModels", "engineModel_ID", "dbo.EngineModels", "ID");
        }
    }
}
