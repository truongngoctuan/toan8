using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace ColorSwatch
{
    public partial class Window1
    {
        public static Frame frameFormNguoiDung;
        public static Frame frameGiaoDienChinh;
        public static Grid gridLoiChao;
        public static Label lbXinChao;
        //Label lbThoat;
        Button btThoat;
        public Window1()
        {
            this.InitializeComponent();

            frameGiaoDienChinh = new Frame();
            frameGiaoDienChinh.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            //frameGiaoDienChinh.Source = new Uri("Room.xaml", UriKind.Relative);
            gridGiaoDienChinh.Children.Add(frameGiaoDienChinh);

            frameFormNguoiDung = new Frame();
            frameFormNguoiDung.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            frameFormNguoiDung.Source = new Uri("FormNguoiDung.xaml", UriKind.Relative);
            gridGiaoDienChinh.Children.Add(frameFormNguoiDung);

            gridLoiChao = new Grid();
            gridLoiChao.HorizontalAlignment = HorizontalAlignment.Right;
            gridLoiChao.VerticalAlignment = VerticalAlignment.Top;
            gridLoiChao.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
            gridLoiChao.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });


            lbXinChao = new Label();
            lbXinChao.Content = "Chào bạn ";
            lbXinChao.HorizontalAlignment = HorizontalAlignment.Right;            
            lbXinChao.Foreground = Brushes.Aqua;
            lbXinChao.Margin = new Thickness(0, -1.5, 0, 0);
            gridLoiChao.Children.Add(lbXinChao);
            Grid.SetColumn(lbXinChao, 1);

            btThoat = new Button();
            btThoat.Content = "Thoát";
            btThoat.Style = this.FindResource("MenuButtonStyle") as Style;
            btThoat.Click += new RoutedEventHandler(btThoat_Click);
            gridLoiChao.Children.Add(btThoat);
            Grid.SetColumn(btThoat, 0);

            gridLoiChao.Visibility = Visibility.Hidden;
            stackMenu.Children.Add(gridLoiChao);
            /*
            lbThoat = new Label();
            lbThoat.Content = "Thoát";
            
            lbThoat.Foreground = Brushes.Black;
            lbThoat.FontStyle = FontStyles.Italic;
            lbThoat.Cursor = Cursors.Hand;
            //lbThoat.MouseDown += new MouseButtonEventHandler(lbThoat_MouseDown);
            ChaoNguoiDung.Children.Add(lbThoat);
            Grid.SetColumn(lbThoat, 1);
            */
            
        }

        private void btThoat_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            gridLoiChao.Visibility = Visibility.Hidden;
            frameGiaoDienChinh.Source = null;
            //FormNguoiDung.frameHienThi.Visibility = Visibility.Visible;
            FormNguoiDung.frameHienThi.Source = new Uri("DangNhap.xaml", UriKind.Relative);
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