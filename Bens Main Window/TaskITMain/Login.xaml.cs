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
using System.IO;
using System.Data.SqlClient;


namespace TaskITMain
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
      
        public string CurrentUsername;
        public string CurrentPassword;
        public event EventHandler LoginEmployee;
        public event EventHandler LoginManager;
        public event EventHandler Close;
        public Dictionary<string, Employee> LoginStorage = new Dictionary<string, Employee>();


        // Dictionary : String represents EmployeeID + Password, int represents Employee ID

        public Login()
        {
           
            getStorage();
            this.DataContext = this;
            InitializeComponent();
        }

        public void getStorage(string SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
                    

            string queryString =
            "use AppDevLab; SELECT * FROM Employee;";

            Employee[] EmployeeArray = GetEmployees(queryString, SQLPath);

            for (int i = 0; i < EmployeeArray.Length; i++)
            { 
                LoginStorage.Add(""+ EmployeeArray[i].EmployeeName + EmployeeArray[i].Password, EmployeeArray[i] );
            }
        

        }
      


        public static Employee[] GetEmployees(string queryString, String SQLPath)
        {


            using (SqlConnection connection =
                       new SqlConnection(SQLPath))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Employee> ReturnEmployees = new List<Employee>();

                // Call Read before accessing data. 
                while (reader.Read())
                {
                    int EmployeeID = (int)reader[0];
                    String EmployeeName = reader[1].ToString();
                    bool IsManager = false;
                    if (reader[2].ToString().Equals("1"))
                    {
                        IsManager = true;
                    }
                    String EmployeePassword = reader[3].ToString();

                    ReturnEmployees.Add(new Employee(EmployeeID, EmployeeName, IsManager, EmployeePassword));
                }


                reader.Close();
                return ReturnEmployees.ToArray();

            }
        }
        public Employee VerifyUser()
        { 
            
            try
            {
                return LoginStorage[CurrentUsername + CurrentPassword];
            }
            catch(Exception e)
            {
                return null;
            }
            
        }

        
        public static Employee GetEmployee(string FilePath)
        {
            try
            {
                string line;
                
                System.IO.StreamReader file =
                    new System.IO.StreamReader(FilePath);

                line = file.ReadLine();
                // Create Employee from Text File
                string[] splitLine = line.Split('|');
                int employeeID = Convert.ToInt32(splitLine[0]);
                string employeeName = splitLine[1];
                bool employeeIsManager = Convert.ToBoolean(splitLine[2]);
                string employeePassword = splitLine[3];

                Employee e = new Employee(employeeID, employeeName, employeeIsManager, employeePassword);

                file.Close();

                return e;
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
                        this.LoginManager(this, new EventArgs() );
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
