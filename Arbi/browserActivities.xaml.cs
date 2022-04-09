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
    /// Interaction logic for browserActivities.xaml
    /// </summary>
    public partial class browserActivities : Window
    {
        public browserActivities()
        {
            InitializeComponent();
            homeBrowse hb = new homeBrowse();
            browseFrame.Content = hb;
            ttlPointsLabel.Content = globalVar.ttlPoints;
        }

        // To Help Move Around The App
        private void MainBrowse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void exitBtnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
