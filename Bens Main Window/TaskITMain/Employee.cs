using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskITMain
{
    public class Employee
    {
        public int EmployeeID { get; private set; }
        public string EmployeeName { get; set; }
        public bool IsSupervisor { get; set; }
        public string Password { get; set; }

        public Employee(int employeeID, string employeeName, bool isSupervisor, string password)
        {
            this.EmployeeID = employeeID;
            this.EmployeeName = employeeName;
            this.IsSupervisor = isSupervisor;
            this.Password = password;
        }
        public string ToString()
        {
            return "ID: " + EmployeeID;
        }
    }
}
