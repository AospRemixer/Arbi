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

namespace Arbi
{
    /// <summary>
    /// Interaction logic for random.xaml
    /// </summary>
    public partial class random : Page
    { 
        public random()
        {
            InitializeComponent();
        }

        private void randomBtn_Click(object sender, RoutedEventArgs e)
        {
            int i = RandomNumber(1, 7);
            switch (i)
            {
                case 1:
                    workoutWindow ww = new workoutWindow();
                    ww.Show();
                    break;
                case 2:
                    mathQ mq = new mathQ();
                    mq.Show();
                    break;
                case 3:
                    artWindow aw = new artWindow();
                    aw.Show();
                    break;
                case 4:
                    readingWindowStart rws = new readingWindowStart();
                    rws.Show();
                    break;
                case 5:
                    geographyWindow gw = new geographyWindow();
                    gw.Show();
                    break;
                case 6:
                    scienceWindow sw = new scienceWindow();
                    sw.Show();
                    break;
            }
        }

        //Function to get a random number 
        private static readonly Random rrandom = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return rrandom.Next(min, max);
            }
        }
    }
}
