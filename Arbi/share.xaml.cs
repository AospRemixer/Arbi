using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Interaction logic for share.xaml
    /// </summary>
    public partial class share : Page
    {
        public share()
        {
            InitializeComponent();
        }

        private void tweet_click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/intent/tweet?text=Hello%20everyone!%20My%20Arbi%20score%20is%20x" + globalVar.ttlPoints.ToString());
        }

        private void discord_click(object sender, RoutedEventArgs e)
        {
            if (awnsTxt.Text == string.Empty)
            {
                MessageBox.Show("Please Type a Display Name!");
            }
            else if (awnsTxt.Text == "Display Name...")
            {
                MessageBox.Show("Please Type a Display Name!");
            }
            else
            {
                string token = "https://discord.com/api/webhooks/964688868953698304/i5A6WDDqepHnxCiBrpfj9_FeZNAT4HIXW56HXceSv3ni3rTTsPfLo8WryZoRWrj2T24G";

                WebRequest wr = (HttpWebRequest)WebRequest.Create(token);

                wr.ContentType = "application/json";

                wr.Method = "POST";

                using (var sw = new StreamWriter(wr.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        username = "Arbi Share Bot",
                        embeds = new[]
                        {
                        new
                        {
                            description = awnsTxt.Text.Trim() + " has " + globalVar.ttlPoints.ToString() + " Arbi Points!",
                            title = awnsTxt.Text.Trim(),
                            color = "8464385"
                        }
                    }
                    });

                    sw.Write(json);
                }

                var response = (HttpWebResponse)wr.GetResponse();
                MessageBox.Show("Our Arbi Score Bot will now display your score on the \nArbi Discord Server! Join the server to check it out!", "Done!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void lostFocusKeyboard(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (awnsTxt.Text == "Display Name...")
                awnsTxt.Text = string.Empty;
        }

        private void joinDiscord_click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://discord.gg/FjVMakcGN5");
        }
    }
}
