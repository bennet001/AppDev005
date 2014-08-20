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
using TaskIT.Delegates;

namespace TaskIT.UserControls
{
    /// <summary>
    /// Interaction logic for TestUserControl.xaml
    /// </summary>
    public partial class TestUserControl : UserControl
    {
        public event AddDelegate JobDel;

        public bool IsOpen 
        {
            get { return popup.IsOpen; }
            set { popup.IsOpen = value; }
        }
        public int JobID { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string POC { get; set; }
        public int Priority { get; set; }
        public DateTime TimeStarted { get; set; }
        public DateTime TimeFinished { get; set; }
        public bool IsCompleted { get; set; }

        public TestUserControl()
        {
            InitializeComponent();
        }

        private void saveJobButton_Click(object sender, RoutedEventArgs e)
        {
            DateSubmitted = DateTime.Now;
            JobDel.Invoke(JobID, JobName, Description, DateSubmitted, POC, Priority, IsCompleted);
            popup.IsOpen = false;
        }

        private void pointOfContactTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            POC = pointOfContactTextBox.Text;
        }

        private void priorityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int result;

            if(int.TryParse(priorityTextBox.Text, out result))
            {
                Priority = result;
            }
        }

        private void JobDescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Description = JobDescriptionTextBox.Text;
        }
    }
}
