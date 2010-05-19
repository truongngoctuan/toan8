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
    public partial class Window1
    {

        public Window1()
        {
            this.InitializeComponent();
        }

        private void OnExit(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void image1_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thoát", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}