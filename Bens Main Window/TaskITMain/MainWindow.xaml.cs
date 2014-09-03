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
using System.Data.SqlClient;


namespace TaskITMain
{
    public delegate void EventHandler(object sender, EventArgs e);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            /**
             * Allow the User to choose where the file is !! NOT AT START, ONLY MANAGER !!
             * 
             * 
             */
            // The Parameters for LoginControl are the location of your employee data
            Login LoginControl = new Login();
            LoginControl.LoginManager += new EventHandler(LoginManager);
            LoginControl.LoginEmployee += new EventHandler(LoginEmployee);
            LoginControl.Close += new EventHandler(CloseWindow);

            this.DataContext = this;

            InitializeComponent();

            ShowDemo();

            CurrentView.Children.Add(LoginControl);



          
        }

        /*
         * These are my Event Listeners that are listening to the Login Control for Button Clicks
         */


        public void ShowDemo()
        {
            string SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
           
            string EmployeeQueryString =
            "use AppDevLab; SELECT * FROM Employee;";
             
            string JobQueryString =
            "use AppDevLab; SELECT * FROM Job;";
          
    
            Employee[] EmployeeArray = GetEmployees(EmployeeQueryString, SQLPath);

            Console.WriteLine("Here are all the Employees in the Database");

            for (int i = 0; i < EmployeeArray.Length; i++)
            {
                Console.WriteLine("Employee ID: " + EmployeeArray[i].EmployeeID);
                Console.WriteLine("Employee Name: " + EmployeeArray[i].EmployeeName);
                Console.WriteLine("Employee Password: " + EmployeeArray[i].Password);
                Console.WriteLine("");
            }

            Job[] JobArray = GetJobs(JobQueryString, SQLPath);
            Console.WriteLine("Here are all the Jobs in the Database");

            for (int i = 0; i < JobArray.Length; i++)
            {
                Console.WriteLine("Job ID: " + JobArray[i].JobID);
                Console.WriteLine("Job Common ID: " + JobArray[i].CommonJobID);
                Console.WriteLine("Job Name: " + JobArray[i].JobName);
                Console.WriteLine("Job Priority: " + JobArray[i].Priority);
                Console.WriteLine("Job Start Date: " + JobArray[i].TimeStarted);
                Console.WriteLine("Job Due Date: " + JobArray[i].TimeDue);

                if (JobArray[i].IsCompleted)
                {
                    Console.WriteLine("Job Finish Date: " + JobArray[i].TimeFinished);
                }
                else
                {
                    Console.WriteLine("Job not Completed");
                }



                Console.WriteLine("Job Description: " + JobArray[i].Description);
                Console.WriteLine("");
        
            }

            Job[] JobsDueToday = JobsByDueDate(new  DateTime(2014, 9, 2));
            Console.WriteLine("Here are all the Jobs due September 2nd 2014 in the Database");

            for (int i = 0; i < JobsDueToday.Length; i++)
            {
                Console.WriteLine("Job ID: " + JobsDueToday[i].JobID);
                Console.WriteLine("Job Common ID: " + JobsDueToday[i].CommonJobID);
                Console.WriteLine("Job Name: " + JobsDueToday[i].JobName);
                Console.WriteLine("Job Priority: " + JobsDueToday[i].Priority);
                Console.WriteLine("Job Start Date: " + JobsDueToday[i].TimeStarted);
                Console.WriteLine("Job Due Date: " + JobsDueToday[i].TimeDue);

                if (JobArray[i].IsCompleted)
                {
                    Console.WriteLine("Job Finish Date: " + JobsDueToday[i].TimeFinished);
                }
                else
                {
                    Console.WriteLine("Job not Completed");
                }



                Console.WriteLine("Job Description: " + JobsDueToday[i].Description);
                Console.WriteLine("");

            }

            Console.WriteLine("Here are all the Employees that are assigned to work on Job 1");

            Employee[] EmployeeArrayByJob = GetEmployeesThatHaveJobID(1, SQLPath);

            for (int i = 0; i < EmployeeArrayByJob.Length; i++)
            {
                Console.WriteLine("Employee ID: " + EmployeeArrayByJob[i].EmployeeID);
                Console.WriteLine("Employee Name: " + EmployeeArrayByJob[i].EmployeeName);
                Console.WriteLine("Employee Password: " + EmployeeArrayByJob[i].Password);
                Console.WriteLine("");
            }

        }

        public void LoginManager(object sender, EventArgs e)
        {
            
            CurrentView.Children.RemoveAt(0);
            // Add the Manager GUI
            ManagerControl control = new ManagerControl();
            this.Height = control.Height;
            this.Width = control.Width;
            
            CurrentView.Children.Add(control);
            MessageBox.Show("You have logged in as a Manager");
        }

        public void LoginEmployee(object sender, EventArgs e)
        {
            CurrentView.Children.RemoveAt(0);
            // Add the Employee GUI
            JobControl control = new JobControl();
            this.Height = control.Height;
            this.Width = control.Width;
            CurrentView.Children.Add(control);
            MessageBox.Show("You have logged in as an Employee");
        }

        public void CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }



        /**
         * Attempted to connect with Data Source=IT-OJCFCBE76QAN;Initial Catalog=AppLabDev;User ID=Ben;Password=password 
         * This was not right. Mr warner is smart. The end
         * 
         * Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False
         */

        public Job[] JobsByDueDate(DateTime DueDate, string SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
            string DueDateParsed = "'" + DueDate.Year + "-" + DueDate.Month + "-" + DueDate.Day+"'";

            string queryString = "use AppDevLab; SELECT * FROM Job j WHERE DATEDIFF(day, j.TimeDue, " + DueDateParsed + ") = 0;";


            return GetJobs(queryString, SQLPath);

        }



        public Job GetJobByID(int ID, string SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
       
           string queryString = "use AppDevLab; SELECT * FROM Job j WHERE j.JobID = " + ID + ";";


           return GetJobs(queryString, SQLPath)[0];

      

        }

        public static Job[] GetJobs(string queryString, string SQLPath)
        {


            using (SqlConnection connection =
                       new SqlConnection(SQLPath))
            {


                SqlCommand command =
                    new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<Job> ReturnJobs = new List<Job>();
                    // Call Read before accessing data. 
                    while (reader.Read())
                    {

                        Job ReturnJob;

                        int JobID = (int)reader[0];
                        int JobCommonID = (int)reader[1];
                        String JobName = reader[2].ToString();

                        Job.priority JobPriority;

                        string PriorityParse = reader[3].ToString();
                        if (PriorityParse.Equals("Green"))
                        {
                            JobPriority = Job.priority.Green;
                        }
                        else if (PriorityParse.Equals("Yellow"))
                        {
                            JobPriority = Job.priority.Yellow;
                        }
                        else
                        {
                            JobPriority = Job.priority.Red;
                        }





                        DateTime TimeStarted = (DateTime)reader[4];
                        DateTime TimeFinished;

                        DateTime TimeDue = (DateTime)reader[6];
                        String Description = reader[7].ToString();
                        bool IsCompleted = false;

                        if (reader[8].ToString().Equals("1"))
                        {
                            IsCompleted = true;
                        }


                        if (!reader[5].ToString().Equals(""))
                        {

                            TimeFinished = (DateTime)reader[5];

                        }
                        else
                        {
                            TimeFinished = DateTime.MaxValue;
                        }
                       
                        ReturnJob = new Job(JobID, JobCommonID, JobName, JobPriority, TimeStarted, TimeDue, Description, IsCompleted);
                        ReturnJob.TimeFinished = TimeFinished;
                        ReturnJobs.Add(ReturnJob);
                    }
                    reader.Close();

                    return ReturnJobs.ToArray();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return null;
                }




            }
        }

        public void SaveJob(Job J, string SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
            int IsCompleted = 0;
            if (J.IsCompleted)
            {
                IsCompleted = 1;
            }

            SqlConnection cnn;
            string connectionString = SQLPath;
            cnn = new SqlConnection(connectionString);
            SqlCommand cmd;
            // SQL Command Here
            string sql = "use AppDevLab; Insert into Job Values(" + J.JobID + ", " + J.CommonJobID + ", '" + J.JobName + "', '" + J.Priority + "', '" + J.TimeStarted + "', " + J.TimeDue + "', " + J.Description + "', " + IsCompleted + "');";
            cnn.Open();


            cmd = new SqlCommand(sql, cnn);
            // ExecuteNonQuery does Data Definition, inserting and updating data
            cmd.ExecuteNonQuery();
            cmd.Dispose();


            cnn.Close();

        }



        public Employee[] GetEmployeesThatHaveJobID(int JobID, string SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
            string queryString =
            "use AppDevLab; SELECT e.EmployeeID, e.EmployeeName, e.IsManager , e.EmployeePassword FROM Employee e, Job j, EmployeeJob ej WHERE ej.EmployeeID = e.EmployeeID AND ej.JobId = j.JobID AND j.JobID =" + JobID +" ;";

            return GetEmployees(queryString, SQLPath);

        }

        public Employee GetEmployeeByID(int ID, string SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
            string queryString =
            "use AppDevLab; SELECT * FROM Employee e WHERE e.EmployeeID = " + ID + ";";

            return GetEmployees(queryString, SQLPath)[0];

               
                
        }

        public void SaveEmployee(Employee e, string SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
            int isSupervisor = 0;
            if (e.IsSupervisor)
            {
                isSupervisor = 1;
            }

            SqlConnection cnn;
            string connectionString = SQLPath;
            cnn = new SqlConnection(connectionString);
            SqlCommand cmd;
            // SQL Command Here
            string sql = "use AppDevLab; Insert into Employee Values(" + e.EmployeeID + ", '" + e.EmployeeName + "', " + isSupervisor + ", '" + e.Password + "');";
            cnn.Open();


            cmd = new SqlCommand(sql, cnn);
            // ExecuteNonQuery does Data Definition, inserting and updating data
            cmd.ExecuteNonQuery();
            cmd.Dispose();


            cnn.Close();

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



    }
}
