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
using AngouriMath;

namespace Arbi
{
    /// <summary>
    /// Interaction logic for mathLvl1.xaml
    /// </summary>
    public partial class mathLvl1 : Window
    {
        string curProblem;
        int curScoreE = 0;
        Stopwatch sw = new Stopwatch();
        public mathLvl1()
        {
            InitializeComponent();
            browserActivities ba = new browserActivities();
            makeProblem();
            sw.Start();
        }

        private void lostFocusKeyboard(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (awnsTxt.Text == "Answer Here...")
                awnsTxt.Text = string.Empty;
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if(checkProblem())
            {
                globalVar gv = new globalVar();
                curScoreE += 1;
                curScore.Content = curScoreE;
                makeProblem();
                awnsTxt.Text = string.Empty;
            }
            else if (checkProblem() == false)
            {
                sw.Stop();
                int pointsToAdd = curScoreE * 2;
                globalVar.daPointsEarned = pointsToAdd;
                globalVar.daScore = curScoreE;
                globalVar.daTime = sw.ElapsedMilliseconds / 1000;
                finalScore fs = new finalScore();
                fs.Show();
                Close();
            }

        }

        void makeProblem()
        {
            int maxNum = 51;
            int minNum = 1;
            int curOper = new Random().Next(1, 5);
            switch(curOper)
            {
                case 1:
                    curProblem = RandomNumber(minNum, maxNum).ToString() + " + " + RandomNumber(minNum, maxNum).ToString();
                    break;
                case 2:
                    curProblem = RandomNumber(minNum, maxNum).ToString() + " - " + RandomNumber(minNum, maxNum).ToString();
                    break;
                case 3:
                    curProblem = RandomNumber(1, 12).ToString() + " * " + RandomNumber(1, 12).ToString();
                    break;
                case 4:
                    curProblem = divisionProblemGenerator();
                    break;
            }
            equaTxt.Content = curProblem;
        }

        bool checkProblem()
        {
            Entity expr = equaTxt.Content.ToString();
            var a = expr.EvalNumerical();
            if (a.ToString() == awnsTxt.Text.Trim())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string divisionProblemGenerator()
        {
            int r = RandomNumber(1, 12);
            int biggerNum = r * RandomNumber(1, 12);
            return biggerNum.ToString() + " / " + r.ToString();
        }

        //Function to get a random number 
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }
}
