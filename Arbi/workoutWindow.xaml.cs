using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Arbi
{
    /// <summary>
    /// Interaction logic for workoutWindow.xaml
    /// </summary>
    public partial class workoutWindow : Window
    {
        int currentScore = 0;
        bool curStarted = false;
        int finalScore = 0;
        public static int waitMode = 0;
        bool swStarted = false;
        public Stopwatch sw = new Stopwatch();

        public workoutWindow()
        {
            InitializeComponent();
            globalVar gv = new globalVar();
            gv.openAll();

        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (swStarted)
            {
                // Then Do Nothing
            }
            else if (swStarted == false)
            {
                sw.Start();
            }
            if (curStarted == false)
            {
                curStarted = true;
            }
            else if (curStarted == true)
            {
                currentScore += 1;
                scoreNumTxt.Text = currentScore.ToString();
            }


            // The code below randomly decides the button colors.
            int nextClrI = new Random().Next(10);
            int exitClrI = new Random().Next(10);
            int mainBtnI = new Random().Next(10);
            switch (nextClrI)
            {
                case 0:
                    nextBtn.Background = hexToBrush("#FF6B6B");
                    break;
                case 1:
                    nextBtn.Background = hexToBrush("#F7B7BB");
                    break;
                case 2:
                    nextBtn.Background = hexToBrush("#D0ECEF");
                    break;
                case 3:
                    nextBtn.Background = hexToBrush("#cfbaf0");
                    break;
                case 4:
                    nextBtn.Background = hexToBrush("#b9fbc0");
                    break;
                case 5:
                    nextBtn.Background = hexToBrush("#ffc6ff");
                    break;
                case 6:
                    nextBtn.Background = hexToBrush("#ffcfd2");
                    break;
                case 8:
                    nextBtn.Background = hexToBrush("#98f5e1");
                    break;
                case 9:
                    nextBtn.Background = hexToBrush("#a3c4f3");
                    break;
            }
            switch (exitClrI)
            {
                case 0:
                    giveUpBtn.Background = hexToBrush("#FF6B6B");
                    break;
                case 1:
                    giveUpBtn.Background = hexToBrush("#F7B7BB");
                    break;
                case 2:
                    giveUpBtn.Background = hexToBrush("#D0ECEF");
                    break;
                case 3:
                    giveUpBtn.Background = hexToBrush("#cfbaf0");
                    break;
                case 4:
                    giveUpBtn.Background = hexToBrush("#b9fbc0");
                    break;
                case 5:
                    giveUpBtn.Background = hexToBrush("#ffc6ff");
                    break;
                case 6:
                    giveUpBtn.Background = hexToBrush("#ffcfd2");
                    break;
                case 8:
                    giveUpBtn.Background = hexToBrush("#98f5e1");
                    break;
                case 9:
                    giveUpBtn.Background = hexToBrush("#a3c4f3");
                    break;
            }
            switch (mainBtnI)
            {
                case 0:
                    activityBtn.Background = hexToBrush("#FF6B6B");
                    break;
                case 1:
                    activityBtn.Background = hexToBrush("#F7B7BB");
                    break;
                case 2:
                    activityBtn.Background = hexToBrush("#D0ECEF");
                    break;
                case 3:
                    activityBtn.Background = hexToBrush("#cfbaf0");
                    break;
                case 4:
                    activityBtn.Background = hexToBrush("#b9fbc0");
                    break;
                case 5:
                    activityBtn.Background = hexToBrush("#ffc6ff");
                    break;
                case 6:
                    activityBtn.Background = hexToBrush("#ffcfd2");
                    break;
                case 8:
                    activityBtn.Background = hexToBrush("#98f5e1");
                    break;
                case 9:
                    activityBtn.Background = hexToBrush("#a3c4f3");
                    break;
            }

            int numOfReps = 0;
            // This decides the next activty.
            if (currentScore <= 5)
            {
                numOfReps = new Random().Next(1, 21);
            }
            else if (currentScore > 5 && currentScore <= 10)
            {
                numOfReps = new Random().Next(5, 31);
            }
            else if (currentScore > 10 && currentScore <= 20)
            {
                numOfReps = new Random().Next(10, 41);
            }
            else if (currentScore > 20 && currentScore <= 30)
            {
                numOfReps = new Random().Next(20, 51);
            }
            else if (currentScore > 30)
            {
                numOfReps = new Random().Next(50, 101);
            }

            int nextActivityI = new Random().Next(9);
            switch(nextActivityI)
            {
                case 0:
                    taskTB.Content = $@"Do Crunches - x{numOfReps}";
                    svgMain.Source = new Uri(@"pack://application:,,,/assets/exerciseIcons/crunches.svg");
                    break;
                case 1:
                    taskTB.Content = $@"Do Leg Raises - x{numOfReps}";
                    svgMain.Source = new Uri(@"pack://application:,,,/assets/exerciseIcons/legRaises.svg");
                    break;
                case 2:
                    taskTB.Content = $@"Do Lunges - x{numOfReps}";
                    svgMain.Source = new Uri(@"pack://application:,,,/assets/exerciseIcons/lunges.svg");
                    break;
                case 3:
                    taskTB.Content = $@"Bicep Curl with the Heaviest Object you can Find - x{numOfReps}";
                    svgMain.Source = new Uri(@"pack://application:,,,/assets/exerciseIcons/pickupHeavy.svg");
                    break;
                case 4:
                    taskTB.Content = $@"Spend atleast {numOfReps * 15} seconds outside";
                    svgMain.Source = new Uri(@"pack://application:,,,/assets/exerciseIcons/spendTimeInSun.svg");
                    break;
                case 5:
                    taskTB.Content = $@"Do x{numOfReps} squats slowly!";
                    svgMain.Source = new Uri(@"pack://application:,,,/assets/exerciseIcons/squats.svg");
                    break;
                case 6:
                    taskTB.Content = $@"Do x{numOfReps} knee pushups slowly!";
                    svgMain.Source = new Uri(@"pack://application:,,,/assets/exerciseIcons/kneePushups.svg");
                    break;
                case 7:
                    taskTB.Content = $@"Jog in place for {numOfReps * 15} seconds!";
                    svgMain.Source = new Uri(@"pack://application:,,,/assets/exerciseIcons/jogInPlace.svg");
                    break;
                case 8:
                    taskTB.Content = $@"Hold the heaviest object you can find above you and repeat {numOfReps} times!";
                    svgMain.Source = new Uri(@"pack://application:,,,/assets/exerciseIcons/dumbbellsUp.svg");
                    break;
            }

        }

        SolidColorBrush hexToBrush(string hex)
        {
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush = (SolidColorBrush)new BrushConverter().ConvertFrom(hex);
            return mySolidColorBrush;
        }

        private void giveUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentScore > 0)
            {
                if ((sw.ElapsedMilliseconds / 1000) / currentScore >= 10)
                {
                    finalScore = currentScore * 5;
                    globalVar.daPointsEarned += finalScore;
                    globalVar.daScore = currentScore;
                    globalVar.ttlPoints += finalScore;
                    globalVar.daTime = sw.ElapsedMilliseconds / 1000;
                    finalScore fsda = new finalScore();
                    fsda.Show();
                    this.Close();
                }
                else
                {
                    int num = Convert.ToInt32((currentScore * 10) - sw.ElapsedMilliseconds / 1000);
                    var Result = MessageBox.Show($"You did these too fast, spend atleast {num} seconds more to earn points!\nOr you can give up now, no points will be given if you do.", "Penalty", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if(Result == MessageBoxResult.Yes)
                    {
                        Close();
                    }
                    else if (Result == MessageBoxResult.No)
                    {

                    }
                }
            }
            else
            {
                Close();
            }
        }
    }
}
