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
using AngouriMath.Extensions;

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
            if (checkProblem(curProblem))
            {
                curScoreE += 1;
                curScore.Content = curScoreE;
                makeProblem();
                awnsTxt.Text = string.Empty;
            }
            else if (checkProblem(curProblem) == false)
            {
                sw.Stop();
                int pointsToAdd = curScoreE * 10;
                globalVar.daPointsEarned = pointsToAdd;
                globalVar.daScore = curScoreE;
                globalVar.daTime = sw.ElapsedMilliseconds / 1000;
                finalScore fs = new finalScore();
                fs.Show();
                Close();
            }

        }

        public string problemTemplateGen()
        {
            int r = RandomNumber(1, 8);
            int a = RandomNumber(1, 100);
            int b = RandomNumber(1, 100);
            int c = RandomNumber(1, 100);
            string result = string.Empty;
            switch (r)
            {
                case 1:
                    result = $"{a}x = {a * b}";
                    break;
                case 2:
                    result = $"{a}x - {b} = {(a * c) - b}";
                    break;
                case 3:
                    result = $"{a} + {b} + x = {a + b + c}";
                    break;
                case 4:
                    result = $"{a} - x = {a * c}";
                    break;
                case 5:
                    result = $"{a} + x = {a + c}";
                    break;
                case 6:
                    result = $"{a} + (-x) = {a - c}";
                    break;
                case 7:
                    result = $"{a} - (-x) = {a + c}";
                    break;
            }
            return result;
        }

        void makeProblem()
        {
            curProblem = problemTemplateGen();
            latexTxt.Formula = curProblem.Latexise();
        }

        // Checks if Answer is Correct
        bool checkProblem(string equation)
        {
            string solveResult = equation.Solve("x").ToString();
            string needB = string.Empty;
            foreach (char x in solveResult)
            {
                if (x == '{')
                {
                    // Do Nothing
                }
                else if (x == '}')
                {
                    // Also Do Nothing
                }
                else
                {
                    needB += x.ToString();
                }
            }
            string finalAngouriResult = needB.Trim();
            if (finalAngouriResult == awnsTxt.Text.Trim())
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
