using HRApp.Models.Configurations;
using HRApp.Models.Domains;
using System;
using System.Data.Entity;
using System.Linq;

namespace HRApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Workplaces { get; set; }
        public DbSet<HRInformation> HRInformations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new HRInformationConfiguration());
            modelBuilder.Configurations.Add(new JobConfiguration());
        }
    }
}