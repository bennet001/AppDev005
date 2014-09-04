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
		private readonly int commonJobID = JobDB.Count;
		private string jobName;
		private string description;
		private DateTime timeStarted = DateTime.Now;
        private DateTime timeFinished;
		private TimeSpan totalTime;
        private DateTime timeDue;
        public bool isCompleted { get; set; }
		private PriorityLevel pry;

		public int ID
		{
			get { return jobID; }
            set { jobID = value; }
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

		public PriorityLevel Pry
		{
			get { return pry; }
			set { pry = value; }
		}

		public Job(string jobname = "SomeDefault", int jobID = 12, 
            int commonID = 3, string describe = " ", 
            PriorityLevel priority = PriorityLevel.Green)
		{
			this.jobID = jobID;
			this.commonJobID = commonID;
			this.jobName = jobname;
			this.description = describe;
			this.pry = priority;
            this.isCompleted = false;
		}
        public Job()
        {
        }
	}
   public class JobDB
   {
       public static ObservableCollection<Job> ourdb;
       public static int Count { get; set; }
       /// <summary>
       /// Will populate a collection upon instantiation
       /// of Employee objects
       /// </summary>
       /// <param name="path"></param>
       /// <returns></returns>
       public static ObservableCollection<Job> PopulateDB(string path)
       {
           string[] dirs = Directory.GetFiles(path);
           ourdb = new ObservableCollection<Job>();
           int standard;
           DateTime newstandards;
           foreach (string dir in dirs)
           {
               string[] newdirs = File.ReadAllLines(dir);
               Console.WriteLine(newdirs[0] + " This is a file Maybe?");
               //FileStream check;
               
               if (int.TryParse(newdirs[0], out standard) && DateTime.TryParse(newdirs[3], out newstandards))
               {
                   ourdb.Add(new Job
                   {
                       ID = int.Parse(newdirs[0]),
                       JobName = newdirs[1],
                       Description = newdirs[2],
                       TimeStarted = DateTime.Parse(newdirs[3]),
                       TimeFinished = DateTime.Now,
                       
                       Pry = ParseEnum(newdirs[4])
                   });
                   Count++;
               }
               
               Console.Write(dir + " ");
           }
           return ourdb;
       }

       private static PriorityLevel ParseEnum(string p)
       {
           return (PriorityLevel)Enum.Parse(typeof(PriorityLevel), p, true);
       }
   }
}