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
    /// Interaction logic for readingLvl2.xaml
    /// </summary>
    public partial class readingLvl2 : Window
    {
        Stopwatch sw = new Stopwatch();
        int i = 0;
        int score = 0;
        public readingLvl2()
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
            switch (i)
            {
                case 1:
                    mainBook.Inlines.Clear();
                    mainBook.Inlines.Add(@"Frederick Douglass (1818-1895) was born into slavery in Maryland.
As an adult, he escaped into freedom. He became a writer, orator and
advocate for the abolition of slavery. In 1845, 16 years before the start
of the Civil War, Douglass published his autobiography, Narrative of
the Life of Frederick Douglass, An American Slave. In this passage
from Chapter VIII, Douglass is a 10 year old slave.



In a very short time after I went to live at Baltimore, my old master’s youngest son
Richard died; and in about three years and six months after his death, my old master,
Captain Anthony, died, leaving only his son, Andrew, and daughter, Lucretia, to share his
estate. He died while on a visit to see his daughter at Hillsborough. Cut off thus unexpectedly, he left no will as to the disposal of his property. It was therefore necessary to have
a valuation of the property, that it might be equally divided between Mrs. Lucretia and
Master Andrew. I was immediately sent for, to be valued with the other property. Here
again my feelings rose up in detestation of slavery. I had now a new conception of my
degraded condition. Prior to this, I had become, if not insensible to my lot, at least partly
so. I left Baltimore with a young heart overborne with sadness, and a soul full of apprehension. I took passage with Captain Rowe, in the schooner Wild Cat, and, after a sail of about
twenty-four hours, I found myself near the place of my birth. I had now been absent from
it almost, if not quite, fi ve years. I, however, remembered the place very well. I was only
about five years old when I left it, to go and live with my old master on Colonel Lloyd’s
plantation; so that I was now between ten and eleven years old.

We were all ranked together at the valuation. Men and women, old and young, married
and single, were ranked with horses, sheep, and swine. There were horses and men, cattle
and women, pigs and children, all holding the same rank in the scale of being, and were all
subjected to the same narrow examination. Silvery-headed age and sprightly youth, maids
and matrons, had to undergo the same indelicate inspection. At this moment, I saw more
clearly than ever the brutalizing effects of slavery upon both slave and slaveholder. ");
                    q1.Content = "What's the first name of the old master's \nyoungest son?";
                    q2.Content = "When was Frederick Douglass born?";
                    q3.Content = "When did Frederick Douglass die?";
                    break;
                case 2:
                    mainBook.Inlines.Clear();
                    mainBook.Inlines.Add(@"Willa Cather’s 1910 novel, O! Pioneers, follows a Swedish family of farmers in Nebraska.
In this passage, John Bergson is dying and worries about what will become of his wife and
young children. Alexandra is the oldest Bergson child. 


Alexandra, her father often said to himself, was like her grandfather; which was his
way of saying that she was intelligent. John Bergson’s father had been a shipbuilder, a
man of considerable force and of some fortune. Late in life he married a second time, a
Stockholm woman of questionable character, much younger than he, who goaded him into
every sort of extravagance. On the shipbuilder’s part, this marriage was an infatuation,
the despairing folly of a powerful man who cannot bear to grow old. In a few years his
unprincipled wife warped the probity of a lifetime. He speculated, lost his own fortune
and funds entrusted to him by poor seafaring men, and died disgraced, leaving his
children nothing. But when all was said, he had come up from the sea himself, had built
up a proud little business with no capital but his own skill and foresight, and had proved
himself a man. In his daughter, John Bergson recognized the strength of will, and the
simple direct way of thinking things out, that had characterized his father in his better
days. He would much rather, of course, have seen this likeness in one of his sons, but it
was not a question of choice. As he lay there day after day he had to accept the situation
as it was, and to be thankful that there was one among his children to whom he could
entrust the future of his family and the possibilities of his hard-won land.");
                    q1.Content = "What is the first name of the oldest Bergsons child?";
                    q2.Content = "What was John Bergson's fathers job in the past?";
                    q3.Content = "Where does the Bergoson's family live?";
                    break;
                case 3:
                    mainBook.Inlines.Clear();
                    mainBook.Inlines.Add(@"Edgar Allan Poe wrote “The Tell-Tale Heart” in 1843. It is one of his most famous short stories.
Below are the opening paragraphs of the story.


TRUE! - nervous - very, very dreadfully nervous I had been and am; but why will you say that
I am mad? The disease had sharpened my senses - not destroyed - not dulled them. Above all was
the sense of hearing acute. I heard all things in the heaven and in the earth. I heard many things
in hell. How, then, am I mad? Hearken! and observe how healthily - how calmly I can tell you the
whole story.

It is impossible to say how first the idea entered my brain; but once conceived, it haunted me
day and night. Object there was none. Passion there was none. I loved the old man. He had never
wronged me. He had never given me insult. For his gold I had no desire. I think it was his eye!
yes, it was this! He had the eye of a vulture - a pale blue eye, with a film over it. Whenever it fell
upon me, my blood ran cold; and so by degrees - very gradually - I made up my mind to take the
life of the old man, and thus rid myself of the eye forever.");
                    q1.Content = @"Who wrote “The Tell-Tale Heart”? (First Name Only)";
                    q2.Content = "When was “The Tell-Tale Heart” published?";
                    q3.Content = "How, then, am I mad? _____! and observe how healthily";
                    break;
            }
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            switch (i)
            {
                case 1:
                    if (awnsTxt.Text.Trim().ToLower() == "richard")
                    {
                        score += 1;
                    }
                    if (awnsTxt2.Text.Trim().ToLower() == "1818")
                    {
                        score += 1;
                    }
                    if (awnsTxt3.Text.Trim().ToLower() == "1895")
                    {
                        score += 1;
                    }
                    break;
                case 2:
                    if (awnsTxt.Text.Trim().ToLower() == "alexandra")
                    {
                        score += 1;
                    }
                    if (awnsTxt2.Text.Trim().ToLower() == "shipbuilder")
                    {
                        score += 1;
                    }
                    if (awnsTxt3.Text.Trim().ToLower() == "nebraska" || awnsTxt3.Text.Trim().ToLower() == "sweden")
                    {
                        score += 1;
                    }
                    break;
                case 3:
                    if (awnsTxt.Text.Trim().ToLower() == "edgar")
                    {
                        score += 1;
                    }
                    if (awnsTxt2.Text.Trim().ToLower() == "1843")
                    {
                        score += 1;
                    }
                    if (awnsTxt3.Text.Trim().ToLower() == "hearken")
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
