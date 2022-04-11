using System;
using System.Windows;
using System.Windows.Threading;

namespace Arbi
{
    /// <summary>
    /// Interaction logic for finalScore.xaml
    /// </summary>
    public partial class finalScore : Window
    {
        int curScoreShowed = 0;
        public finalScore()
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
                globalVar.ttlPoints += globalVar.daPointsEarned;
                globalVar gv = new globalVar();
                browserActivities ba = new browserActivities();
                ba.ttlPointsLabel.Content = globalVar.ttlPoints;
                gv.saveAll();
                this.Close();
            }
        }
        }
    }
