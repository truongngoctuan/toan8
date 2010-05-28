using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace ColorSwatch
{
	public partial class FormNguoiDung
	{
		static public Frame frameHienThi;
		public FormNguoiDung()
		{
			this.InitializeComponent();

			// Insert code required on object creation below this point.
			frameHienThi = new Frame();
			frameHienThi.NavigationUIVisibility = NavigationUIVisibility.Hidden;
			frameHienThi.Source = new Uri("DangNhap.xaml", UriKind.Relative);
			LayoutRoot.Children.Add(frameHienThi);
		}
	}
}