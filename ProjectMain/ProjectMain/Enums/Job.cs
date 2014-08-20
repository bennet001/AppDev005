using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMain
{
    class Job
    {
        private readonly int JobID;
        private readonly int CommonJobID;
        private string JobName;
        private string Description;
        private DateTime TimeStarted;
        private DateTime TimeFinished;
        private DateTime TimeDue;
        private bool IsCompleted;

        public int ID
        {
            get { return JobID; }
        }

        public int commonID
        {
            get { return CommonJobID; }
        }

        public string jobName
        {
            get { return JobName; }
            set { JobName = value; }
        }

        public string description
        {
            get { return Description; }
            set { Description = value; }
        }

        public DateTime timeStarted
        {
            get { return timeStarted; }
            set { TimeStarted = value; }
        }

        public DateTime timeFinished
        {
            get { return timeFinished; }
            set { TimeFinished = value; }
        }

        public DateTime timeDue
        {
            get { return TimeDue; }
            set { TimeDue = value; }
        }

        public Job(string jobname, string describe, int jobID, int commonID, DateTime timeStart, DateTime dueDate)
        {
            JobID = jobID;
            CommonJobID = commonID;
            jobName = jobname;
            description = describe;
            this.timeStarted = timeStart;
            timeDue = dueDate;
        }
    }
}
