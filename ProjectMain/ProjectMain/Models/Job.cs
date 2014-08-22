using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMain.Enum

namespace ProjectMain
{
    public class Job
    {
        private readonly int jobID;
        private readonly int commonJobID;
        private string jobName;
        private string description;
        private DateTime timeStarted;
        private DateTime timeFinished;
        private TimeSpan totalTime;
        private DateTime timeDue;
        private bool isCompleted;

        public int ID
        {
            get { return jobID; }
        }

        public int CommonID
        {
            get { return commonJobID; }
        }

        public string JobName
        {
            get { return jobName; }
            set { jobName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime TimeStarted
        {
            get { return timeStarted; }
            set { timeStarted = value; }
        }

        public DateTime TimeFinished
        {
            get { return timeFinished; }
            set { timeFinished = value; }
        }

        public DateTime TimeDue
        {
            get { return timeDue; }
            set { timeDue = value; }
        }

        public TimeSpan TotalTime
        {
            get { return totalTime; }
            set { totalTime = TimeFinished - TimeStarted; }
        }

        public bool IsComplete
        {
            get { return isComplete; }
            set { isComplete = value; }
        }

        public Job(string jobname, int jobID, int commonID, DateTime timeStart, DateTime dueDate, string describe = " ", Priority.Priority priority = Priority.Green)
        {
            this.jobID = jobID;
            this.commonJobID = commonID;
            jobName = jobname;
            description = describe;
            TimeStarted = timeStart;
            TimeDue = dueDate;
            Priority.Priority pry = priority;
        }
    }
}