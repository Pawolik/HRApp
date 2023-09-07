namespace HRApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Employees", "HireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "TerminationDate", c => c.DateTime());
            DropTable("dbo.HRInformations");
        }
        
        public override void Down()
        {
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
            
            DropColumn("dbo.Employees", "TerminationDate");
            DropColumn("dbo.Employees", "HireDate");
            DropColumn("dbo.Employees", "Salary");
        }
    }
}
