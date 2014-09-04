using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMain.Models;
using ProjectMain.SaveToDB;
using ProjectMain.UC;

namespace ProjectMain
{
    public class MainController
    {
        public  List<Job> localJobCollection;
        public  List<Employee> localEmployeeCollection;
        public  MainWindow mainWindow;
        public  InAndOut io;

        public string SQLPath;

        public static void Main(String[] args)
        {
            MainController c = new MainController();
           
            c.io = new InAndOut();


            c.mainWindow = new MainWindow();

            c.localEmployeeCollection = c.io.GetEmployees(c.SQLPath, "use AppDevLab; Select * from Employee;");

            c.StartLogin();
            c.StartTest();


        }


        public void StartLogin()
        {
            mainWindow.CurrentView.Children.RemoveRange(0, mainWindow.CurrentView.Children.Count);
            mainWindow.CurrentView.Children.Add(new LogIn(localEmployeeCollection));
        }

        public void StartTest()
        { 
        
        }
    }
}
