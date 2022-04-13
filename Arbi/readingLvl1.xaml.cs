using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for readingLvl1.xaml
    /// </summary>
    public partial class readingLvl1 : Window
    {
        Stopwatch sw = new Stopwatch();
        int i = 0;
        int score = 0;
        public readingLvl1()
        {
            InitializeComponent();
            sw.Start();
            generateRead();
        }

        private void lostFocusKeyboard(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (awnsTxt.Text == "Answer Here...")
                awnsTxt.Text = string.Empty;
        }

        private void lostFocusKeyboard1(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (awnsTxt2.Text == "Answer Here...")
                awnsTxt2.Text = string.Empty;
        }

        private void lostFocusKeyboard2(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (awnsTxt3.Text == "Answer Here...")
                awnsTxt3.Text = string.Empty;
        }

        public void generateRead()
        {
            i = RandomNumber(1, 4);
            switch(i)
            {
                case 1:
                    mainBook.Inlines.Clear();
                    mainBook.Inlines.Add(@"Where on Earth are you? Navigators use lines of latitude and lines of
longitude to locate places.Lines of latitude run east and west(sideways, or
horizontally) around Earth.Lines of longitude run north and south(up and down,
or vertically) around Earth.These lines create kind of an imaginary graph paper
on the Earth.They make it possible to find an absolute(exact) location on Earth.
They even allow us to give an absolute location to a place out in the middle of
the ocean.

                    Lines of latitude tell us how far north or south of the equator we are.
Sailors have used primitive navigation tools, like astrolabes, since the 1400's.
Using such tools, they have been able to approximate their distance from the
equator.Although their instruments may not have been the high quality we have
now, they were incredibly accurate for their time.
 Lines of longitude tell us how far east or west of the prime meridian we
are.Sailors constantly looked for new ways to increase their navigation skills.
Still, it was another 300 years before they were able to measure degrees of
longitude.They would have been very envious of the technololgy available to
us today.

                   When we use lines of latitude and longitude together, we can get a very
precise location.The lines that cross each other nearest to the point we want to
identify tell us its absolute location.We use the coordinates for that point as its
address.Many maps today include degrees of latitude and longitude on top of the
continents of the world.

                  Another tool that has helped us navigate is the magnetic compass.The
magnetic compass was developed in China.Sailors brought it from China to Europe
in the 1400’s during their regular trade expeditions to Asia.The astrolabe has
also proven useful.It uses the sun and stars to find an approximate location.This
technology made worldwide travel easier and encouraged
more exploration.");
                    q1.Content = "What line tell us how far north or south of \nthe equator we are?";
                    q2.Content = "Where was the magnetic compass developed?";
                    q3.Content = "Approximately when did magnetic compass first \ncome to China?";
                    break;
                case 2:
                    mainBook.Inlines.Clear();
                    mainBook.Inlines.Add(@"A symbol is something that stands as a reminder of something else. The United States has many
national symbols that help bring the local and regional communities together as a whole nation.By
having some traditional symbols that people throughout our nation share, we are able to connect with
each other and share the pride we have in our country.

                    The United States flag is a symbol that is easy for all Americans to recognize.It stands for our
country, with one star for each of our 50 states, and 13 stripes to represent each of our original 13
colonies.Those colonies later became states, and 37 more states joined them to make up our country.
The American Bald Eagle is our national bird.It was
chosen because it is so independent and free.Choosing such
a bird to represent our nation tells everyone that our country
values freedom and the courage to be independent.
The Statue of Liberty is another very famous American
symbol.It was a gift to the people of America from the
people of France in 1885.It represented not only the spirit of
friendship between our countries, but also the shared vision
for liberty, which is a synonym for freedom.

                   America’s symbols unite people from many different states
and help them feel like Americans instead of just citizens of
their own states.We all pledge allegiance to the same flag. We
celebrate national holidays. Our American spirit shows more
than ever when we unite in times of crisis, reaching out to
help fellow Americans, or foreigners in need.");
                    q1.Content = "When did the people of France give America the \nstatue of liberty?";
                    q2.Content = "How many stripes does the American flag have?";
                    q3.Content = "What is the synonym of liberty that was mentioned \nin the paragraph?";
                    break;
                case 3:
                    mainBook.Inlines.Clear();
                    mainBook.Inlines.Add(@"Natural resources are things that we use that come
from Earth. Our natural resources are limited. This
means that they will not last forever. Some are renewable,
like when you plant a new tree when you cut one down.
Others are not renewable, like when you dig coal out of
the ground. Once it is used, it is gone.

                    People are aware of the fact that Earth’s natural
resources are limited, and can do things to help conserve
those resources. When you try to conserve a natural
resource, you try to use less of it so it does not get used up
so fast. One way that people conserve fuel, like gasoline,
is by riding a bicycle or walking when the distance is
short instead of driving everywhere.

                    Water is a very important natural resource because we
all need it to stay alive. We can conserve water by making
sure that our pipes and faucets do not leak. We can also
conserve water by making smart choices, like only using
the dishwasher or washing machine when they are full.");
                    q1.Content = "Coal is not a renewable natural resource (true/false)?";
                    q2.Content = "Plants are not renewable (true/false)?";
                    q3.Content = "What is the major natural resource you can save by \nriding a bike instead of driving?";
                    break;
            }
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            switch(i)
            {
                case 1:
                    if(awnsTxt.Text.Trim().ToLower() == "latitude")
                    {
                        score += 1;
                    }
                    if (awnsTxt2.Text.Trim().ToLower() == "china")
                    {
                        score += 1;
                    }
                    if (awnsTxt3.Text.Trim().ToLower() == "1400")
                    {
                        score += 1;
                    }
                    break;
                case 2:
                    if (awnsTxt.Text.Trim().ToLower() == "1885")
                    {
                        score += 1;
                    }
                    if (awnsTxt2.Text.Trim().ToLower() == "13" || awnsTxt2.Text.Trim().ToLower() == "thirteen")
                    {
                        score += 1;
                    }
                    if (awnsTxt3.Text.Trim().ToLower() == "freedom")
                    {
                        score += 1;
                    }
                    break;
                case 3:
                    if (awnsTxt.Text.Trim().ToLower() == "true")
                    {
                        score += 1;
                    }
                    if (awnsTxt2.Text.Trim().ToLower() == "false")
                    {
                        score += 1;
                    }
                    if (awnsTxt3.Text.Trim().ToLower() == "gasoline" || awnsTxt3.Text.Trim().ToLower() == "gas")
                    {
                        score += 1;
                    }
                    break;
            };
            sw.Stop();
            globalVar.daPointsEarned = score * 5;
            globalVar.daScore = score;
            globalVar.daTime = sw.ElapsedMilliseconds / 1000;
            finalScore fs = new finalScore();
            fs.Show();
            Close();
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
