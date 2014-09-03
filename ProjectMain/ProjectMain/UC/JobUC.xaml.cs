using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ProjectMain.Enums;

namespace ProjectMain.UC
{
    /// <summary>
    /// Interaction logic for JobUC.xaml
    /// </summary>
    public partial class JobUC : UserControl
    {
        public event AddDelegate JobDel;

        public int JobId { get; set; }

        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        public string POC { get; set; }

        static DateTime _time = DateTime.Now;
        public static DateTime Time { get { return _time; } set { } }

        public Job Make;

        public ObservableCollection<Employees> AssignedEmployee = 
            new ObservableCollection<Employees>();

        public ObservableCollection<Employees> EmployeeList = 
            EmployeeDB.PopulateDB("../../Employeelist");

        public PriorityLevel pry { get; set; }
        
        public JobUC()
        {
            this.DataContext = this;
            InitializeComponent();
            JobDescJobEmployee.ItemsSource = EmployeeList;
            AssignedEmployees.ItemsSource = AssignedEmployee;
        }

        /// <summary>
        /// Add Job Click is a listener for when the button is clicked in the XAML
        /// This will create a new job item and add it to a list that already exist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddJob_Click(object sender, RoutedEventArgs e)
        {
            Make = new Job
            {
                Description = JobDescription, JobName = JobTitle,
                ID = JobId, Pry = (PriorityLevel) JobDescPriority.SelectedItem, 
                TimeStarted = Time };
            JobDel.Invoke(Make);
            MessageBox.Show(JobTitle);
            WindowCloseBehaviour.SetClose(this, true);
        }

        //private void pointOfContactTextBox_TextChanged_1(object sender,
        //TextChangedEventArgs e)
        //{
        //    POC = (TextBox)sender.Text;
        //}

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employees created = (Employees)JobDescJobEmployee.SelectedItem;
            AssignedEmployee.Add((Employees)JobDescJobEmployee.SelectedItem);
        }

        private void AssignedEmployees_MouseRightButtonUp(object sender, 
            MouseButtonEventArgs e)
        {
            AssignedEmployee.RemoveAt(AssignedEmployees.SelectedIndex);
        }
    }

    /// <summary>
    /// Class that handles the closing of specific windows without intturpting the other windows.
    /// </summary>
    public static class WindowCloseBehaviour
    {
        public static void SetClose(DependencyObject target, bool value)
        {
            target.SetValue(CloseProperty, value);
        }
        public static readonly DependencyProperty CloseProperty =
        DependencyProperty.RegisterAttached(
        "Close",
        typeof(bool),
        typeof(WindowCloseBehaviour),
        new UIPropertyMetadata(false, OnClose));
        private static void OnClose(DependencyObject sender, 
            DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool && ((bool)e.NewValue))
            {
                Window window = GetWindow(sender);
                if (window != null)
                    window.Close();
            }
        }
        private static Window GetWindow(DependencyObject sender)
        {
            Window window = null;
            if (sender is Window)
                window = (Window)sender;
            if (window == null)
                window = Window.GetWindow(sender);
            return window;
        }
    }
}
