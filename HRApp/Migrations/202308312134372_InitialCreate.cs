namespace HRApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Comments = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        PositionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HRInformations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeID = c.Int(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        TerminationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "PositionID" });
            DropIndex("dbo.Employees", new[] { "DepartmentID" });
            DropTable("dbo.HRInformations");
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
