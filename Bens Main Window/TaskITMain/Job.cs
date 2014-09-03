using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskITMain
{
    public class Job
    {
        public enum priority
        {
            Green,
            Yellow,
            Red
        };

      


        public int JobID { get; set; }
        public int CommonJobID { get; set; }
        public string JobName { get; set; }
        public priority Priority { get; set; }
        public DateTime TimeStarted { get; set; }
        public DateTime TimeFinished { get; set; }
        public DateTime TimeDue { get; set; }
        public string Description { get; set; }   
        public bool IsCompleted { get; set; }


        public Job(int jobID, int commonID, string jobname, priority priority, DateTime timeStart = default(DateTime), DateTime dueDate, string describe = " ", bool jobComplete = false)
        {
            this.JobID = jobID;
            this.CommonJobID = commonID;
            JobName = jobname;
            Priority = priority;
            TimeStarted = timeStart;
            TimeDue = dueDate;
            Description = describe;
            IsCompleted = jobComplete;
        }

        public string ToString()
        {
            return "ID: " + JobID;
        }
    }
}
