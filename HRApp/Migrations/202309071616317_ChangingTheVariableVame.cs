namespace HRApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingTheVariableVame : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "WorkplaceID", newName: "JobID");
            RenameIndex(table: "dbo.Employees", name: "IX_WorkplaceID", newName: "IX_JobID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Employees", name: "IX_JobID", newName: "IX_WorkplaceID");
            RenameColumn(table: "dbo.Employees", name: "JobID", newName: "WorkplaceID");
        }
    }
}
