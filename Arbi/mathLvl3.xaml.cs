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
    /// Interaction logic for mathLvl3.xaml
    /// </summary>
    public partial class mathLvl3 : Window
    {
        string curProblem;
        int curScoreE = 0;
        int curOper = new Random().Next(1, 5);
        Stopwatch sw = new Stopwatch();
        public mathLvl3()
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
            if (checkProblem())
            {
                globalVar gv = new globalVar();
                curScoreE += 1;
                curScore.Content = curScoreE;
                makeProblem();
                // Then Continue and add points.
            }
            else if (checkProblem() == false)
            {
                sw.Stop();
                int pointsToAdd = curScoreE * 5;
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
            curOper = RandomNumber(1, 20);
            switch (curOper)
            {
                case 1:
                    //  !! HAVE TO FINISH THIS !!
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
