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
    /// Interaction logic for learnWindow.xaml
    /// </summary>
    public partial class learnWindow : Window
    {
        public learnWindow()
        {
            InitializeComponent();
            nextP();
        }

        public void nextP()
        {
            int year = RandomNumber(2011, 2021);
            int cType = RandomNumber(0, 10);
            string[] questionPage = { $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}Gauss7Contest.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}PascalContest.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}CayleyContest.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}FermatContest.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}FryerContest.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}GaloisContest.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}HypatiaContest.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}EuclidContest.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}CIMC.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}CSMC.pdf"};
            string[] solutionPage = { $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}Gauss7Solution.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}PascalSolution.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}CayleySolution.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}FermatSolution.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}FryerSolution.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}GaloisSolution.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}HypatiaSolution.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}EuclidSolution.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}CIMCSolution.pdf",
                $@"https://cemc.uwaterloo.ca/contests/past_contests/{year}/{year}CSMCSolution.pdf"};
            q.Navigate(questionPage[cType]);
            a.Navigate(solutionPage[cType]);
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

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            nextP();
        }
    }
}
