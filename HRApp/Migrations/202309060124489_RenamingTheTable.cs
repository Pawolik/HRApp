namespace HRApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingTheTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Positions", newName: "Workplaces");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Workplaces", newName: "Positions");
        }
    }
}
