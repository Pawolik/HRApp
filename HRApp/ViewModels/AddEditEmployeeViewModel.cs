using HRApp.Commands;
using HRApp.Models;
using HRApp.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace HRApp.ViewModels
{
    public class AddEditEmployeeViewModel : ViewModelBase
    {
        public AddEditEmployeeViewModel(EmployeeWrapper employee = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            if (employee == null)
            {
                Employee = new EmployeeWrapper();
            }
            else
            {
                Employee = employee;
                IsUpdate = true;
            }

            InitDepartments();
        }


        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        private EmployeeWrapper _employee;

        public EmployeeWrapper Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }
        private bool _isUpdate;

        public bool IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }

        private EmployeeWrapper _selectedEmployee;
        public EmployeeWrapper SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        private int _selectedDepartmentId;

        public int SelectedDepartmentId
        {
            get { return _selectedDepartmentId; }
            set
            {
                _selectedDepartmentId = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<DepartmentWrapper> _department;
        public ObservableCollection<DepartmentWrapper> Departments
        {
            get { return _department; }
            set
            {
                _department = value;
                OnPropertyChanged();
            }
        }

        private void Confirm(object obj)
        {
            if (!IsUpdate)
            {
                AddEmployee();
            }
            else
            {
                UpdateEmployee();
            }
            //logika
            CloseWindow(obj as Window);
        }

        private void UpdateEmployee()
        {
            //baza danych
        }

        private void AddEmployee()
        {
            //baza danych
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
        private void InitDepartments()
        {
            Departments = new ObservableCollection<DepartmentWrapper>
            {
                new DepartmentWrapper {ID = 0, Name = "-- brak --"},

                new DepartmentWrapper {ID = 1, Name = "IT"},
                new DepartmentWrapper {ID = 2, Name = "Finanse"}
            };
            Employee.Department.ID = 0;
        }
    }
}
