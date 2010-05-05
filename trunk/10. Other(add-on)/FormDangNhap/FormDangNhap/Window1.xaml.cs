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
            string ten = this.tbTen.Text;
            string matKhau = this.tbMatKhau.Text;
            bool dangNhapThanhCong = DangNhap(ten, matKhau);            
            if (dangNhapThanhCong == true)
            {
                //Viet code de xu ly khi dang nhap thanh cong 
                //Vi du
                MessageBox.Show("Dang nhap thanh cong");
            }
            else
            {
                //Viet code de xu ly khi dang nhap that bai 
                //Vi du
                MessageBox.Show("Dang nhap that bai");
            }
        }

        public bool DangNhap(string tenDangNhap, string matKhauDangNhap)
        {
            //Minh them code xu ly sau
            //O day, return true hoac false, cac ban co the tu gia dinh de test phan dang nhap 
            return false;
        }
    }
}
