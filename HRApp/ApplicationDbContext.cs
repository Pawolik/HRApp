using HRApp.Models.Configurations;
using HRApp.Models.Domains;
using HRApp.Properties;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace HRApp
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext()
            : base(GetConnectionStringFromSettings())
        {

        }
        private static string GetConnectionStringFromSettings()
        {
            string serverAddress = Settings.Default.ServerAddress;
            string serverName = Settings.Default.ServerName;
            string databaseName = Settings.Default.DataBase;
            string username = Settings.Default.User;
            string password = Settings.Default.Password;

            return $"Server={serverAddress}\\{serverName};Database={databaseName};User Id={username};Password={password};";
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Workplaces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new JobConfiguration());
        }
    }
}