using HRApp.Models.Domains;
using HRApp.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HRApp.Models.Converters;
using System.ComponentModel.DataAnnotations;

namespace HRApp
{
    public class Repository
    {
        public List<Department> GetDepartments()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Departments.ToList();
            }
        }

        public List<Job> GetJobs()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Workplaces.ToList();
            }
        }

        public List<EmployeeWrapper> GetEmployees(int departmentID)
        {
            using (var context = new ApplicationDbContext())
            {
                var employees = context
                    .Employees
                    .Include(x => x.Department)
                    .Include(x => x.Job)
                    .AsQueryable();

                if (departmentID != 0)
                {
                    employees = employees.Where(x =>  x.DepartmentID == departmentID);
                }

                return employees.ToList().Select( x => x.ToWrapper()).ToList();
            }
        }

        public void ReleaseEmployee(int ID)
        {

            // usuwanie pracownika
            /*using(var context = new ApplicationDbContext())
            {
                var employeeToDelete = context.Employees.Find(ID);
                context.Employees.Remove(employeeToDelete);
                context.SaveChanges();
            }*/

            //zwalnianie pracownika
            using (var context = new ApplicationDbContext())
            {
                var employeeToRelease = context.Employees.Find(ID);
                employeeToRelease.TerminationDate = DateTime.Today;
                context.SaveChanges();
            }

        }

        public void UpdateEmployee(EmployeeWrapper employeeWrapper)
        {
            var employee = employeeWrapper.ToDao();

            using (var context = new ApplicationDbContext())
            {
                var employeeToUpdate = context.Employees.Find(employee.ID);
                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.Email = employee.Email;
                employeeToUpdate.Comments = employee.Comments;
                employeeToUpdate.DepartmentID = employee.DepartmentID;
                employeeToUpdate.JobID = employee.JobID;
                employeeToUpdate.Salary = employee.Salary;
                employeeToUpdate.HireDate = employee.HireDate;
                employeeToUpdate.TerminationDate = employee.TerminationDate;
                context.SaveChanges();
            }
        }

        public void AddEmployee(EmployeeWrapper employeeWrapper)
        {
            var employee = employeeWrapper.ToDao();

            using (var context = new ApplicationDbContext())
            {
                var dbEmployee = context.Employees.Add(employee);

                context.SaveChanges();
            }
        }
    }
}
