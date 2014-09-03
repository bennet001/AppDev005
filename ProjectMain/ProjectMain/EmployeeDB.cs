using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMain
{
    public class EmployeeDB
    {
        public static ObservableCollection<Employees> ourdb;
        public static int count { get; set; }
        /// <summary>
        /// Will populate a collection upon instantiation
        /// of Employee objects
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ObservableCollection<Employees> PopulateDB(string path)
        {
            string[] dirs = Directory.GetFiles(path);
            ourdb = new ObservableCollection<Employees>();
            foreach (string dir in dirs)
            {
                string[] newdirs = File.ReadAllLines(dir);
                Console.WriteLine(newdirs[0] + " This is a file Maybe?");
                //FileStream check;
                ourdb.Add(new Employees
                {
                    EmployeeID = newdirs[0],
                    EmployeeName = newdirs[1],
                    Password = newdirs[3]
                });
                Console.Write(dir + " ");
                count++;
            }
            return ourdb;
        }  
    }
    public class Employees
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public bool IsSupervisor { get; set; }
        public string Password { get; set; }
        public Employees(string employeeID, string employeeName,
            bool isSupervisor, string password)
        {
            this.EmployeeID = employeeID;
            this.EmployeeName = employeeName;
            this.IsSupervisor = isSupervisor;
            this.Password = password;
        }

        public Employees()
        {
        }
    }
}
