using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Models.Wrappers
{
    public class EmployeeWrapper
    {
        public EmployeeWrapper()
        {
            Department = new DepartmentWrapper();
            Job = new JobWrapper();
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }

        public int DepartmentID { get; set; }  // Foreign Key
        public DepartmentWrapper Department { get; set; }  // Navigation Property

        public int JobID { get; set; }  // Foreign Key
        public JobWrapper Job { get; set; }  // Navigation Property

        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}
