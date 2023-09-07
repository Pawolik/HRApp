namespace HRApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkplaceChange : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "PositionID", newName: "WorkplaceID");
            RenameIndex(table: "dbo.Employees", name: "IX_PositionID", newName: "IX_WorkplaceID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Employees", name: "IX_WorkplaceID", newName: "IX_PositionID");
            RenameColumn(table: "dbo.Employees", name: "WorkplaceID", newName: "PositionID");
        }
    }
}
