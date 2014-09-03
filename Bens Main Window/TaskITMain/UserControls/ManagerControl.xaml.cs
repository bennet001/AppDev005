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
using TaskITMain.UserControls;

namespace TaskITMain
{
    /// <summary>
    /// Interaction logic for ManagerControl.xaml
    /// </summary>
    public partial class ManagerControl : UserControl
    {
        ObservableCollection<Job> jobs;
        StreamWriter sw;
        int currentJobID;

        public ManagerControl()
        {
            InitializeComponent();

            //Subscribe SaveJob() to the delgate, linking the main window and the Job popup window.
            jobPopup.JobDel += SaveJob;

            jobs = new ObservableCollection<Job>();

            

            IncompleteJobDataGrid.ItemsSource = jobs;
        }

        //Prevents display of specific columns within this view.  Renames specific column headers.
        private void IncompleteJobDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "TimeStarted" ||
                e.Column.Header.ToString() == "TimeFinished" ||
                e.Column.Header.ToString() == "IsCompleted")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString() == "JobID")
            {
                e.Column.Header = "Job ID";
            }
            if (e.Column.Header.ToString() == "JobCategory")
            {
                e.Column.Header = "Job Category";
            }
            if (e.Column.Header.ToString() == "DateSubmitted")
            {
                e.Column.Header = "Date Submitted";
            }
            if (e.Column.Header.ToString() == "POC")
            {
                e.Column.Header = "Point of contact";
            }
            if (e.Column.Header.ToString() == "AssignedTo")
            {
                e.Column.Header = "Assigned To";
            }
        }

        //Sets the value of jobPopup.IsOpen to true.
        private void CreateJobButton_Click(object sender, RoutedEventArgs e)
        {
            ////jobPopup.IsOpen = true;
            //CreateJob create = new CreateJob();
            //jobPopup.DataContext = create;
            jobPopup.IsOpen = true;
        }

    
    }
}


