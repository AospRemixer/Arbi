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
using WpfMath;

namespace Arbi
{
    /// <summary>
    /// Interaction logic for mathQ.xaml
    /// </summary>
    public partial class mathQ : Window
    {
        public mathQ()
        {
            InitializeComponent();
        }

        private void lvl1_click(object sender, RoutedEventArgs e)
        {
            mathLvl1 ml1 = new mathLvl1();
            ml1.Show();
            this.Close();
        }

        private void lvl2_click(object sender, RoutedEventArgs e)
        {
            mathLvl2 ml2 = new mathLvl2();
            ml2.Show();
            this.Close();
        }

        private void lvl3_click(object sender, RoutedEventArgs e)
        {
            mathLvl3 ml3 = new mathLvl3();
            ml3.Show();
            this.Close();
        }
    }
}
