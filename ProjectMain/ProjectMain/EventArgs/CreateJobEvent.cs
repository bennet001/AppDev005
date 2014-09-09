using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMain.Models;

namespace ProjectMain.EventHandlers
{

    public class CreateJobEvent
    {
        public CreateJobEvent(Job job, Employee[] AssignedEmployees)
        {
            this.job = job;
            this.AssignedEmployees = AssignedEmployees;
        }
        public Job job
        { get; set; }
        public Employee[] AssignedEmployees
        { get; set; }

    }
}
