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
using System.Xml.Linq;
using BUS;
using ColorSwatch;

namespace ColorSwatch
{
    /// <summary>
    /// Interaction logic for DangKyTaiKhoan.xaml
    /// </summary>
    public partial class DangKyTaiKhoan : Page
    {
        public DangKyTaiKhoan()
        {
            InitializeComponent();
        }

        private void btn_DangKy_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void KeyUp_TextBoxTenDangNhap(object sender, KeyEventArgs e)
        {
            string tenDangNhap = textBoxTenDangNhap.Text;
            int doDaiTen = tenDangNhap.Length;
            labelTenDangNhap.FontSize = 12;
            labelTenDangNhap.Foreground=Brushes.Red;
            if (doDaiTen < 6)
            {
                
                labelTenDangNhap.Content = "Tên phải dài trên 5 ký tự";
            }
            else
            {

                int kiemTra = 1;
              
                kiemTra=BUS.NguoiDung_BUS.KiemTraUserNameCoTonTaiChua(textBoxTenDangNhap.Text);
                //Nếu tên đăng nhập chưa từng được đăng ký
                if (kiemTra == 0)
                {
                    labelTenDangNhap.Foreground = Brushes.Green;
                    labelTenDangNhap.Content = tenDangNhap + " hợp lệ";
                }
                else
                {
                    labelTenDangNhap.Foreground = Brushes.Red;
                    labelTenDangNhap.Content = tenDangNhap + " đã tồn tại";
                }
            }
        }

        private void passwordBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string matKhau = passwordBox1.Password;
            int doDaiMatKhau = matKhau.Length;
            labelMatKhau.FontSize=12;

            if (doDaiMatKhau < 8)
            {
                labelMatKhau.Foreground = Brushes.Red;
                labelMatKhau.Content = "Mật khẩu dài trên 7 ký tự";
            }
            else
            {
                labelMatKhau.Foreground = Brushes.Green;
                labelMatKhau.Content = "Mật khẩu hợp lệ";
            }
        }

        private void passwordBox2_KeyUp(object sender, KeyEventArgs e)
        {
            string matKhau = passwordBox1.Password;
            string matKhauNhapLai = passwordBox2.Password;
            labelMatKhauNhapLai.FontSize=12;
            if (matKhau == matKhauNhapLai)
            {
                labelMatKhauNhapLai.Foreground = Brushes.Green;
                labelMatKhauNhapLai.Content = "Mật khẩu chính xác";
            }
            else
            {
                labelMatKhauNhapLai.Foreground = Brushes.Red;
                labelMatKhauNhapLai.Content = "Mật khẩu chưa đúng";
            }
        }

        private void ButtonDangKy_Click(object sender, RoutedEventArgs e)
        {
            bool laHopLe = true;
            int taoThanhCong=0;

            if (textBoxTenDangNhap.Text.Length == 0)
            {
                labelTenDangNhap.Foreground = Brushes.Red;
                labelTenDangNhap.Content = "Bạn chưa điền tên đăng nhập ";
                laHopLe = false;
            }
           
            if (passwordBox1.Password.Length == 0)
            {
                labelMatKhau.Foreground = Brushes.Red;
                labelMatKhau.Content = "Bạn cần điền mật khẩu";
                laHopLe = false;
            }
            if (passwordBox2.Password.Length == 0)
            {
                labelMatKhauNhapLai.Foreground = Brushes.Red;
                labelMatKhauNhapLai.Content = "Mật khẩu chưa đúng";
                laHopLe = false;
            }
            else
            {
                if (passwordBox1.Password != passwordBox2.Password)
                {
                    laHopLe = false;
                }
            }
            if (textBoxHoTen.Text.Length == 0)
            {
                labelHoTen.Visibility = Visibility.Visible;
                laHopLe = false;
            }
            else
            {
                labelHoTen.Visibility = Visibility.Hidden;
            }
            if (textBoxTruong.Text.Length == 0)
            {
                labelTruong.Visibility = Visibility.Visible;
                laHopLe = false;
            }
            else
            {
                labelTruong.Visibility = Visibility.Hidden;
            }
            if (textBoxLop.Text.Length == 0)
            {
                labelLop.Visibility = Visibility.Visible;
                laHopLe = false;
            }
            else
            {
                labelLop.Visibility = Visibility.Hidden;
            }
            if (laHopLe == true)
            {
                XElement thongTinNguoiDung =
                    new XElement("ThongTinNguoiDung",
                        new XElement("TenDangNhap", textBoxTenDangNhap.Text),
                        new XElement("MatKhau", passwordBox1.Password),
                        new XElement("HoTen", textBoxHoTen.Text),
                        new XElement("Truong", textBoxTruong.Text),
                        new XElement("Lop", textBoxLop.Text),
                        new XElement("Email", textBoxEmail.Text),
                        new XElement("LoaiNguoiDung", 1)
                        );
                try
                {
                    
                    taoThanhCong=BUS.NguoiDung_BUS.ThemNguoiDungMoi(thongTinNguoiDung);
                    thongTinNguoiDung.RemoveAll();
                }
                catch(Exception ex)
                {
                    taoThanhCong=1;
                    MessageBox.Show(ex.ToString());
                }
            }
            if ((laHopLe == true) && (taoThanhCong == 0))
            {
                MessageBox.Show("Tài khoản đã được tạo thành công", "Chúc mừng", MessageBoxButton.OK, MessageBoxImage.Information);
                FormNguoiDung.frameHienThi.Source = new Uri("DangNhap.xaml", UriKind.Relative);
            }
            else
            {
                labelThongBao.Foreground = Brushes.Red;
                if (taoThanhCong == 1)
                {
                    labelTenDangNhap.Foreground = Brushes.Red;
                    labelTenDangNhap.Content = textBoxTenDangNhap.Text + " đã tồn tại";
                }
                else
                {
                    labelThongBao.Content = "Còn một số mục bạn chưa đúng , bạn cần hoàn thiện lại";

                }
            }
           
        }

        private void buttonHuyDangKy_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
       
    }
}
