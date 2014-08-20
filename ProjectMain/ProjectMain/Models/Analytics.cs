using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMain
{
    class Analytics
    {

        public Analytics()
        {
            //Grab files 
            //Console.WriteLine("Enter desired operation");
            //Console.WriteLine("0) AverageTime for one task");
            //Console.WriteLine("1) Find minimun time for a task to be done");
            //Console.WriteLine("9) quit");

        }

        public List<DateTime> getByCommonId()
        {
            List<DateTime> time = new List<DateTime>();
            //grab CommonID from file system

            return time;
        }

        public TimeSpan AverageTime(List<DateTime> times) // redo
        {
            TimeSpan finalTime = TimeSpan.Zero;
            for (int i = 0; i < times.Count; i++)
            {
                TimeSpan time1 = times[i].TimeOfDay;
                i++;
                TimeSpan time2 = times[i].TimeOfDay;
                TimeSpan time3 = time1 + time2;
                TimeSpan dividedTime = new TimeSpan(time3.Ticks / 2);
                finalTime += dividedTime;
            }
            return finalTime;
        }

        public DateTime MinTime(List<DateTime> times)
        {
            DateTime minTime = times.Min<DateTime>();
            return minTime;
        }

        public DateTime MaxTime(List<DateTime> times)
        {
            DateTime maxTime = times.Max<DateTime>();
            return maxTime;
        }

        public TimeSpan EmployeeTaskAverage(int EmployeeID)
        {
            List<DateTime> time = new List<DateTime>();
            /**Grab all jobs with employee id
            if(job has righ employee id)
             * time.add(job);
             * */
            TimeSpan finalTime = AverageTime(time);
            
            return finalTime;
        }

        public DateTime EmployeeTaskMin(int EmployeeID)
        {
            List<DateTime> time = new List<DateTime>();
            /**Grab all jobs with employee id
            if(job has righ employee id)
             * time.add(job);
             * */
            DateTime MinTaskTime = MinTime(time);

            return MinTaskTime;
        }

        public DateTime EmployeeTaskMax(int EmployeeID)
        {
            List<DateTime> time = new List<DateTime>();
            /**Grab all jobs with employee id
            if(job has righ employee id)
             * time.add(job);
             * */
            DateTime MaxTaskTime = MaxTime(time);

            return MaxTaskTime;
        }

        public int NumOfJobs(int EmployeeId)
        {
            int JobCount = 0;
            /**Grab all jobs with for loop
            if(job has righ employee id)
                JobCount++;
             **/
            return JobCount;
        }

        public int OverDueJobs(List<JobTest> JobList)
        {
            int OverDue = 0;
            /**Grab all jobs with for loop
            if(job is overdue)
                OverDue++;
             **/
            return OverDue;
        }

        public int OverDueForOneEmployee(int EmployeeID)
        {
            List<JobTest> jobs = new List<JobTest>(); 
            /**Grab all jobs with for loop
            if(job has righ employee id)
                jobs.Add(job)
             **/
            int overdue = OverDueJobs(jobs);

            return overdue;
        }

        public int TotalJobs(List<JobTest> JobList)
        {
            int totalJobs = JobList.Count;
            return totalJobs;
        }
    }
}
