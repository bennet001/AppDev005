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
        ObservableCollection<Job> jobs = new ObservableCollection<Job>();
        public void ButtonClick_Handler(Job addition)
        {
            _joblist.Add(addition);
        }

        private ObservableCollection<Job> _joblist = new ObservableCollection<Job>();
        public ObservableCollection<Job> JobList { get { return _joblist; } set { _joblist = value; } }
    }
}
