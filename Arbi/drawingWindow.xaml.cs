using System;
using System.Collections.Generic;
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
    /// Interaction logic for drawingWindow.xaml
    /// </summary>
    public partial class drawingWindow : Window
    {
        public static int fsM = 0;
        public static int erM = 0;
        public drawingWindow()
        {
            InitializeComponent();
        }

        private void fullScrenBtn(object sender, RoutedEventArgs e)
        {
            fullScrnIcn.Source = new Uri("pack://application:,,,/assets/viewB/minm.svg");
            if (fsM == 0)
            {
                this.WindowState = WindowState.Maximized;
                fullScrnIcn.Source = new Uri("pack://application:,,,/assets/viewB/minm.svg");
                fsM = 1;
            }
            else if (fsM == 1)
            {
                this.WindowState = WindowState.Normal;
                fullScrnIcn.Source = new Uri("pack://application:,,,/assets/viewB/full.svg");
                fsM = 0;
            }
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void applyBtn_Click(object sender, RoutedEventArgs e)
        {
            double newSize = Convert.ToDouble(brushSizeTxt.Text);
            mainBoard.DefaultDrawingAttributes.Width = newSize;
            mainBoard.DefaultDrawingAttributes.Height = newSize;
        }

        private void paintBtn_Click(object sender, RoutedEventArgs e)
        {
            mainBoard.DefaultDrawingAttributes.IsHighlighter = false;
            this.mainBoard.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void highlightBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mainBoard.DefaultDrawingAttributes.IsHighlighter)
            {
                mainBoard.DefaultDrawingAttributes.IsHighlighter = false;
            }
            else
            {
                mainBoard.DefaultDrawingAttributes.IsHighlighter = true;
            }
        }

        private void eraseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (erM == 0)
            {
                mainBoard.EditingMode = InkCanvasEditingMode.EraseByStroke;
                erM = 1;
            }
            else if (erM == 1)
            {
                mainBoard.DefaultDrawingAttributes.IsHighlighter = false;
                mainBoard.EditingMode = InkCanvasEditingMode.Ink;
                erM = 0; 
            }
        }

        private void selectBtn_Click(object sender, RoutedEventArgs e)
        {
            mainBoard.EditingMode = InkCanvasEditingMode.Select;
        }

        private void undoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mainBoard.Strokes.Count > 0)
            {
                mainBoard.Strokes.RemoveAt(mainBoard.Strokes.Count - 1);
            }
            else
            {
                // Else Do Nothing. Lmfao.
            }
        }

        // Hex to Media.Color
        public Color ConvertStringToColor(String hex)
        {
            //remove the # at the front
            hex = hex.Replace("#", "");
            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;
            int start = 0;
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }
            //convert RGB characters to bytes
            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(a, r, g, b);
        }
    }
}
