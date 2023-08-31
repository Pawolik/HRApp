﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Models
{
    public class Employee
    {
        public Employee()
        {
           Department = new Department();
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }

        public int DepartmentID { get; set; }  // Foreign Key
        public Department Department { get; set; }  // Navigation Property

        public int PositionID { get; set; }  // Foreign Key
        public Position Position { get; set; }  // Navigation Property

        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}
