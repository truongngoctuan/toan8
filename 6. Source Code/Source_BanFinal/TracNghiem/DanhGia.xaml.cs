using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TracNghiem
{
    /// <summary>
    /// Interaction logic for DanhGia.xaml
    /// </summary>
    public partial class DanhGia : Window
    {
        public DanhGia(string diem, string danhgia)
        {
            InitializeComponent();
            txtSoDiem.Text = diem;
            txtDanhGia.Text = danhgia;
        }

        private void bntThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
