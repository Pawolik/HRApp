using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Models.Wrappers
{
    public class EmployeeWrapper : IDataErrorInfo
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

        private bool _isFirstNameValid;
        private bool _isLastNameValid;
        private bool _isHireDateValid;
        public bool IsEmployed
        {
            get
            {
                return TerminationDate == null;
            }
        }
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(FirstName):
                        if (string.IsNullOrWhiteSpace(FirstName))
                        {
                            Error = "Pole wymagane!";
                            _isFirstNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isFirstNameValid = true;
                        }
                        break;
                    case nameof(LastName):
                        if (string.IsNullOrWhiteSpace(LastName))
                        {
                            Error = "Pole wymagane!";
                            _isLastNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;

                            _isLastNameValid = true;
                        }
                        break;
                    case nameof(HireDate):
                        if (HireDate < new DateTime(1753, 1, 1) || HireDate > new DateTime(9999, 12, 31))
                        {
                            Error = "Błędna data!";
                            _isHireDateValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isHireDateValid = true;
                        }
                        break;
                    default:
                        break;
                }
                return Error;
            }
        }

        public string Error { get; set; }

        public bool IsValid 
        {
            get
            {
                return _isLastNameValid && _isFirstNameValid && Department.IsValid && Job.IsValid && _isHireDateValid;
            }
        }
    }
}
