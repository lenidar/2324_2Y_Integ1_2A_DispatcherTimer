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
using System.Windows.Threading;

namespace _2324_2Y_Integ1_2A_DispatcherTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _timerStatus = false;
        DispatcherTimer _dt = null;

        public MainWindow()
        {
            InitializeComponent();
            _dt = new DispatcherTimer();
            _dt.Tick += _dt_Tick;
            _dt.Interval = new TimeSpan(0,0,0,0,100);
        }

        private void _dt_Tick(object sender, EventArgs e)
        {
            int sec = int.Parse(lblTimerDisplay.Content.ToString());
            sec--;
            if(sec < 0)
            {
                sec = 59;
                lblTimerDisplay_Min.Content = 
                    int.Parse(lblTimerDisplay_Min.Content.ToString()) - 1;
            }
            lblTimerDisplay.Content = sec.ToString();
        }

        private void btnStartStop_Click(object sender, RoutedEventArgs e)
        {
            // do something based on status
            if (_timerStatus)
                _dt.Stop();
            else
                _dt.Start();

            _timerStatus = !_timerStatus;
            if (_timerStatus)
                btnStartStop.Content = "Stop";
            else
                btnStartStop.Content = "Start";
        }
    }
}
