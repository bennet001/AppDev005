using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class JobTest
    {
        private readonly int JobID;
        public int ID
        {
            get { return JobID; }
        }

        private string JobName;
        public string jobName
        {
            get { return JobName; }
            set
            {
                JobName = value;
            }
        }

        private string Description;
        public string description
        {
            get { return Description; }
            set
            {
                Description = value;
            }
        }
        
        //These will be current time no format added. Leave alone
        private static DateTime TimeStarted;
        public DateTime timeStarted
        {
            get { return TimeStarted; }
            set
            {
                TimeStarted = value;
            }
        }

        private static DateTime TimeFinished;
        public DateTime timeFinished
        {
            get { return TimeFinished; }
            set
            {
                TimeFinished = value;
            }
        }

        //These will be month and day format to fit the mold
        private static DateTime DateAssigned;
        public DateTime dateassigned { get { return DateAssigned; } set { DateAssigned = value; } }

        private static DateTime DateDue;
        public DateTime datedue { get { return DateDue; } set { DateDue = value; } }

        private static DateTime DateCompleted;
        public DateTime datecompleted { get { return DateCompleted; } set { DateCompleted = value; } }

        private bool IsCompleted;
        public bool iscompleted { get { return IsCompleted; } set { IsCompleted = value; } }

        private string _employeename;
        public string EmployeeName { get { return _employeename; } set { _employeename = value; } }
        
        private string _supereename = "Maxwell";
        public string SupereeName { get { return _supereename; } set { _supereename = value; } }
       
        public JobTest(DateTime started, string jobname = "Power", string describe = "Restore Functionality to turbine", int jobID = 25, string employee = "David") 
        {
            JobID = jobID;
            jobName = jobname;
            description = describe;            
            timeStarted = started;
            EmployeeName = employee;
            iscompleted = false;
        }
    }
}
