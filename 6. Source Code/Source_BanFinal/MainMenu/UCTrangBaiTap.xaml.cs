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
        public UCTrangBaiTap(string LoaiSach,int iChuong,int iBai)
        {
            InitializeComponent();
            var xElement = XElement.Load(LoaiSach);
            var baiHocThu = from c in xElement.Descendants("BaiHoc")
                            where int.Parse(c.Attribute("Chuong").Value) == iChuong && int.Parse(c.Attribute("Bai").Value) == iBai  
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
                            StackPanel sp = new StackPanel();
                            sp.Orientation = Orientation.Vertical;
                            TextBlock tbTemp = new TextBlock();
                            tbTemp.FontSize = 16;
                            tbTemp.Text = "Câu " + (i+1).ToString();
                            sp.Children.Add(tbTemp);
                            //tạo cau trắc nghiệm
                            TracNghiem temp = new TracNghiem();
                            string path = AppDomain.CurrentDomain.BaseDirectory + cau.Attribute("Source").Value;
                            string strThuTuCau = cau.Attribute("Cau").Value;
                            temp.LayCauHoi(path,strThuTuCau, 15, 50);
                            //Thêm câu trắc nghiệm vào stackpanel
                            sp.Children.Add(temp);
                            this.spDanhSachCauHoi.Children.Add(sp);
                            break;
                        case "SapXepChungMinh":
                            StackPanel sp1 = new StackPanel();
                            sp1.Orientation = Orientation.Vertical;
                            TextBlock tbTemp1 = new TextBlock();
                            tbTemp1.FontSize = 16;
                            tbTemp1.Text = "Câu " + (i + 1).ToString();
                            sp1.Children.Add(tbTemp1);
                            //tao câu sắp xếp chứng minh
                            SapXepChungMinh ctSXCM = new SapXepChungMinh();
                            string pathFile = cau.Attribute("Source").Value;
                            ctSXCM.HienThi(pathFile);
                            //Thêm câu trắc nghiệm vào stackpanel
                            sp1.Children.Add(ctSXCM);
                            this.spDanhSachCauHoi.Children.Add(sp1);
                            //this.spDanhSachCauHoi.Children.Add(ctSXCM);
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
            for (int i = 0; i < this.spDanhSachCauHoi.Children.Count -1; i++)
            {
                string strSPtemp = spDanhSachCauHoi.Children[i].GetType().ToString();

                if (strSPtemp == "System.Windows.Controls.StackPanel")
                {
                    StackPanel spTemp = spDanhSachCauHoi.Children[i] as StackPanel;
                    for (int j = 0; j < spTemp.Children.Count; j++)
                    {
                        string temp = spTemp.Children[j].GetType().ToString();
                        if (temp == "ColorSwatch.TracNghiem")
                        {
                            Diem += (spTemp.Children[j] as TracNghiem).ChamDiem(1);
                            socau++;
                        }
                        if (temp == "ColorSwatch.SapXepChungMinh")
                        {
                            Diem += (spTemp.Children[j] as SapXepChungMinh).KiemTra();
                        }
                    }
                }
                // nếu là bìa sắp xếp chứng minh
            }
            MessageBox.Show((Diem).ToString());//tùy cách tổ chức thang điểm. cách chấm
        }
    }
}
