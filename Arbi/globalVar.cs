using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Arbi
{
    class globalVar
    {
        // Global Variables; Used throughout the app!
        public static int daScore { get; set; }
        public static long daTime { get; set; }
        public static int daPointsEarned { get; set; }
        public static int ttlPoints { get; set; }

        // Saves the total points earned!
        public void saveAll()
        {
            string folder = Environment.CurrentDirectory;
            string fileName = @"\data.arbi";
            string fullPath = folder + fileName;
            FileInfo f1 = new FileInfo(fullPath);
            StreamWriter sw = f1.CreateText();
            sw.WriteLine(ttlPoints);
            sw.Close();
        }

        // Loads the total points earned throughout the app!
        public void openAll()
        {
            string folder = Environment.CurrentDirectory;
            string fileName = @"\data.arbi";
            string fullPath = folder + fileName;
            FileInfo f1 = new FileInfo(fullPath);
            StreamReader sr = f1.OpenText();
            while (sr.Peek() > -1)
            {
                ttlPoints = int.Parse(sr.ReadLine());
            }
        }
    }
}
