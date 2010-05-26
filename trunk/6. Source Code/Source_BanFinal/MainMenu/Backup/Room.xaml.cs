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

    }
}