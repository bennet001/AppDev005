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
using ProjectMain.EventHandlers;
using ProjectMain.Models;
using ProjectMain.SaveToDB;
using ProjectMain.UC;


namespace ProjectMain
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Job> localJobCollection;
        public List<Employee> localEmployeeCollection;
        public InAndOut io;

        public string SQLPath;


        public MainWindow()
        {
            InitializeComponent();

            SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            io = new InAndOut();

            localEmployeeCollection = io.GetEmployees("use AppDevLab; Select * from Employee;", SQLPath);
            localJobCollection = io.GetJobs("use AppDevLab; Select * from Job;", SQLPath);
            StartLogin();


        }
      
        public void StartLogin()
        {
            LogIn currentLogin = new LogIn(localEmployeeCollection);
            currentLogin.LoginEmployee += LoginEmployee;
            currentLogin.LoginManager += LoginManager;
            CurrentView.Children.RemoveRange(0, CurrentView.Children.Count);
            CurrentView.Children.Add(currentLogin);
        }

        public void LoginEmployee(Object o, EventArgs e)
        {
            CurrentView.Children.RemoveRange(0, CurrentView.Children.Count);

            CurrentView.Children.Add(new JobUC(io.GetJobByID(2, SQLPath)));
        }


        public void LoginManager(Object o, EventArgs e)
        {
            
            SupervisorUI maker = new SupervisorUI(localJobCollection, localEmployeeCollection);
            maker.CreateJobEventHandler += CreateNewJob;
            CurrentView.Children.RemoveRange(0, CurrentView.Children.Count);
            CurrentView.Children.Add(maker);
        }

        public void CreateNewJob(Object o, CreateJobEvent e)
        {
            io.SaveJob(e.job, SQLPath);
            io.AddEmployeesToJob(e.job, e.AssignedEmployees, SQLPath);
            localJobCollection = io.GetJobs("use AppDevLab; Select * from Job;", SQLPath);
        }

    }
}
