using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskIT.Models
{
    class MockJob
    {
        public int JobID { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string POC { get; set; }
        public int Priority { get; set; }
        public DateTime TimeStarted { get; set; }
        public DateTime TimeFinished { get; set; }
        public bool IsCompleted { get; set; }

        public MockJob(int jobId, string description, DateTime dateSubmitted, string poc, int priority, bool isCompleted)
        {
            JobID = jobId;
            Description = description;
            DateSubmitted = dateSubmitted;
            POC = poc;
            Priority = priority;
            IsCompleted = isCompleted;
        }
    }
}
