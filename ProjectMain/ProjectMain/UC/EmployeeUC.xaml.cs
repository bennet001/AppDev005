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
using ProjectMain.Models;
using ProjectMain.Enums;
using ProjectMain.SaveToDB;

namespace ProjectMain.UC
{
	/// <summary>
	/// Interaction logic for Employee.xaml
	/// </summary>
	public partial class EmployeeUC : UserControl
	{
		public Job task { get; private set; }
		private static DateTime defultDateTime = new DateTime(9999, 12, 31, 12, 59, 59, DateTimeKind.Local);
		private static DateTime DefultDateTime
		{
			get { return defultDateTime; }
		}
		private static DateTime _TimeNow = System.DateTime.Now;
		private static DateTime TimeNow
		{
			get { return _TimeNow; }
			set { _TimeNow = value; }
		}
		private bool isStarted = false;
		private bool IsStarted
		{
			get { return isStarted; }
			set { isStarted = value; }
		}
		Window JobUserControl1;


        public EmployeeUC(Job _task)
		{
			InitializeComponent();

			task = _task;

			//jobNameLabel = task.JobName;
			//jobLocationLabel = task.
			//jobDateLabel = task.TimeDue;
			//commentsTextBlock = task.Description;

		}

		private void Start_Job_Click(object sender, RoutedEventArgs e)
		{
			if (task.TimeDue < TimeNow)
			{
				MessageBox.Show("You cannot start this job. It is scheduled to start at " + task.TimeStarted.ToString("T"));
				if (task.TimeStarted <= TimeNow)
				{
					IsStarted = true;
				}
			}
			else if (task.TimeStarted <= DefultDateTime && task.IsCompleted == false && IsStarted == false)
			{
				task.TimeStarted = TimeNow;
				MessageBox.Show("The job " + task.JobName + " has been started at " + task.TimeStarted.ToString("T"));
				SaveThis();
				IsStarted = true;
			}
			else
			{
				MessageBox.Show("You cannot start this job again. It has already been started at " + task.TimeStarted.ToString("T"));
			}
		}

		private void Finish_Job_Click(object sender, RoutedEventArgs e)
		{
			if (task.TimeStarted <= TimeNow && task.TimeStarted != DefultDateTime && task.IsCompleted == false && IsStarted == true)
			{
				TimeNow = DateTime.Now;
				task.TimeFinished = TimeNow;
				task.IsCompleted = true;
				MessageBox.Show("The job " + task.JobName + " has been completed at " + task.TimeFinished.ToString("T"));
				SaveThis();
				IsStarted = false;
				ExitProgram();
			}
			else
			{
				if (isStarted == false)
				{
					MessageBox.Show("The job " + task.JobName + " cannot be completed becasue it hasn't been started yet.");
				}
			}
		}

		private void SaveThis()
		{
			//Save this current job. 
			InAndOut a = new InAndOut();
			a.SaveJob(task);
			//MessageBox.Show("The job " + task.JobName + " has been saved.");
		}

		private void ExitProgram()
		{
			//MessageBox.Show("Bye.");
			//this.Exit(1);
			//System.Environment.Exit(0);
			WindowCloseBehaviour.SetClose(this, true);
		}

		private void Log_out_Click(object sender, RoutedEventArgs e)
		{
			//This needs to open a new instance of the log-in window before complete close, multi-thredding.
	
			ExitProgram();
		}

		private void returnButton_Click(object sender, RoutedEventArgs e)
		{
			JobUserControl1 = new Window();
			ExitProgram();
		}

	}
}
