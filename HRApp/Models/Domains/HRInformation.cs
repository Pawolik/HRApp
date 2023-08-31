using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Models.Domains
{
    public class HRInformation
    {
        public int ID { get; set; }
        public decimal Salary { get; set; }
        public int EmployeeID { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}
