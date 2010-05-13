using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace ColorSwatch
{
    /// <summary>
    /// USER CONTROL:
    /// Room is defined as a User Control to make it easier to send/receive events from Swatches and to the main window.
    /// </summary>
    public partial class Room
    {
        // Swatch selected
        FrameworkElement currentSwatch;

        /// <summary>
        /// Exposes the method OnResetImage as a source to Data Binding in Expression Blend.
        /// </summary>
        public DelegateCommand ResetImage
        {
            get { return new DelegateCommand(delegate() { OnResetImage(); }); }
        }

        public Room()
        {
            this.InitializeComponent();

            // Registers the events that can be accessed using Expression Blend, under Triggers in the Interaction panel.
            EventManager.RegisterClassHandler(typeof(Swatch), Swatch.OpenSwatchEvent, new RoutedEventHandler(this.OnOpenSwatch));
            EventManager.RegisterClassHandler(typeof(Swatch), Swatch.ColorSelectionChangedEvent, new RoutedEventHandler(this.OnColorSelectionChanged));
        }

        /// <summary>
        /// The trigger for this method is defined inside the Swatch user control.
        /// </summary>
        public void OnOpenSwatch(object o, RoutedEventArgs e)
        {
            if (currentSwatch != null)
            {
                Storyboard closeSwatchAnimation = (Storyboard)currentSwatch.FindResource("closeSwatch");
                closeSwatchAnimation.Begin(currentSwatch);
            }
            currentSwatch = (FrameworkElement)e.Source;
            Storyboard closeOpenSwatchesAnimation = (Storyboard)this.Resources["closeAll"];
            closeOpenSwatchesAnimation.Begin(this);
            Storyboard openSwatchAnimation = (Storyboard)this.Resources["open" + currentSwatch.Name];
            openSwatchAnimation.Begin(this);
        }

        private void OnResetImage()
        {
            WallBrush.Fill = Brushes.White;
            FrameBrush.Fill = Brushes.White;
            FloorBrush.Fill = Brushes.White;
            BathtubBrush.Fill = Brushes.White;
            TowelBrush.Fill = Brushes.White;
        }

        /// <summary>
        /// Launches the browser from the application.
        /// </summary>
        private void OnLaunchBrowser(object sender, RoutedEventArgs e)
        {
            Process.Start("http://pro.corbis.com/");
        }

        public Frame layframe()
        {
            return dangnhap;
        }

        private void OnColorSelectionChanged(object o, RoutedEventArgs e)
        {
            ColorSelectionEventArgs args = e as ColorSelectionEventArgs;
            if (currentSwatch != null && args != null)
            {
                Color newColor = (Color)ColorConverter.ConvertFromString(args.Color);
                SolidColorBrush newBrush = new SolidColorBrush(newColor);
                switch (currentSwatch.Name)
                {
                    case "Wall":
                        WallBrush.Fill = newBrush;
                     
                     
                        break;
                    case "Frame":
                        FrameBrush.Fill = newBrush;
                        break;
                    case "Floor":
                        FloorBrush.Fill = newBrush;
                        break;
                    case "Bathtub":
                        BathtubBrush.Fill = newBrush;
                        break;
                    case "Towel":
                        TowelBrush.Fill = newBrush;
                        break;
                }
            }
        }


        private void button1_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Uri uri = new Uri("images/login.jpg", UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            concoc.Source = imgSource;
        }

        private void button1_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Uri uri = new Uri("Assets/tacke.png", UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            concoc.Source = imgSource;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            dangnhap.Visibility = Visibility.Visible;
        }

        private void button3_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Uri uri = new Uri("images/hinhhoc_nen.png", UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            concoc.Source = imgSource;
        }

        private void button3_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Uri uri = new Uri("Assets/tacke.png", UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            concoc.Source = imgSource;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            
            ManHinh.HinhHoc hh = new ColorSwatch.ManHinh.HinhHoc();
            hh.Show();

           
            
        }

        private void button2_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Uri uri = new Uri("images/daiso_nên.png", UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            concoc.Source = imgSource;
        }

        private void button2_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Uri uri = new Uri("Assets/tacke.png", UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            concoc.Source = imgSource;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //ManHinh.Dáio ds = new ColorSwatch.ManHinh.Dáio();
            //ds.Show();
            HocDaiSo ds = new HocDaiSo();
            ds.Show();
        }

        private void button4_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Uri uri = new Uri("images/6EntertainmentVector.png", UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            concoc.Source = imgSource;
        }

        private void button4_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Uri uri = new Uri("Assets/tacke.png", UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            concoc.Source = imgSource;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ManHinh.GiaiTri gt = new ColorSwatch.ManHinh.GiaiTri();
            gt.Show();
        }

        private void button5_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Uri uri = new Uri("images/trogiup.jpg", UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            concoc.Source = imgSource;
        }

        private void button5_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Uri uri = new Uri("Assets/tacke.png", UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            concoc.Source = imgSource;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}