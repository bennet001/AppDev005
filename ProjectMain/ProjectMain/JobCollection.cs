using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMain
{
    class JobCollection
    {
        ObservableCollection<JobTest> jobs = new ObservableCollection<JobTest>();
        public void ButtonClick_Handler(JobTest addition)
        {
            _joblist.Add(addition);
        }

        private ObservableCollection<JobTest> _joblist = new ObservableCollection<JobTest>();
        public ObservableCollection<JobTest> JobList { get { return _joblist; } set { _joblist = value; } }
    }
}
