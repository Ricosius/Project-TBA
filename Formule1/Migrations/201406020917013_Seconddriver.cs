namespace Formule1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seconddriver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileViewModels", "SecondDriverID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileViewModels", "SecondDriverID");
        }
    }
}
