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
using System.Xml.Linq;
using System.Data;

namespace ColorSwatch
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ColorSwatch"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ColorSwatch;assembly=ColorSwatch"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:SXCM/>
    ///
    /// </summary>
    public class SapXepChungMinh : StackPanel
    {
        List<ListBoxItem> DapAn;
        ListBoxItem lbiCauHoi;
        List<int> ViTriDapAn = new List<int>();
        List<string> lstDapAn = new List<string>();
        int Chuong = 0;
        int BaiHoc = 0;
        int CauHoi = 0;
        string path;
        string strCauHoi;
        static SapXepChungMinh()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SapXepChungMinh), new FrameworkPropertyMetadata(typeof(SapXepChungMinh)));
        }

        public void LayDuLieuCauHoi()
        {
            var xElement = XElement.Load(path + "\\CauHoi.xml");
            var cauHoi = from c in xElement.Descendants("CauHoi")
                         where c.Element("BaiHoc").Value == BaiHoc.ToString()
                            && c.Element("CauHoiID").Value == CauHoi.ToString()
                         select c.Element("NoiDungCauHoi").Value;

            if (cauHoi.Count() == 0)
            {
                strCauHoi = "";
            }
            strCauHoi = cauHoi.ElementAt(0);
        }
        public void LayDuLieuDapAn()
        {
            var xElementDapAn = XElement.Load(path + "\\DapAn.xml");
            var dapAn = from d in xElementDapAn.Descendants("DapAn")
                        where d.Element("BaiHoc").Value == BaiHoc.ToString()
                           && d.Element("CauHoi").Value == CauHoi.ToString()
                        select d.Element("NoiDungDapAn").Value;

            for (int i = 0; i < dapAn.Count(); i++)
            {
                lstDapAn.Add(dapAn.ElementAt(i));
            }
        }
        public void HienThi(string filename)
        {
            string Temp;

            if (filename.Contains("BaiTapDaiSo"))
            {
                Temp = "\\BaiTapDaiSo\\Chuong";
                path = "DeSapXepChungMinh" + filename.Remove(Temp.Length + 2);

            }
            else
            {
                Temp = "BaiTapHinhHoc\\Chuong";
            }
            string strChuong = filename.Remove(0, Temp.Length).Remove(2, "\\Bai01\\Cau01".Length);
            string strBai = filename.Remove(0, (Temp + "01\\Bai").Length).Remove(2, "\\Cau01".Length);
            string strCau = filename.Remove(0, (Temp + "01\\Bai01\\Cau").Length);
            Chuong = int.Parse(strChuong);
            BaiHoc = int.Parse(strBai);
            CauHoi = int.Parse(strCau);
            HienThiCauHoi();
            HienThiDapAn();
            if (lstDapAn.Count() > 0)
            {
                Button btHoanDoi = new Button();
                btHoanDoi.Width = 100;
                btHoanDoi.Height = 30;
                Image img = new Image();
                img.HorizontalAlignment = HorizontalAlignment.Left;
                img.VerticalAlignment = VerticalAlignment.Top;

                BitmapSource bs = new BitmapImage(new Uri("..\\..\\images\\DoiCho.png", UriKind.RelativeOrAbsolute));
                img.Source = bs;
                int top = lstDapAn.Count() * 40;
                btHoanDoi.Margin = new Thickness(400, -top, 0, 0);
                btHoanDoi.Width = 32;
                btHoanDoi.Height = 70;
                img.Width = bs.Width;
                img.Height = bs.Height;
                btHoanDoi.Content = img;
                btHoanDoi.Click += new RoutedEventHandler(btHoanDoi_Click);

                Children.Add(btHoanDoi);
            }
        }

        void btHoanDoi_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            DoiCho();

        }
        public void HienThiCauHoi()
        {
            LayDuLieuCauHoi();
            if (strCauHoi.CompareTo("") == 0)
            {
                return;
            }
            ListBoxItem lbi = new ListBoxItem();
            strCauHoi = path + "\\" + BaiHoc.ToString() + "\\" + strCauHoi;
            StackPanel sp = new StackPanel();
            lbi.Content = sp;

            Image img = new Image();
            BitmapSource bs = new BitmapImage(new Uri(strCauHoi, UriKind.RelativeOrAbsolute));
            img.Source = bs;
            img.Width = bs.Width;
            img.Height = bs.Height;
            sp.Children.Add(img);
            Children.Add(lbi);
        }

        public void HienThiDapAn()
        {
            LayDuLieuDapAn();
            DapAn = new List<ListBoxItem>();
            if (lstDapAn.Count == 0)
            {
                return;
            }
            // Phat sinh ngau nhien
            Random rand = new Random();
            int[] PhatSinhNgauNhien = new int[lstDapAn.Count()];

            for (int i = 0; i < lstDapAn.Count(); i++)
            {
                int Temp = rand.Next(0, lstDapAn.Count());
                int j = 0;
                for (; j < i; j++)
                {
                    if (Temp == PhatSinhNgauNhien[j])
                    {
                        break;
                    }
                }
                if (j == i)
                {
                    PhatSinhNgauNhien[i] = Temp;
                }
                else
                {
                    i--;
                }
            }
            for (int i = 0; i < PhatSinhNgauNhien.Count(); i++)
            {
                ViTriDapAn.Add(PhatSinhNgauNhien[i]);
            }

            for (int i = 0; i < lstDapAn.Count(); i++)
            {
                ListBoxItem lbi = new ListBoxItem();
                StackPanel sp = new StackPanel();
                lbi.Name = "lbiDapAn" + i.ToString();
                sp.Orientation = Orientation.Horizontal;
                lbi.Content = sp;
                CheckBox cb = new CheckBox();
                cb.Width = 25;
                cb.Height = 25;
                cb.Margin = new Thickness(50, 15, 0, 0);
                cb.Checked += new RoutedEventHandler(cb_Checked);
                cb.Unchecked += new RoutedEventHandler(cb_Unchecked);
                Canvas cv = new Canvas();
                cv.Width = cb.Width + 50;
                cv.Height = cb.Height + 15;
                cv.Children.Add(cb);
                cv.Arrange(new Rect(0, 0, cv.Width, cv.Height));
                sp.Children.Add(cv);
                Image img = new Image();
                BitmapSource bs = new BitmapImage(new Uri(path + "\\" + BaiHoc.ToString() + "\\" + lstDapAn[ViTriDapAn[i]], UriKind.RelativeOrAbsolute));
                img.Source = bs;
                img.Width = bs.Width;
                img.Height = bs.Height;
                sp.Children.Add(img);
                lbiCauHoi = lbi;
                DapAn.Add(lbi);

            }
            Orientation = Orientation.Vertical;
            for (int i = 0; i < DapAn.Count; ++i)
            {
                Children.Add(DapAn[i]);
            }
        }

        void cb_Unchecked(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            XuLyCheckBox();
        }

        void cb_Checked(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            XuLyCheckBox();
        }

        public void DoiCho()
        {
            int ViTri1 = -1;
            int ViTri2 = -1;
            int Dem = 0;
            for (int i = 0; i < DapAn.Count(); i++)
            {
                ListBoxItem lbi = DapAn[i];
                StackPanel sp = (StackPanel)lbi.Content;
                Canvas cv = new Canvas();
                cv = (Canvas)sp.Children[0];
                CheckBox cb = (CheckBox)cv.Children[0];
                if (cb.IsChecked == true)
                {
                    if (ViTri1 == -1)
                    {
                        ViTri1 = i;
                    }
                    else
                    {
                        ViTri2 = i;
                    }
                    Dem += 1;
                }
            }

            if (Dem != 2)
            {
                return;
            }
            int Temp = ViTriDapAn[ViTri1];
            ViTriDapAn[ViTri1] = ViTriDapAn[ViTri2];
            ViTriDapAn[ViTri2] = Temp;


            BitmapSource bs1 = new BitmapImage(new Uri(path + "\\" + BaiHoc.ToString() + "\\" + lstDapAn[ViTriDapAn[ViTri1]], UriKind.RelativeOrAbsolute));
            ListBoxItem lbItem1 = DapAn[ViTri1];
            StackPanel stackPanel1 = (StackPanel)lbItem1.Content;
            Image img1 = (Image)stackPanel1.Children[1];
            img1.Width = bs1.Width;
            img1.Height = bs1.Height;
            img1.Source = bs1;

            BitmapSource bs2 = new BitmapImage(new Uri(path + "\\" + BaiHoc.ToString() + "\\" + lstDapAn[ViTriDapAn[ViTri2]], UriKind.RelativeOrAbsolute));
            ListBoxItem lbItem2 = DapAn[ViTri2];
            StackPanel stackPanel2 = (StackPanel)lbItem2.Content;
            Image img2 = (Image)stackPanel2.Children[1];

            img2.Width = bs2.Width;
            img2.Height = bs2.Height;
            img2.Source = bs2;

            for (int i = 0; i < lstDapAn.Count(); i++)
            {
                ListBoxItem lbi = DapAn[i];
                StackPanel sp = (StackPanel)lbi.Content;
                Canvas cv = new Canvas();
                cv = (Canvas)sp.Children[0];
                CheckBox cb = (CheckBox)cv.Children[0];
                cb.IsEnabled = true;
                cb.IsChecked = false;
            }
        }

        public double KiemTra()
        {
            int soDapAn = DapAn.Count();
            for (int i = 0; i < soDapAn; i++)
            {
                ListBoxItem lbi = DapAn[i];
                StackPanel sp = (StackPanel)lbi.Content;
                Image img = (Image)sp.Children[1];
                string strDapAnNguoiDung = img.Source.ToString();

                if (strDapAnNguoiDung.Contains(lstDapAn[i]) != true)
                {
                    for (int j = i; j < soDapAn; j++)
                    {
                        ListBoxItem lbiSai = DapAn[j];
                        StackPanel spSai = (StackPanel)lbiSai.Content;
                        Canvas cvSai = (Canvas)spSai.Children[0];
                        CheckBox cbSai = (CheckBox)cvSai.Children[0];
                        cbSai.Background = Brushes.Red;
                    }
                    return 0.0;

                }
                Canvas cvDung = (Canvas)sp.Children[0];
                CheckBox cbDung = (CheckBox)cvDung.Children[0];
                cbDung.Background = Brushes.Blue;
            }
            return 1.0;
        }

        public void XuLyCheckBox()
        {
            int Dem = 0;
            int ViTri1 = -1;
            int ViTri2 = -1;
            for (int i = 0; i < DapAn.Count(); i++)
            {
                ListBoxItem lbi = DapAn[i];
                StackPanel sp = (StackPanel)lbi.Content;
                Canvas cv = new Canvas();
                cv = (Canvas)sp.Children[0];
                CheckBox cb = (CheckBox)cv.Children[0];
                if (cb.IsChecked == true)
                {

                    if (ViTri1 == -1)
                    {
                        ViTri1 = i;
                    }
                    else
                    {
                        ViTri2 = i;
                    }

                    Dem += 1;
                }
            }

            for (int i = 0; i < lstDapAn.Count(); i++)
            {
                ListBoxItem lbi = DapAn[i];
                StackPanel sp = (StackPanel)lbi.Content;
                Canvas cv = new Canvas();
                cv = (Canvas)sp.Children[0];
                CheckBox cb = (CheckBox)cv.Children[0];
                cb.IsEnabled = false;
                if (i == ViTri1 || i == ViTri2 || Dem < 2)
                {
                    cb.IsEnabled = true;
                }
            }
        }
    }
}
