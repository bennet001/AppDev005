

// The namespace will be changed as we combine our code.
namespace EmployeeControlApp.Models
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
	}
}
