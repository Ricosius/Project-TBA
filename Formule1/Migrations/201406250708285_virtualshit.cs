namespace Formule1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virtualshit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProfileViewModels", "EngineModel_ID", "dbo.EngineModels");
            DropIndex("dbo.ProfileViewModels", new[] { "EngineModel_ID" });
            CreateIndex("dbo.ProfileViewModels", "ChassisID");
            CreateIndex("dbo.ProfileViewModels", "EngineID");
            AddForeignKey("dbo.ProfileViewModels", "ChassisID", "dbo.ChassisModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProfileViewModels", "EngineID", "dbo.EngineModels", "ID", cascadeDelete: true);
            DropColumn("dbo.ProfileViewModels", "EngineModel_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfileViewModels", "EngineModel_ID", c => c.Int());
            DropForeignKey("dbo.ProfileViewModels", "EngineID", "dbo.EngineModels");
            DropForeignKey("dbo.ProfileViewModels", "ChassisID", "dbo.ChassisModels");
            DropIndex("dbo.ProfileViewModels", new[] { "EngineID" });
            DropIndex("dbo.ProfileViewModels", new[] { "ChassisID" });
            CreateIndex("dbo.ProfileViewModels", "EngineModel_ID");
            AddForeignKey("dbo.ProfileViewModels", "EngineModel_ID", "dbo.EngineModels", "ID");
        }
    }
}
