using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for artWindow.xaml
    /// </summary>
    public partial class artWindow : Window
    {
        public static int fsM = 0;
        public static int erM = 0;
        public bool sendT = true;
        public artWindow()
        {
            InitializeComponent();
            givePoints();
        }

        public async void givePoints()
        {
            int r;
            // Every 50 Seconds Show Toast Notification
            while (sendT)
            {
                await Task.Delay(50000);
                r = new Random().Next(5, 31);

                // The Toast Notifications
                var notificationManager = new NotificationManager();

                notificationManager.Show(new NotificationContent
                {
                    Title = $"{r}+ Points",
                    Message = $"You earnt {r} points for spending time drawing!",
                    Type = NotificationType.Success,
                });
                globalVar.ttlPoints += r;
                globalVar gv = new globalVar();
                gv.saveAll();
            }
        }

        private void windowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sendT = false;
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
                this.mainBoard.EditingMode = InkCanvasEditingMode.Ink;
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

        private void clrChanged(object sender, RoutedEventArgs e)
        {
            mainBoard.DefaultDrawingAttributes.Color = clrPicker.SelectedColor;
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

        private void downloadBtn_Click(object sender, RoutedEventArgs e)
        {
            string downloadsFolder = globalVar.GetPath(KnownFolder.Downloads);
            MessageBox.Show("Saved To Downloads Folder!");
            Rect bounds = VisualTreeHelper.GetDescendantBounds(mainBoard);
            double dpi = 96d;

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, dpi, dpi, System.Windows.Media.PixelFormats.Default);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(mainBoard);
                dc.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }
            rtb.Render(dv);

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                pngEncoder.Save(ms);
                System.IO.File.WriteAllBytes(downloadsFolder + @"\download.png", ms.ToArray());
            }
        }

        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            if (mainBoard.Strokes.Count != 0)
            {
                while (mainBoard.Strokes.Count > 0)
                {
                    mainBoard.Strokes.RemoveAt(mainBoard.Strokes.Count - 1);
                }
            }
            else
            {
                // Else Do Nothing! 
            }
        }
    }
}
