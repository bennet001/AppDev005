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
using ProjectMain.Models;

namespace ProjectMain.UC
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : UserControl
    {
       
        public string CurrentUsername;
        public string CurrentPassword;
        public event EventHandler LoginEmployee;
        public event EventHandler LoginManager;
        public event EventHandler Close;
        public Dictionary<string, Employee> LoginStorage = new Dictionary<string, Employee>();



        public LogIn(List<Employee> Employees)
        {
           
            for (int i = 0; i < Employees.Count; i++)
            {
                LoginStorage.Add("" + Employees[i].EmployeeName + Employees[i].Password, Employees[i]);
            }
           
            this.DataContext = this;
            InitializeComponent();
        }

        public Employee VerifyUser()
        {

            try
            {
                return LoginStorage[CurrentUsername + CurrentPassword];
            }
            catch (Exception e)
            {
                return null;
            }

        }



        private void loginButton_Click_1(object sender, RoutedEventArgs e)
        {
            CurrentPassword = passwordTextBox.Text;
            CurrentUsername = usernameTextBox.Text;
            Employee User = VerifyUser();
            if (User != null)
            {
                if (User.IsSupervisor)
                {
                    if (this.LoginManager != null)
                    {
                        this.LoginManager(this, new EventArgs());
                    }
                }
                else
                {
                    if (this.LoginEmployee != null)
                    {
                        this.LoginEmployee(this, new EventArgs());
                    }
                }
            }
            else
            {
                MessageBox.Show("Your Username/Password combination does not exist, please try again.");

            }
        }

        private void exitButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.Close != null)
            {
                this.Close(this, new EventArgs());
            }
        }
    }
}
