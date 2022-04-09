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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Arbi
{
    /// <summary>
    /// Interaction logic for finalScoreDailyArbi.xaml
    /// </summary>
    public partial class finalScoreDailyArbi : Window
    {
        int curScoreShowed = 0;

        public finalScoreDailyArbi()
        {
            InitializeComponent();
            Counter_Timer.Interval = TimeSpan.FromMilliseconds(1);
            Counter_Timer.Tick += dispatcherTimer_Tick;
            Counter_Timer.Start();
        }
        private readonly DispatcherTimer Counter_Timer = new DispatcherTimer();

        public void dispatcherTimer_Tick(object sender, object e)
        {
            if (curScoreShowed == 0)
            {
                scoreLabel.Content = Convert.ToInt16(scoreLabel.Content) + 1;
                if (Convert.ToInt16(scoreLabel.Content) >= globalVar.daScore)
                {
                    Counter_Timer.Stop();
                }
            }
            else if (curScoreShowed == 1)
            {
                timeLabel.Content = Convert.ToInt16(timeLabel.Content) + 1;
                if (Convert.ToInt16(timeLabel.Content) >= globalVar.daTime)
                {
                    Counter_Timer.Stop();
                }
            }
            else if (curScoreShowed == 2)
            {
                pointsEarnedLabel.Content = Convert.ToInt16(pointsEarnedLabel.Content) + 1;
                if (Convert.ToInt16(pointsEarnedLabel.Content) >= globalVar.daPointsEarned)
                {
                    Counter_Timer.Stop();
                }
            }
        }

        private void resultNextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (curScoreShowed == 0)
            {
                curScoreShowed = 1;
                Counter_Timer.Start();
            }
            else if (curScoreShowed == 1)
            {
                curScoreShowed = 2;
                Counter_Timer.Start();
            }
            else if (curScoreShowed == 2)
            {
                browserActivities ba = new browserActivities();
                ba.Show();
                this.Close();
            }
        }
    }
}
