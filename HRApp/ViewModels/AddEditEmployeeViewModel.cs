using HRApp.Commands;
using HRApp.Models;
using HRApp.Models.Domains;
using HRApp.Models.Wrappers;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Position = HRApp.Models.Domains.Position;

namespace HRApp.ViewModels
{
    public class AddEditEmployeeViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();
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
            InitPositions();
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

        private ObservableCollection<Department> _department;
        public ObservableCollection<Department> Departments
        {
            get { return _department; }
            set
            {
                _department = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Position> _position;
        public ObservableCollection<Position> Positions
        {
            get { return _position; }
            set
            {
                _position = value;
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
            _repository.UpdateEmployee(Employee);
        }

        private void AddEmployee()
        {
            _repository.AddEmployee(Employee);
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
            var departments = _repository.GetDepartments();
            departments.Insert(0, new Department { ID = 0, Name = "-- brak --" });


            Departments = new ObservableCollection<Department>(departments);

            Employee.Department.ID = 0;
        }

        private void InitPositions()
        {
            var positions = _repository.GetPositions();
            //positions.Insert(0, new Position { ID = 0, Title = "-- brak --" });


            Positions = new ObservableCollection<Position>(positions);

        }
    }
}
