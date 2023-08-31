using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Models.Domains
{
    public class Department
    {
        public Department()
        {
            Employees = new Collection<Employee>();
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
