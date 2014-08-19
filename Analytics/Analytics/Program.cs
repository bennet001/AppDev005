using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DateTime> times = new List<DateTime>();
            DateTime time = DateTime.Now;
            times.Add(time);
            DateTime time1 = DateTime.Now;
            time1 = time1.AddMinutes(30);
            times.Add(time1);
            Analytics analize = new Analytics();
            Console.WriteLine(analize.AverageTime(times));
            Console.WriteLine(analize.MaxTime(times));
            Console.WriteLine(analize.MinTime(times));
            Console.ReadLine();
        }
    }
}