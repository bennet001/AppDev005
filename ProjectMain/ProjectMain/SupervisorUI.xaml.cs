using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Shapes;
using ProjectMain.UC;

namespace ProjectMain
{
    /// <summary>
    /// Interaction logic for SupervisorUI.xaml
    /// </summary>
    public partial class SupervisorUI : Window
    {
        ObservableCollection<Job> jobs;
        StreamWriter sw;
        Window JobUserControlWindow;
 
        public SupervisorUI()
        {
            
            InitializeComponent();
            jobs = JobDB.PopulateDB("../../Jobs");
            IncompleteJobDataGrid.ItemsSource = jobs;
        }
        private void CreateJobButton_Click(object sender, RoutedEventArgs e)
        {
             JobUserControlWindow = new Window();
            JobUC popupJobUC = new JobUC();
            popupJobUC.JobDel += SaveJob;
            JobUserControlWindow.Height = 300;
            JobUserControlWindow.Width = 300;
            JobUserControlWindow.MinHeight = 250;
            JobUserControlWindow.MinWidth = 300;
            JobUserControlWindow.MaxHeight = 400;
            JobUserControlWindow.MaxWidth = 400;
            JobUserControlWindow.Content = popupJobUC;
            JobUserControlWindow.Show();
        }

        protected void SaveJob(Job entered)
        {
            Job mock = entered;
            jobs.Add(mock);
            
            using (sw = new StreamWriter("../../Jobs/Job" + JobDB.Count +".txt", true))
            {
                sw.WriteLine(mock.ID);
                sw.WriteLine(mock.JobName);
                sw.WriteLine(mock.Description);
                sw.WriteLine(mock.TimeStarted);
                //sw.Write(POC + "|");
                sw.WriteLine(mock.Pry);
                //sw.Write(IsCompleted + "|");
                sw.WriteLine();
            }
            JobDB.Count++;
        }

        private void DeleteJobButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}