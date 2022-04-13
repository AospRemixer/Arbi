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

namespace Arbi
{
    /// <summary>
    /// Interaction logic for readingWindowStart.xaml
    /// </summary>
    public partial class readingWindowStart : Window
    {
        public readingWindowStart()
        {
            InitializeComponent();
        }

        private void lvl1_click(object sender, RoutedEventArgs e)
        {
            readingLvl1 rl1 = new readingLvl1();
            rl1.Show();
            this.Close();
        }

        private void lvl2_click(object sender, RoutedEventArgs e)
        {
            readingLvl2 rl2 = new readingLvl2();
            rl2.Show();
            this.Close();
        }
    }
}
