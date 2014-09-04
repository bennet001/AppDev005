using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMain.Enums;

namespace ProjectMain
{
   public class Job
	{
		private int jobID;
		private int commonJobID;
		private string jobName;
		private string description;
		private DateTime timeStarted;
        private DateTime timeFinished;
		private TimeSpan totalTime;
        private DateTime timeDue;
        private bool isCompleted;
		private PriorityLevel pry;



		public int ID
		{
			get { return jobID; }
            set { jobID = value; }
		}

		public int CommonID
		{
			get { return commonJobID; }
            set { commonJobID = value; }
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

		public PriorityLevel Pry
		{
			get { return pry; }
			set { pry = value; }
		}

        public bool IsCompleted
        {
            get { return isCompleted; }
            set { isCompleted = value;}
        }

        public Job(int jobID, int commonID, PriorityLevel priority, string describe, bool isCompleted = false, DateTime timeStart = default(DateTime), DateTime TimeDue = default(DateTime))
		{
            this.ID = jobID;
            this.CommonID = commonID;
            this.JobName = JobName;
            this.Description = describe;
            this.TimeStarted = timeStart;
            this.TimeDue = TimeDue;
            this.Pry = priority;
            this.isCompleted = isCompleted;
		}
        public Job()
        {
        }
	}
  
}