using MahApps.Metro.Controls;
using System.Windows;

namespace HRApp.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : MetroWindow
    {
        public LoginView()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "admin" && PasswordTextBox.Password == "a")
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nieprawidłowy login lub hasło.");
            }
        }
    }
}
