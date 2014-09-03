

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
using TaskITMain.Delegates;

namespace TaskITMain.UserControls
{
    /// <summary>
    /// Interaction logic for CreateJob.xaml
    /// </summary>
    public partial class CreateJob : UserControl
    {
        public event AddDelegate JobDel;

        public bool IsOpen
        {
            get { return popup.IsOpen; }
            set { popup.IsOpen = value; }
        }
        public string POC { get; set; }
        public int Priority { get; set; }
        public string JobCategory { get; set; }
        public string JobDescription { get; set; }
        public string AssignedTo { get; set; }
        public DateTime DateSubmitted { get; set; }

        public CreateJob()
        {
            InitializeComponent();
        }

        private void pointOfContactTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            POC = pointOfContactTextBox.Text;
        }

        private void priorityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int result;

            if (int.TryParse(priorityTextBox.Text, out result))
            {
                Priority = result;
            }
        }

        private void JobCategoryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            JobCategory = jobCategoryTextBox.Text;
        }

        private void JobDescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            JobDescription = jobDescriptionTextBox.Text;
        }

        private void assignedToTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AssignedTo = assignedToTextBox.Text;
        }

        private void saveJobButton_Click(object sender, RoutedEventArgs e)
        {
            DateSubmitted = DateTime.Now;

            JobDel.Invoke(JobCategory, JobDescription, POC, AssignedTo, Priority);

            pointOfContactTextBox.Text = "";
            priorityTextBox.Text = "";
            jobCategoryTextBox.Text = "";
            jobDescriptionTextBox.Text = "";
            assignedToTextBox.Text = "";

            popup.IsOpen = false;
        }
    }
}

