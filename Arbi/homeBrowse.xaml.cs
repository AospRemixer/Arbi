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
    /// Interaction logic for homeBrowse.xaml
    /// </summary>
    public partial class homeBrowse : Page
    {   
        public homeBrowse()
        {
            InitializeComponent();
        }

        private void workoutBtn_Click(object sender, RoutedEventArgs e)
        {
            workoutWindow ww = new workoutWindow();
            ww.Show();
        }

        private void mathBtn_Click(object sender, RoutedEventArgs e)
        {
            mathQ mq = new mathQ();
            mq.Show();
        }

        private void drawingBtn_Click(object sender, RoutedEventArgs e)
        {
            artWindow aw = new artWindow();
            aw.Show();
        }

        private void readingBtn(object sender, RoutedEventArgs e)
        {
            readingWindowStart rws = new readingWindowStart();
            rws.Show();
        }

        private void geoClick(object sender, RoutedEventArgs e)
        {
            geographyWindow gw = new geographyWindow();
            gw.Show();
        }

        private void sci_Click(object sender, RoutedEventArgs e)
        {
            scienceWindow sw = new scienceWindow();
            sw.Show();
        }
    }
}
