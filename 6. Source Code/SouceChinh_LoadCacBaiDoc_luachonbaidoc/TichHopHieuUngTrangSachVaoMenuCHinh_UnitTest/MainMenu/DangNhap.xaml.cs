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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;
using BUS;

namespace ColorSwatch
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Page
    {
        public DangNhap()
        {
            
            InitializeComponent();
        }
       
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (this.tbTen.Text == string.Empty)
            {
                MessageBox.Show("Vui long nhap ten dang nhap");
                return;
            }
            
            int ketQuaDangNhap = ThucHienDangNhap();
            switch (ketQuaDangNhap)
            {
                case 0:
                    {
                        MessageBox.Show("Tai Khoan Khong Ton Tai");                        
                        break;
                    }
                case -1:
                    {
                        if (this.pbMatKhau.Password == string.Empty)
                        {
                            MessageBox.Show("Vui long nhap mat khau");
                            return;
                        }
                        MessageBox.Show("Sai Mat Khau");
                        break;
                    }
                case 1:
                case 2:
                    {
                        MessageBox.Show("Dang Nhap Thanh Cong");
                        this.Visibility = Visibility.Hidden;
                        break;
                    }
            }
            
        }

        public int ThucHienDangNhap()
        {
            string tenDangNhap = this.tbTen.Text;
            string matKhauDangNhap = this.pbMatKhau.Password;
            int kiemTraUserNameTonTaiChua = BUS.NguoiDung_BUS.KiemTraUserNameCoTonTaiChua(tenDangNhap);
            if ( kiemTraUserNameTonTaiChua!= 0)
            {
                string matKhau = BUS.NguoiDung_BUS.LayMatKhauCuaTaiKhoan(tenDangNhap);
                if (matKhauDangNhap == matKhau)
                {
                    return kiemTraUserNameTonTaiChua;  // Dang Nhap Thanh Cong, tra ve loai user
                }
                return -1;  // Sai Mat Khau
            }
            return 0;  // Tai Khoan Khong Ton Tai
        }
    }
}
