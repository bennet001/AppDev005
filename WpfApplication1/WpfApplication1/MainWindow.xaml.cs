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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //_joblist.Add(new JobTest());
            //_joblist.Add(new JobTest());
            //_joblist.Add(new JobTest());
            
            _joblist.Count();
            this.DataContext = this;
            InitializeComponent();
            JobList.Add(JobUserControl.Make);
            Console.Write(JobUserControl.Height);
        }

        public void ButtonClick_Handler(JobTest addition)
        {
            _joblist.Add(addition);
        }

        private ObservableCollection<JobTest> _joblist = new ObservableCollection<JobTest>();
        public ObservableCollection<JobTest> JobList { get { return _joblist; } set { _joblist = value; } }
    }
}
