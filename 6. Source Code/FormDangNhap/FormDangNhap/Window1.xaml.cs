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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BUS;
using DTO;
namespace FormDangNhap
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btDangNhap_Click(object sender, RoutedEventArgs e)
        {
            int ketQuaDangNhap = DangNhap();
            switch (ketQuaDangNhap)
            {
                case -1:                    
                    {
                        MessageBox.Show("Tai Khoan Khong Ton Tai");
                        break;
                    }
                case 0:
                    {
                        MessageBox.Show("Sai Mat Khau");
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Dang Nhap Thanh Cong");
                        break;
                    }
            }
        }

        public int DangNhap()
        {
            string tenDangNhap = this.tbTen.Text;
            string matKhauDangNhap = this.pbMatKhau.Password;
            if (BUS.PupilUserBUS.KiemTraTenDangNhapCoTonTaiKhong(tenDangNhap))
            {
                string matKhau = BUS.PupilUserBUS.LayMatKhauCuaTaiKhoan(tenDangNhap);
                if (matKhauDangNhap == matKhau)
                {
                    return 1;  // Dang Nhap Thanh Cong
                }
                return 0;  // Sai Mat Khau
            }
            return -1;  // Tai Khoan Khong Ton Tai
        }

    }
}
