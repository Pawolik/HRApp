using HRApp.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void EmployeeFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeFilterComboBox == null || DataContext == null)
            {
                return;
            }

            var vm = (MainViewModel)DataContext;
            vm.FilterEmployees(EmployeeFilterComboBox.SelectedIndex);
        }

    }
}
