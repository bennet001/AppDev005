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
using System.Collections.ObjectModel;
using TaskIT.Models;
using System.IO;
using TaskIT.UserControls;


namespace TaskIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<MockJob> jobs;
        StreamWriter sw;

        public MainWindow()
        {
            InitializeComponent();

            jobPopup.JobDel += SaveJob;

            jobs = new ObservableCollection<MockJob>();

            IncompleteJobDataGrid.ItemsSource = jobs;
        }

        private void CreateJobButton_Click(object sender, RoutedEventArgs e)
        {
            jobPopup.IsOpen = true;
        }

        protected void SaveJob(int JobID, string Description, DateTime DateSubmitted, string POC, int Priority, bool IsCompleted)
        {
            MockJob mock = new MockJob(JobID, Description, DateSubmitted, POC, Priority, IsCompleted);
            jobs.Add(mock);

            using (sw = new StreamWriter("c:/users/christopher rains/desktop/testoutput.txt", true))
            {
                sw.Write(JobID + "|");
                sw.Write(Description + "|");
                sw.Write(DateSubmitted + "|");
                sw.Write(POC + "|");
                sw.Write(Priority + "|");
                sw.Write(IsCompleted + "|");
                sw.WriteLine();
            }
        }        
    }
}
