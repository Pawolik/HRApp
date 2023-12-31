﻿using HRApp.Models.Domains;
using HRApp.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Models.Converters
{
    public static class EmployeeConverter
    {
        public static EmployeeWrapper ToWrapper(this Employee model)
        {
            return new EmployeeWrapper
            {
                ID = model.ID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Comments = model.Comments,
                Department = new DepartmentWrapper
                {
                    ID = model.Department.ID,
                    Name = model.Department.Name
                },
                Job = new JobWrapper
                {
                    ID = model.Job.ID,
                    Title = model.Job.Title
                },
                Salary = model.Salary,
                HireDate = model.HireDate,
                TerminationDate = model.TerminationDate,
            };
        }

        public static Employee ToDao(this EmployeeWrapper model)
        {
            return new Employee
            {
                ID = model.ID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Comments = model.Comments,
                DepartmentID = model.Department.ID,
                JobID = model.Job.ID,
                Salary = model.Salary,
                HireDate = model.HireDate,
                TerminationDate = model.TerminationDate,
            };
        }
    }
}
