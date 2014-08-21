using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectMain.UC
{
    /// <summary>
    /// Interaction logic for JobUC.xaml
    /// </summary>
    public partial class JobUC : UserControl
    {
        int _jobid = 0;
        public int JobId { get { return _jobid; } set { _jobid = value; } }

        string _jobTitle;
        public string JobTitle { get { return _jobTitle; } set { _jobTitle = value; } }

        string _jobdescription;
        public string JobDescription { get { return _jobdescription; } set { _jobdescription = value; } }

        static DateTime _time = DateTime.Now;
        public static DateTime Time { get { return _time; } set { } }

        public Job Make;

        string _assignedemployee;
        public string AssignedEmployee { get { return _assignedemployee; } set { _assignedemployee = value; } }
        public JobUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add Job Click is a listener for when the button is clicked in the XAML
        /// This will create a new job item and add it to a list that already exist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddJob_Click(object sender, RoutedEventArgs e)
        {
            Make = new Job(JobTitle, JobId, JobId, Time, Time, JobDescription);
            MessageBox.Show("This Button Does Something.\nCurrent Time: " + Time +
               "\nJob Title: " + Make.JobName +
               "\nJob Description: " + Make.Description +
               "\nJob ID: " + Make.CommonID +
               "\nEmmployee Assigned: " + Make.JobName +
               "\nPriority: " +
               "\nJob Time made: ");
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
