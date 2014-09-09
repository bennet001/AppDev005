using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMain.Models;
using System.Data.SqlClient;
using ProjectMain.Enums;


namespace ProjectMain.SaveToDB
{
	public class InAndOut
	{
		// this SQLPath string is too Ben's Local DataBase
        public List<Job> JobsByDueDate(DateTime DueDate, string SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
            string DueDateParsed = "'" + DueDate.Year + "-" + DueDate.Month + "-" + DueDate.Day + "'";

            string queryString = "use AppDevLab; SELECT * FROM Job j WHERE DATEDIFF(day, j.TimeDue, " + DueDateParsed + ") = 0;";


            return GetJobs(queryString, SQLPath);

        }



        public Job GetJobByID(int ID, string SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {

            string queryString = "use AppDevLab; SELECT * FROM Job j WHERE j.JobID = " + ID + ";";


            return GetJobs(queryString, SQLPath)[0];



        }

        public List<Job> GetJobs(string queryString, string SQLPath)
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
                        string JobName = reader[2].ToString();

                        PriorityLevel JobPriority;

                        string PriorityParse = reader[3].ToString();
                        if (PriorityParse.Equals("Green"))
                        {
                            JobPriority = PriorityLevel.Green;
                        }
                        else if (PriorityParse.Equals("Yellow"))
                        {
                            JobPriority = PriorityLevel.Yellow;
                        }
                        else
                        {
                            JobPriority = PriorityLevel.Red;
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

                        ReturnJob = new Job(JobID, JobCommonID, JobPriority, Description, IsCompleted, TimeStarted, TimeDue);
                        ReturnJob.TimeFinished = TimeFinished;
                        ReturnJobs.Add(ReturnJob);
                    }
                    reader.Close();

                    return ReturnJobs;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
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
            string sql;
            // SQL Command Here
            if(J.TimeFinished == null)
            {
                sql = "use AppDevLab; Insert into Job Values(" + J.ID + ", " + J.CommonID + ", '" + J.JobName + "', '" + J.Pry + "', '" + J.TimeStarted + "', NULL, '" + J.TimeDue + "', '" + J.Description + "', " + IsCompleted + ");";


                sql = "use AppDevLab; IF EXISTS (SELECT * FROM Job WHERE JobID=" + J.ID + ") UPDATE Job SET JobID=" + J.ID + ", CommonJobID=" + J.CommonID + ", JobName='" + J.JobName + "', JobPriority='" + J.Pry +
                "', TimeStarted='" + J.TimeStarted + "', TimeFinished=NULL, TimeDue='" +J.TimeDue +"', Description='"+J.Description+"', Is_Completed="+Convert.ToInt32(J.IsCompleted)+" WHERE JobID='"+ J.ID +"' ELSE INSERT INTO Job VALUES ("
                + J.ID + ", " + J.CommonID + ", '" + J.JobName + "', '" + J.Pry + "', '" + J.TimeStarted + "', NULL, '" + J.TimeDue + "', '" + J.Description + "', " + IsCompleted + ");";
            }
            else
            {
                sql = "use AppDevLab; Insert into Job Values(" + J.ID + ", " + J.CommonID + ", '" + J.JobName + "', '" + J.Pry + "', '" + J.TimeStarted + "', '" + J.TimeFinished + "', '" + J.TimeDue + "', '" + J.Description + "', " + IsCompleted + ");";

                sql = "use AppDevLab; IF EXISTS (SELECT * FROM Job WHERE JobID=" + J.ID + ") UPDATE Job SET JobID=" + J.ID + ", CommonJobID=" + J.CommonID + ", JobName='" + J.JobName + "', JobPriority='" + J.Pry +
                 "', TimeStarted='" + J.TimeStarted + "', TimeFinished='"+J.TimeFinished+"', TimeDue='" + J.TimeDue + "', Description='" + J.Description + "', Is_Completed=" + Convert.ToInt32(J.IsCompleted) + " WHERE JobID='" + J.ID + "' ELSE INSERT INTO Job VALUES ("
                 + J.ID + ", " + J.CommonID + ", '" + J.JobName + "', '" + J.Pry + "', '" + J.TimeStarted + "', NULL, '" + J.TimeDue + "', '" + J.Description + "', " + IsCompleted + ");";
       
            
            }

            cnn.Open();

            cmd = new SqlCommand(sql, cnn);
            // ExecuteNonQuery does Data Definition, inserting and updating data
            cmd.ExecuteNonQuery();
            cmd.Dispose();


            cnn.Close();

        }

		public List<Employee> GetEmployeesThatHaveJobID(int JobID, string SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
		{
			string queryString =
			"use AppDevLab; SELECT e.EmployeeID, e.EmployeeName, e.IsManager , e.EmployeePassword FROM Employee e, Job j, EmployeeJob ej WHERE ej.EmployeeID = e.EmployeeID AND ej.JobId = j.JobID AND j.JobID =" + JobID + " ;";
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
		public List<Employee> GetEmployees(string queryString, String SQLPath)
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
				return ReturnEmployees;
			}
		}
	
        public void AddEmployeesToJob(Job job, Employee[] employees, string SQLPath = "Data Source=IT-OJCFCBE76QAN;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        {
            SqlConnection cnn;
            string connectionString = SQLPath;
            cnn = new SqlConnection(connectionString);
            SqlCommand cmd = null;
            // SQL Command Here
            
            cnn.Open();
            for (int i = 0; i < employees.Length; i++)
            {
                string sql = "use AppDevLab; Insert into EmployeeJob Values(" + employees[i].EmployeeID + ", " + job.ID + ");";

                cmd = new SqlCommand(sql, cnn);
                // ExecuteNonQuery does Data Definition, inserting and updating data
                cmd.ExecuteNonQuery();
            }
       
            cmd.Dispose();
            cnn.Close();
        }
    }
}

