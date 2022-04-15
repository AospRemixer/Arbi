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
    /// Interaction logic for scienceWindow.xaml
    /// </summary>
    public partial class scienceWindow : Window
    {
        int w;
        int curScore = 0;
        Stopwatch sw = new Stopwatch();
        // QUestions Listed into a Array!
        public string[] q = { "How much charge does a proton have?", 
            "How much charge does a neutron have?", "How much charge does a electron have?", 
            "How much mass does a proton have?", "How much mass does a neutron have?", "How much mass does a electron have?", 
            "How much ion charge does Lithium have?", "How much ion charge does Sodium have?", 
            "How much ion charge does Potassium have?", "How much ion charge does Calcium have?", 
            "How much ion charge does Barium have?", "What is the density formula?", "What is the energy formula?", 
            "What is the speed formula?", "What is the force formula?" };

        // The correct answers!
        public string[] a = { "1", "0", "-1", "1", "1", "0", "1", "1", "1", "2", "2", "D = m/v", "E = mc^2", "v = d/t", "F = m * a"};
        // The wrong answers!
        public string[] b = { "-1", "2", "0", "0", "2", "-1", "0", "0", "0", "1", "1", "E = mc^2", "v = d/t", "F = m * a", "D = m/v" };

        public scienceWindow()
        {
            InitializeComponent();
            makeQ();
        }

        public void makeQ()
        {
            int r = RandomNumber(0, 15);
            w = RandomNumber(1, 3);
            switch(w)
            {
                case 1:
                    btn1_txt.Text = a[r];
                    btn2_txt.Text = b[r];
                    break;
                case 2:
                    btn2_txt.Text = a[r];
                    btn1_txt.Text = b[r];
                    break;
            }
            question.Text = curScore.ToString() + ". " + q[r];
        }

        private void btn1_click(object sender, RoutedEventArgs e)
        {
            switch (w)
            {
                case 1:
                    curScore++;
                    makeQ();
                    break;
                case 2:
                    sw.Stop();
                    globalVar.daPointsEarned = curScore * RandomNumber(1, 8);
                    globalVar.daScore = curScore;
                    globalVar.daTime = sw.ElapsedMilliseconds / 1000;
                    finalScore fs = new finalScore();
                    fs.Show();
                    Close();
                    break;
            }
        }

        private void btn2_click(object sender, RoutedEventArgs e)
        {
            switch (w)
            {
                case 1:
                    sw.Stop();
                    globalVar.daPointsEarned = curScore * 10;
                    globalVar.daScore = curScore;
                    globalVar.daTime = sw.ElapsedMilliseconds / 1000;
                    finalScore fs = new finalScore();
                    fs.Show();
                    Close();
                    break;
                case 2:
                    curScore++;
                    makeQ();
                    break;
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
