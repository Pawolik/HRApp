using HRApp.Commands;
using HRApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace HRApp.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsData Settings { get; set; }

        public SettingsViewModel()
        {
            Settings = new SettingsData
            {
                ServerAddress = Properties.Settings.Default.ServerAddress,
                ServerName = Properties.Settings.Default.ServerName,
                DatabaseName = Properties.Settings.Default.DataBase,
                Username = Properties.Settings.Default.User,
                Password = Properties.Settings.Default.Password
            };

            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(SaveSettingsAndClose);
        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }



        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }

        private void SaveSettingsAndClose(object parameter)
        {
            if (parameter is Window window)
            {
                Properties.Settings.Default.ServerAddress = Settings.ServerAddress;
                Properties.Settings.Default.ServerName = Settings.ServerName;
                Properties.Settings.Default.DataBase = Settings.DatabaseName;
                Properties.Settings.Default.User = Settings.Username;
                Properties.Settings.Default.Password = Settings.Password;

                Properties.Settings.Default.Save();

                window.Close();
                RestartApplication();
            }
        }

        private void RestartApplication()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
