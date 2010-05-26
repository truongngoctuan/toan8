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
using System.IO;
using System.Xml.Linq;
namespace ColorSwatch
{
    /// <summary>
    /// Interaction logic for UCTrangBaiTap.xaml
    /// </summary>
    public partial class UCTrangBaiTap : UserControl
    {
        
        public UCTrangBaiTap()
        {
            InitializeComponent();
        }
        public UCTrangBaiTap(int iBai)
        {
            InitializeComponent();
            var xElement = XElement.Load(@"BaiTapDaiSo.xml");
            var baiHocThu = from c in xElement.Descendants("BaiHoc")
                            where int.Parse(c.Attribute("ThuTu").Value) == iBai
                            select c;
            if (baiHocThu.Count() != 0)
            {
                XElement BaiHoc = baiHocThu.ElementAt(0);
                int SoCau = BaiHoc.Elements().Count();
                for (int i = 0; i < SoCau; i++)
                {
                    XElement cau = BaiHoc.Elements().ElementAt(i);
                    switch (cau.Name.ToString())
                    {
                        case "TracNghiem":
                            TracNghiem temp = new TracNghiem();
                            string path = AppDomain.CurrentDomain.BaseDirectory + cau.Attribute("Source").Value;
                            string strThuTuCau = cau.Attribute("Cau").Value;
                            temp.LayCauHoi(path,strThuTuCau, 15, 50);
                            this.spDanhSachCauHoi.Children.Add(temp);
                            break;
                        case "SapXepChungMinh":
                            //tao câu sắp xếp chứng minh
                            break;

                    }
                }
                Button btchamDiem = new Button();
                btchamDiem.Width = 100;
                btchamDiem.Height = 30;
                btchamDiem.Content = "Chấm điểm";
                btchamDiem.Click += new RoutedEventHandler(btchamDiem_Click);
                this.spDanhSachCauHoi.Children.Add(btchamDiem);
            }
        }

        void btchamDiem_Click(object sender, RoutedEventArgs e)
        {
            // chidlren cuối cùng là button chấm điểm
            double Diem = 0;
            int socau = 0;
            for (int i = 0; i < this.spDanhSachCauHoi.Children.Count; i++)
            {
                string temp = spDanhSachCauHoi.Children[i].GetType().ToString();
                if (temp == "ColorSwatch.TracNghiem")
                {
                    Diem += (spDanhSachCauHoi.Children[i] as TracNghiem).ChamDiem(1);
                    socau++;
                }
                // nếu là bìa sắp xếp chứng minh
            }
            MessageBox.Show((Diem).ToString());//tùy cách tổ chức thang điểm. cách chấm
        }
    }
}
