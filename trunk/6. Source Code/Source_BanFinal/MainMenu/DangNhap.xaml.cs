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
        static public NguoiDung_DTO NguoiDungHienThoi;
        public DangNhap()
        {            
            InitializeComponent();
            NguoiDungHienThoi = new NguoiDung_DTO();
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
                        NguoiDungHienThoi = BUS.NguoiDung_BUS.LayThongTinCuaTaiKhoan(this.tbTen.Text);
                        //FormNguoiDung.frameHienThi.Visibility = Visibility.Hidden;
                        FormNguoiDung.frameHienThi.Source = null;
                        Window1.frameGiaoDienChinh.Source = new Uri("Room.xaml", UriKind.Relative);
                        Window1.lbXinChao.Content = "Hello, " + NguoiDungHienThoi.HoTen + " (^_^)";
                        Window1.gridLoiChao.Visibility = Visibility.Visible;
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

        private void Label_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	// TODO: Add event handler implementation here.		
            lbTaoTaiKhoanMoi.FontSize += 2;
        }

        private void lbTaoTaiKhoanMoi_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            lbTaoTaiKhoanMoi.FontSize -= 2;
        }

        private void lbTaoTaiKhoanMoi_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            FormNguoiDung.frameHienThi.Source = new Uri("DangKyTaiKhoan.xaml", UriKind.Relative);
        }
    }
}
