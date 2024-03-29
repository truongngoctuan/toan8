using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace ColorSwatch
{
    #region Rounted Event

    public class ColorSelectionEventArgs : RoutedEventArgs
    {
        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public ColorSelectionEventArgs(RoutedEvent id, string color)
        {
            base.RoutedEvent = id;
            this.Color = color;
        }
    }

    #endregion

    /// <summary>
    /// USER CONTROL:
    /// Swatch is defined as a User Control to make it easier to send/receive events to Room.
    /// It's also easier to re-use it, since each Color Swatch is an instance of the same User Control.
    /// </summary>
    public partial class Swatch
    {
        ListBox previousListBox;

        // Exposes the events that can be accessed using Expression Blend, under Triggers in the Interaction panel.
        public static readonly RoutedEvent OpenSwatchEvent = EventManager.RegisterRoutedEvent("OpenSwatch", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Swatch));
        public static readonly RoutedEvent ColorSelectionChangedEvent = EventManager.RegisterRoutedEvent("ColorSelectionChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Swatch));

        public Swatch()
        {
            this.InitializeComponent();
        }

        private void OnOpenSwatch(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            base.RaiseEvent(new RoutedEventArgs(Swatch.OpenSwatchEvent, this));
        }

        /// <summary>
        /// Triggered when a new color is selected. 
        /// </summary>
        private void OnListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;

            if (e.AddedItems.Count != 0)
            {
                // Unselects any previous item of the list boxes.
                if (previousListBox != null && previousListBox != list)
                {
                    previousListBox.SelectedIndex = -1;
                }
                previousListBox = list;

                // Sends the event up to Room user control, and passes the code of the selected color in the format "#AARRGGBB".
                base.RaiseEvent(new ColorSelectionEventArgs(Swatch.ColorSelectionChangedEvent, ((System.Xml.XmlElement)e.AddedItems[0]).InnerXml));
            }
        }

        #region Swatch Z-Index

        private void BringSwatchToFront(object sender, System.Windows.Input.MouseEventArgs e)
        {
            FrameworkElement swatch = (FrameworkElement)sender;
            Panel.SetZIndex(swatch, 1);
            Storyboard bringSwatchToFrontAnimation = (Storyboard)this.Resources["toFront_" + swatch.Name];
            bringSwatchToFrontAnimation.Begin(this);
        }

        private void SendSwatchToBack(object sender, System.Windows.Input.MouseEventArgs e)
        {
            FrameworkElement swatch = (FrameworkElement)sender;
            Panel.SetZIndex(swatch, 0);
        }

        #endregion

    }
}