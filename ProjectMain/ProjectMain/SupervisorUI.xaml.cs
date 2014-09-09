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
using ProjectMain.SaveToDB;

namespace ProjectMain
{
    /// <summary>
    /// Interaction logic for SupervisorUI.xaml
    /// </summary>
    public partial class SupervisorUI : UserControl
    {
        ObservableCollection<Job> jobs;
        StreamWriter sw;
        Window JobUserControlWindow;
 
        public SupervisorUI()
        {
            
            InitializeComponent();
        
            IncompleteJobDataGrid.ItemsSource = jobs;
        }
        private void CreateJobButton_Click(object sender, RoutedEventArgs e)
        {
             JobUserControlWindow = new Window();
            CreateJobUC popupJobUC = new CreateJobUC();


            //popupJobUC.JobDel += SaveJob;

			InAndOut a = new InAndOut();
			
				for (int i = 0; i < jobs.Count(); i++)
				{
					a.SaveJob(jobs[i]);
				}

            JobUserControlWindow.Height = 300;
            JobUserControlWindow.Width = 300;
            JobUserControlWindow.MinHeight = 250;
            JobUserControlWindow.MinWidth = 300;
            JobUserControlWindow.MaxHeight = 400;
            JobUserControlWindow.MaxWidth = 400;
            JobUserControlWindow.Content = popupJobUC;
            JobUserControlWindow.Show();
        }



        private void DeleteJobButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}