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
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Arbi
{
    /// <summary>
    /// Interaction logic for geographyWindow.xaml
    /// </summary>
    public partial class geographyWindow : Window
    {
        dynamic jsonF = JsonConvert.DeserializeObject("{\r\n \"ad\": \"Andorra\",\r\n \"ae\": \"United Arab Emirates\",\r\n \"af\": \"Afghanistan\",\r\n \"ag\": \"Antigua and Barbuda\",\r\n \"ai\": \"Anguilla\",\r\n \"al\": \"Albania\",\r\n \"am\": \"Armenia\",\r\n \"ao\": \"Angola\",\r\n \"aq\": \"Antarctica\",\r\n \"ar\": \"Argentina\",\r\n \"as\": \"American Samoa\",\r\n \"at\": \"Austria\",\r\n \"au\": \"Australia\",\r\n \"aw\": \"Aruba\",\r\n \"ax\": \"Åland Islands\",\r\n \"az\": \"Azerbaijan\",\r\n \"ba\": \"Bosnia and Herzegovina\",\r\n \"bb\": \"Barbados\",\r\n \"bd\": \"Bangladesh\",\r\n \"be\": \"Belgium\",\r\n \"bf\": \"Burkina Faso\",\r\n \"bg\": \"Bulgaria\",\r\n \"bh\": \"Bahrain\",\r\n \"bi\": \"Burundi\",\r\n \"bj\": \"Benin\",\r\n \"bl\": \"Saint Barthélemy\",\r\n \"bm\": \"Bermuda\",\r\n \"bn\": \"Brunei\",\r\n \"bo\": \"Bolivia\",\r\n \"bq\": \"Caribbean Netherlands\",\r\n \"br\": \"Brazil\",\r\n \"bs\": \"Bahamas\",\r\n \"bt\": \"Bhutan\",\r\n \"bv\": \"Bouvet Island\",\r\n \"bw\": \"Botswana\",\r\n \"by\": \"Belarus\",\r\n \"bz\": \"Belize\",\r\n \"ca\": \"Canada\",\r\n \"cc\": \"Cocos(Keeling) Islands\",\r\n \"cd\": \"DR Congo\",\r\n \"cf\": \"Central African Republic\",\r\n \"cg\": \"Republic of the Congo\",\r\n \"ch\": \"Switzerland\",\r\n \"ci\": \"Côte d'Ivoire (Ivory Coast)\",\r\n \"ck\": \"Cook Islands\",\r\n \"cl\": \"Chile\",\r\n \"cm\": \"Cameroon\",\r\n \"cn\": \"China\",\r\n \"co\": \"Colombia\",\r\n \"cr\": \"Costa Rica\",\r\n \"cu\": \"Cuba\",\r\n \"cv\": \"Cape Verde\",\r\n \"cw\": \"Curaçao\",\r\n \"cx\": \"Christmas Island\",\r\n \"cy\": \"Cyprus\",\r\n \"cz\": \"Czechia\",\r\n \"de\": \"Germany\",\r\n \"dj\": \"Djibouti\",\r\n \"dk\": \"Denmark\",\r\n \"dm\": \"Dominica\",\r\n \"do\": \"Dominican Republic\",\r\n \"dz\": \"Algeria\",\r\n \"ec\": \"Ecuador\",\r\n \"ee\": \"Estonia\",\r\n \"eg\": \"Egypt\",\r\n \"eh\": \"Western Sahara\",\r\n \"er\": \"Eritrea\",\r\n \"es\": \"Spain\",\r\n \"et\": \"Ethiopia\",\r\n \"eu\": \"European Union\",\r\n \"fi\": \"Finland\",\r\n \"fj\": \"Fiji\",\r\n \"fk\": \"Falkland Islands\",\r\n \"fm\": \"Micronesia\",\r\n \"fo\": \"Faroe Islands\",\r\n \"fr\": \"France\",\r\n \"ga\": \"Gabon\",\r\n \"gb\": \"United Kingdom\",\r\n \"gb-eng\": \"England\",\r\n \"gb-nir\": \"Northern Ireland\",\r\n \"gb-sct\": \"Scotland\",\r\n \"gb-wls\": \"Wales\",\r\n \"gd\": \"Grenada\",\r\n \"ge\": \"Georgia\",\r\n \"gf\": \"French Guiana\",\r\n \"gg\": \"Guernsey\",\r\n \"gh\": \"Ghana\",\r\n \"gi\": \"Gibraltar\",\r\n \"gl\": \"Greenland\",\r\n \"gm\": \"Gambia\",\r\n \"gn\": \"Guinea\",\r\n \"gp\": \"Guadeloupe\",\r\n \"gq\": \"Equatorial Guinea\",\r\n \"gr\": \"Greece\",\r\n \"gs\": \"South Georgia\",\r\n \"gt\": \"Guatemala\",\r\n \"gu\": \"Guam\",\r\n \"gw\": \"Guinea-Bissau\",\r\n \"gy\": \"Guyana\",\r\n \"hk\": \"Hong Kong\",\r\n \"hm\": \"Heard Island and McDonald Islands\",\r\n \"hn\": \"Honduras\",\r\n \"hr\": \"Croatia\",\r\n \"ht\": \"Haiti\",\r\n \"hu\": \"Hungary\",\r\n \"id\": \"Indonesia\",\r\n \"ie\": \"Ireland\",\r\n \"il\": \"Israel\",\r\n \"im\": \"Isle of Man\",\r\n \"in\": \"India\",\r\n \"io\": \"British Indian Ocean Territory\",\r\n \"iq\": \"Iraq\",\r\n \"ir\": \"Iran\",\r\n \"is\": \"Iceland\",\r\n \"it\": \"Italy\",\r\n \"je\": \"Jersey\",\r\n \"jm\": \"Jamaica\",\r\n \"jo\": \"Jordan\",\r\n \"jp\": \"Japan\",\r\n \"ke\": \"Kenya\",\r\n \"kg\": \"Kyrgyzstan\",\r\n \"kh\": \"Cambodia\",\r\n \"ki\": \"Kiribati\",\r\n \"km\": \"Comoros\",\r\n \"kn\": \"Saint Kitts and Nevis\",\r\n \"kp\": \"North Korea\",\r\n \"kr\": \"South Korea\",\r\n \"kw\": \"Kuwait\",\r\n \"ky\": \"Cayman Islands\",\r\n \"kz\": \"Kazakhstan\",\r\n \"la\": \"Laos\",\r\n \"lb\": \"Lebanon\",\r\n \"lc\": \"Saint Lucia\",\r\n \"li\": \"Liechtenstein\",\r\n \"lk\": \"Sri Lanka\",\r\n \"lr\": \"Liberia\",\r\n \"ls\": \"Lesotho\",\r\n \"lt\": \"Lithuania\",\r\n \"lu\": \"Luxembourg\",\r\n \"lv\": \"Latvia\",\r\n \"ly\": \"Libya\",\r\n \"ma\": \"Morocco\",\r\n \"mc\": \"Monaco\",\r\n \"md\": \"Moldova\",\r\n \"me\": \"Montenegro\",\r\n \"mf\": \"Saint Martin\",\r\n \"mg\": \"Madagascar\",\r\n \"mh\": \"Marshall Islands\",\r\n \"mk\": \"North Macedonia\",\r\n \"ml\": \"Mali\",\r\n \"mm\": \"Myanmar\",\r\n \"mn\": \"Mongolia\",\r\n \"mo\": \"Macau\",\r\n \"mp\": \"Northern Mariana Islands\",\r\n \"mq\": \"Martinique\",\r\n \"mr\": \"Mauritania\",\r\n \"ms\": \"Montserrat\",\r\n \"mt\": \"Malta\",\r\n \"mu\": \"Mauritius\",\r\n \"mv\": \"Maldives\",\r\n \"mw\": \"Malawi\",\r\n \"mx\": \"Mexico\",\r\n \"my\": \"Malaysia\",\r\n \"mz\": \"Mozambique\",\r\n \"na\": \"Namibia\",\r\n \"nc\": \"New Caledonia\",\r\n \"ne\": \"Niger\",\r\n \"nf\": \"Norfolk Island\",\r\n \"ng\": \"Nigeria\",\r\n \"ni\": \"Nicaragua\",\r\n \"nl\": \"Netherlands\",\r\n \"no\": \"Norway\",\r\n \"np\": \"Nepal\",\r\n \"nr\": \"Nauru\",\r\n \"nu\": \"Niue\",\r\n \"nz\": \"New Zealand\",\r\n \"om\": \"Oman\",\r\n \"pa\": \"Panama\",\r\n \"pe\": \"Peru\",\r\n \"pf\": \"French Polynesia\",\r\n \"pg\": \"Papua New Guinea\",\r\n \"ph\": \"Philippines\",\r\n \"pk\": \"Pakistan\",\r\n \"pl\": \"Poland\",\r\n \"pm\": \"Saint Pierre and Miquelon\",\r\n \"pn\": \"Pitcairn Islands\",\r\n \"pr\": \"Puerto Rico\",\r\n \"ps\": \"Palestine\",\r\n \"pt\": \"Portugal\",\r\n \"pw\": \"Palau\",\r\n \"py\": \"Paraguay\",\r\n \"qa\": \"Qatar\",\r\n \"re\": \"Réunion\",\r\n \"ro\": \"Romania\",\r\n \"rs\": \"Serbia\",\r\n \"ru\": \"Russia\",\r\n \"rw\": \"Rwanda\",\r\n \"sa\": \"Saudi Arabia\",\r\n \"sb\": \"Solomon Islands\",\r\n \"sc\": \"Seychelles\",\r\n \"sd\": \"Sudan\",\r\n \"se\": \"Sweden\",\r\n \"sg\": \"Singapore\",\r\n \"sh\": \"Saint Helena,\r\n Ascension and Tristan da Cunha\",\r\n \"si\": \"Slovenia\",\r\n \"sj\": \"Svalbard and Jan Mayen\",\r\n \"sk\": \"Slovakia\",\r\n \"sl\": \"Sierra Leone\",\r\n \"sm\": \"San Marino\",\r\n \"sn\": \"Senegal\",\r\n \"so\": \"Somalia\",\r\n \"sr\": \"Suriname\",\r\n \"ss\": \"South Sudan\",\r\n \"st\": \"São Tomé and Príncipe\",\r\n \"sv\": \"El Salvador\",\r\n \"sx\": \"Sint Maarten\",\r\n \"sy\": \"Syria\",\r\n \"sz\": \"Eswatini (Swaziland)\",\r\n \"tc\": \"Turks and Caicos Islands\",\r\n \"td\": \"Chad\",\r\n \"tf\": \"French Southern and Antarctic Lands\",\r\n \"tg\": \"Togo\",\r\n \"th\": \"Thailand\",\r\n \"tj\": \"Tajikistan\",\r\n \"tk\": \"Tokelau\",\r\n \"tl\": \"Timor-Leste\",\r\n \"tm\": \"Turkmenistan\",\r\n \"tn\": \"Tunisia\",\r\n \"to\": \"Tonga\",\r\n \"tr\": \"Turkey\",\r\n \"tt\": \"Trinidad and Tobago\",\r\n \"tv\": \"Tuvalu\",\r\n \"tw\": \"Taiwan\",\r\n \"tz\": \"Tanzania\",\r\n \"ua\": \"Ukraine\",\r\n \"ug\": \"Uganda\",\r\n \"um\": \"United States Minor Outlying Islands\",\r\n \"un\": \"United Nations\",\r\n \"us\": \"United States\",\r\n \"us-ak\": \"Alaska\",\r\n \"us-al\": \"Alabama\",\r\n \"us-ar\": \"Arkansas\",\r\n \"us-az\": \"Arizona\",\r\n \"us-ca\": \"California\",\r\n \"us-co\": \"Colorado\",\r\n \"us-ct\": \"Connecticut\",\r\n \"us-de\": \"Delaware\",\r\n \"us-fl\": \"Florida\",\r\n \"us-ga\": \"Georgia\",\r\n \"us-hi\": \"Hawaii\",\r\n \"us-ia\": \"Iowa\",\r\n \"us-id\": \"Idaho\",\r\n \"us-il\": \"Illinois\",\r\n \"us-in\": \"Indiana\",\r\n \"us-ks\": \"Kansas\",\r\n \"us-ky\": \"Kentucky\",\r\n \"us-la\": \"Louisiana\",\r\n \"us-ma\": \"Massachusetts\",\r\n \"us-md\": \"Maryland\",\r\n \"us-me\": \"Maine\",\r\n \"us-mi\": \"Michigan\",\r\n \"us-mn\": \"Minnesota\",\r\n \"us-mo\": \"Missouri\",\r\n \"us-ms\": \"Mississippi\",\r\n \"us-mt\": \"Montana\",\r\n \"us-nc\": \"North Carolina\",\r\n \"us-nd\": \"North Dakota\",\r\n \"us-ne\": \"Nebraska\",\r\n \"us-nh\": \"New Hampshire\",\r\n \"us-nj\": \"New Jersey\",\r\n \"us-nm\": \"New Mexico\",\r\n \"us-nv\": \"Nevada\",\r\n \"us-ny\": \"New York\",\r\n \"us-oh\": \"Ohio\",\r\n \"us-ok\": \"Oklahoma\",\r\n \"us-or\": \"Oregon\",\r\n \"us-pa\": \"Pennsylvania\",\r\n \"us-ri\": \"Rhode Island\",\r\n \"us-sc\": \"South Carolina\",\r\n \"us-sd\": \"South Dakota\",\r\n \"us-tn\": \"Tennessee\",\r\n \"us-tx\": \"Texas\",\r\n \"us-ut\": \"Utah\",\r\n \"us-va\": \"Virginia\",\r\n \"us-vt\": \"Vermont\",\r\n \"us-wa\": \"Washington\",\r\n \"us-wi\": \"Wisconsin\",\r\n \"us-wv\": \"West Virginia\",\r\n \"us-wy\": \"Wyoming\",\r\n \"uy\": \"Uruguay\",\r\n \"uz\": \"Uzbekistan\",\r\n \"va\": \"Vatican City (Holy See)\",\r\n \"vc\": \"Saint Vincent and the Grenadines\",\r\n \"ve\": \"Venezuela\",\r\n \"vg\": \"British Virgin Islands\",\r\n \"vi\": \"United States Virgin Islands\",\r\n \"vn\": \"Vietnam\",\r\n \"vu\": \"Vanuatu\",\r\n \"wf\": \"Wallis and Futuna\",\r\n \"ws\": \"Samoa\",\r\n \"xk\": \"Kosovo\",\r\n \"ye\": \"Yemen\",\r\n \"yt\": \"Mayotte\",\r\n \"za\": \"South Africa\",\r\n \"zm\": \"Zambia\",\r\n \"zw\": \"Zimbabwe\" }");
        public static string[] codes = {"ad", "ae", "af", "ag", "ai", "al", "am", "ao", "aq", "ar", "as", "at", "au", "aw", "ax", "az", "ba", "bb", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bl", "bm", "bn", "bo", "bq", "br", "bs", "bt", "bv", "bw", "by", "bz", "ca", "cc", "cd", "cf", "cf", "cg", "cg", "ch", "ci", "ck", "cl", "cm", "cn", "co", "cr", "cu", "cv", "cw", "cy", "cz", "de", "dj", "dk", "dm", "do", "dz", "ec", "ee", "eg", "eh", "er", "es", "et", "eu", "fi", "fj", "fk", "fm", "fo", "fr", "ga", "gb", "gb-eng", "gb-nir", "gb-sct", "gb-wls", "gd", "ge", "gf", "gg", "gh", "gi", "gl", "gm", "gn", "gp", "gq", "gr", "gs", "gt", "gu", "gw", "gy", "hk", "hm", "hn", "hr", "ht", "hu", "hu", "id", "ie", "il", "im", "in", "io", "iq", "ir", "is", "it", "je", "jm", "jo", "jp", "ke", "kg", "kh", "ki", "km", "kn", "kp", "kr", "kw", "ky", "kz", "la", "lb", "lc", "li", "lk", "lr", "ls", "lt", "lu", "lv", "ly", "ma", "mc", "md", "me", "mf", "mg", "mh", "mk", "ml", "mm", "mn", "mo", "mp", "mq", "mr", "ms", "mt", "mu", "mv", "mw", "mx", "my", "mz", "na", "nc", "ne", "nf", "ng", "ni", "nl", "no", "np", "nr", "nu", "nz", "om", "pa", "pe", "pf", "pg", "ph", "pk", "pl", "pm", "pn", "pr", "ps", "pt", "pw", "py", "qa", "re", "ro", "rs", "ru", "rw", "sa", "sb", "sc", "sd", "se", "sg", "sh", "si", "sj", "sk", "sl", "sm", "sn", "so", "sr", "ss", "st", "sv", "sx", "sy", "sz", "tc", "td", "tf", "tg", "th", "tj", "tk", "tl", "tm", "tn", "to", "tr", "tt", "tv", "tw", "tz", "ua", "ug", "um", "us", "uy", "uz", "va", "vc", "ve", "vg", "vi", "vn", "vu", "wf", "ws", "xk", "ye", "yt", "za", "zm", "zw" };
        public int chances = 3;
        public int i = 0;
        public int currentScore = 0;
        Stopwatch sw = new Stopwatch();

        public geographyWindow()
        {
            InitializeComponent();
            sw.Start();
            nextF();
        }

        private void lostFocusKeyboard(object sender, KeyboardFocusChangedEventArgs e)
        {
            setTxtBox(sender);
        }

        public void setTxtBox(object senda)
        {
            TextBox txtBox = senda as TextBox;
            if (awnsTxt.Text == "Answer Here...")
                awnsTxt.Text = string.Empty;
        }

        public void nextF()
        {
            i = RandomNumber(1, 257);
            string part1 = "https://";
            string part2 = $"flagcdn.com/{codes[i]}.svg";
            svgViewbox.Source = new Uri(part1 + part2);


        }
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (getFromCode(codes[i]).ToLower() == awnsTxt.Text.Trim().ToLower())
            {
                nextF();
                setTxtBox(sender);
                currentScore += 1;
                scoreNumTxt.Text = currentScore.ToString();
            }
            else
            {
                globalVar.daScore = currentScore;
                globalVar.daPointsEarned = currentScore * 6;
                globalVar.daTime = sw.ElapsedMilliseconds / 1000; 
                finalScore fs = new finalScore();
                fs.Show();
                Close();
            }
        }

        public string getFromCode(string code)
        {
            return Convert.ToString(jsonF[code]);
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