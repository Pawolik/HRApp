using HRApp.Models.Domains;
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
                Position = new PositionWrapper
                {
                    ID = model.Position.ID,
                    Title = model.Position.Title
                }
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
                //Position = new Position { ID = model.Position.ID }
            };
        }
    }
}
