using HRApp.Commands;
using HRApp.Models;
using HRApp.Models.Wrappers;
using HRApp.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HRApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                var employees = context.Employees.ToList();
            }


            AddEmployeeCommand = new RelayCommand(AddEditEmployee);
            EditEmployeeComand = new RelayCommand(AddEditEmployee, CanEditDeleteEmployee);
            DeleteEmployeeCommand = new AsyncRelayCommand(DeleteEmployee, CanEditDeleteEmployee);
            RefreshEmployeeCommand = new RelayCommand(RefreshEmployee);
            SettingsEmployeeCommand = new RelayCommand(SettingsEmployee);

            RefreshHRProgram();
            InitDepartments();
        }

        

        public ICommand AddEmployeeCommand { get; set; }
        public ICommand EditEmployeeComand { get; set; }
        public ICommand DeleteEmployeeCommand { get; set; }
        public ICommand RefreshEmployeeCommand { get; set; }
        public ICommand SettingsEmployeeCommand { get; set; }

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

        /*private decimal _salary;
        public string Salary
        {
            get { return _salary.ToString(); }
            set
            {
                if (decimal.TryParse(value, out decimal newSalary))
                {
                    _salary = newSalary;
                    OnPropertyChanged("Salary"); // zakładając, że masz zaimplementowane INotifyPropertyChanged
                }
                else
                {
                    // logika obsługi błędów, np. ustawienie wartości na 0 lub wyświetlenie komunikatu
                }
            }
        }*/


        private ObservableCollection<EmployeeWrapper> _employee;
        public ObservableCollection<EmployeeWrapper> Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
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

        private ObservableCollection<PositionWrapper> _position;
        public ObservableCollection<PositionWrapper> Positions
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }



        private void AddEditEmployee(object obj)
        {
            var addEditEmployeeWindow = new AddEditEmployeeView(obj as EmployeeWrapper);
            addEditEmployeeWindow.Closed += addEditEmployeeWindow_Closed;
            addEditEmployeeWindow.ShowDialog();
        }

        private void addEditEmployeeWindow_Closed(object sender, EventArgs e)
        {
            RefreshHRProgram();
        }

        private async Task DeleteEmployee(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync("Zwalnianie pracownika", 
                $"Czy na pewno chcesz zwolnić pracownika {SelectedEmployee.FirstName} {SelectedEmployee.LastName}?", 
                MessageDialogStyle.AffirmativeAndNegative);

            if (dialog != MessageDialogResult.Affirmative)
            {
                return;
            }

            //Zwalnianie pracownika

            RefreshHRProgram();
        }
        private bool CanEditDeleteEmployee(object obj)
        {
            return SelectedEmployee != null;
        }
        private void RefreshEmployee(object obj)
        {
            RefreshHRProgram();
        }
        private void SettingsEmployee(object obj)
        {

        }
        private void RefreshHRProgram()
        {
            Employee = new ObservableCollection<EmployeeWrapper>
            {
                new EmployeeWrapper
                {
                    FirstName = "Paweł",
                    LastName ="Jacewicz",
                    Email ="Test@Test",
                    Salary = 4500,
                    Department = new DepartmentWrapper
                    {
                        ID = 1,
                        Name = "It"
                    },
                    Position = new PositionWrapper
                    {
                        ID=1,
                        Title = "Junior"
                    }
                }
            };
        }

        private void InitDepartments()
        {
            Departments = new ObservableCollection<DepartmentWrapper>
            {
                new DepartmentWrapper {ID = 0, Name = "Wszystkie"},

                new DepartmentWrapper {ID = 1, Name = "IT"},
                new DepartmentWrapper {ID = 2, Name = "Finanse"}
            };
            SelectedDepartmentId = 0;
        }
    }
}
