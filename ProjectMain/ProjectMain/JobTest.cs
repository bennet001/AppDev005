using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMain
{
    public class JobTest
    {
        public int JobID { get; private set; }

        public string JobName { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        
        //These will be current time no format added. Leave alone
        public static DateTime TimeStarted { get; set; }

        public static DateTime TimeFinished { get; set; }

        //These will be month and day format to fit the mold
        public DateTime DateAssigned { get; set; }

        public DateTime DateDue { get; set; }

        public DateTime DateCompleted { get; set; }

        public bool IsCompleted { get; set; }

        public string EmployeeName { get; set; }
        
        public string SupereeName { get; set; }
       
        public JobTest(DateTime started, string jobname = "Power", string describe = "Restore Functionality to turbine", int jobID = 25, string employee = "David") 
        {
            JobID = jobID;
            JobName = jobname;
            Description = describe;
            TimeStarted = started;
            EmployeeName = employee;
            IsCompleted = false;
        }
    }
}
