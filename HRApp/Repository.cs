﻿using HRApp.Models.Domains;
using HRApp.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HRApp.Models.Converters;

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

        public List<Position> GetPositions()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Positions.ToList();
            }
        }

        public List<EmployeeWrapper> GetEmployees(int departmentID)
        {
            using (var context = new ApplicationDbContext())
            {
                var employees = context
                    .Employees
                    .Include(x => x.Department)
                    .Include(x => x.Position)
                    .AsQueryable();

                if (departmentID != 0)
                {
                    employees = employees.Where(x =>  x.DepartmentID == departmentID);
                }


                return employees.ToList().Select( x => x.ToWrapper()).ToList();
            }
        }

        public void DeleteEmployee(int ID)
        {
            using(var context = new ApplicationDbContext())
            {
                var employeeToDelete = context.Employees.Find(ID);
                context.Employees.Remove(employeeToDelete);
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
                employeeToUpdate.PositionID = employee.PositionID;
                //pozostałe dane
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