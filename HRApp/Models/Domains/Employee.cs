using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Models.Domains
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public int JobID { get; set; }
        public Job Job { get; set; }


    }
}
