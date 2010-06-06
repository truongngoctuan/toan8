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
        List<ListBoxItem> m_ListLbiDapAn;
        ListBoxItem m_LbiCauHoi;
        List<int> m_ListViTriDapAn = new List<int>();
        public List<string> m_ListStrDapAn = new List<string>();
        public int m_Chuong = 0;
        public int m_BaiHoc = 0;
        public int m_CauHoi = 0;
        public string m_Path;
        public string m_StrCauHoi;
        static SapXepChungMinh()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SapXepChungMinh), new FrameworkPropertyMetadata(typeof(SapXepChungMinh)));
        }

        public void LayDuLieuCauHoi()
        {
            var xElement = XElement.Load(m_Path + "\\CauHoi.xml");
            var cauHoi = from c in xElement.Descendants("CauHoi")
                         where c.Element("BaiHoc").Value == m_BaiHoc.ToString()
                            && c.Element("CauHoiID").Value == m_CauHoi.ToString()
                         select c.Element("NoiDungCauHoi").Value;

            if (cauHoi.Count() == 0)
            {
                m_StrCauHoi = "";
                return;
            }
            m_StrCauHoi = cauHoi.ElementAt(0);
        }
        public void LayDuLieuDapAn()
        {
            var xElementDapAn = XElement.Load(m_Path + "\\DapAn.xml");
            var dapAn = from d in xElementDapAn.Descendants("DapAn")
                        where d.Element("BaiHoc").Value == m_BaiHoc.ToString()
                           && d.Element("CauHoi").Value == m_CauHoi.ToString()
                        select d.Element("NoiDungDapAn").Value;

            for (int i = 0; i < dapAn.Count(); i++)
            {
                m_ListStrDapAn.Add(dapAn.ElementAt(i));
            }
        }
        public void HienThi(string filename)
        {
            string Temp;

            if (filename.Contains("BaiTapDaiSo"))
            {
                Temp = "\\BaiTapDaiSo\\Chuong";
                m_Path = "DeSapXepChungMinh" + filename.Remove(Temp.Length + 2);

            }
            else
            {
                Temp = "\\BaiTapHinhHoc\\Chuong";
                m_Path = "DeSapXepChungMinh" + filename.Remove(Temp.Length + 2);
            }
            string strChuong = filename.Remove(0, Temp.Length).Remove(2, "\\Bai01\\Cau01".Length);
            string strBai = filename.Remove(0, (Temp + "01\\Bai").Length).Remove(2, "\\Cau01".Length);
            string strCau = filename.Remove(0, (Temp + "01\\Bai01\\Cau").Length);
            m_Chuong = int.Parse(strChuong);
            m_BaiHoc = int.Parse(strBai);
            m_CauHoi = int.Parse(strCau);
            HienThiCauHoi();
            HienThiDapAn();
            if (m_ListStrDapAn.Count() > 0)
            {
                Button btHoanDoi = new Button();
                btHoanDoi.Width = 100;
                btHoanDoi.Height = 30;
                Image img = new Image();
                img.HorizontalAlignment = HorizontalAlignment.Left;
                img.VerticalAlignment = VerticalAlignment.Top;

                BitmapSource bs = new BitmapImage(new Uri("images/DoiCho.png", UriKind.Relative));
                img.Source = bs;
                int top = m_ListStrDapAn.Count() * 40;
                btHoanDoi.Margin = new Thickness(400, -top, 0, 0);
                btHoanDoi.Width = 32;
                btHoanDoi.Height = 70;
                //img.Width = bs.Width;
                //img.Height = bs.Height;
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
            if (m_StrCauHoi.CompareTo("") == 0)
            {
                return;
            }
            ListBoxItem listBoxItem = new ListBoxItem();
            m_StrCauHoi = m_Path + "\\" + m_BaiHoc.ToString() + "\\" + m_StrCauHoi;
            StackPanel stackPanel = new StackPanel();
            listBoxItem.Content = stackPanel;

            Image image = new Image();
            BitmapSource bitmapSource = new BitmapImage(new Uri(m_StrCauHoi, UriKind.RelativeOrAbsolute));
            image.Source = bitmapSource;
            image.Width = bitmapSource.Width;
            image.Height = bitmapSource.Height;
            stackPanel.Children.Add(image);
            Children.Add(listBoxItem);
        }

        public void HienThiDapAn()
        {
            LayDuLieuDapAn();
            m_ListLbiDapAn = new List<ListBoxItem>();
            if (m_ListStrDapAn.Count == 0)
            {
                return;
            }
            // Phat sinh ngau nhien
            Random rand = new Random();
            int[] phatSinhNgauNhien = new int[m_ListStrDapAn.Count()];

            for (int i = 0; i < m_ListStrDapAn.Count(); i++)
            {
                int temp = rand.Next(0, m_ListStrDapAn.Count());
                int j = 0;
                for (; j < i; j++)
                {
                    if (temp == phatSinhNgauNhien[j])
                    {
                        break;
                    }
                }
                if (j == i)
                {
                    phatSinhNgauNhien[i] = temp;
                }
                else
                {
                    i--;
                }
            }
            for (int i = 0; i < phatSinhNgauNhien.Count(); i++)
            {
                m_ListViTriDapAn.Add(phatSinhNgauNhien[i]);
            }

            for (int i = 0; i < m_ListStrDapAn.Count(); i++)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                StackPanel stackPanel = new StackPanel();
                listBoxItem.Name = "lbiDapAn" + i.ToString();
                stackPanel.Orientation = Orientation.Horizontal;
                listBoxItem.Content = stackPanel;
                CheckBox checkBox = new CheckBox();
                checkBox.Width = 25;
                checkBox.Height = 25;
                checkBox.Margin = new Thickness(50, 15, 0, 0);
                checkBox.Checked += new RoutedEventHandler(checkBox_Checked);
                checkBox.Unchecked += new RoutedEventHandler(checkBox_Unchecked);
                Canvas canvas = new Canvas();
                canvas.Width = checkBox.Width + 50;
                canvas.Height = checkBox.Height + 15;
                canvas.Children.Add(checkBox);
                canvas.Arrange(new Rect(0, 0, canvas.Width, canvas.Height));
                stackPanel.Children.Add(canvas);
                Image image = new Image();
                BitmapSource bitmapSource = new BitmapImage(new Uri(m_Path + "\\" + m_BaiHoc.ToString() + "\\" + m_ListStrDapAn[m_ListViTriDapAn[i]], UriKind.RelativeOrAbsolute));
                image.Source = bitmapSource;
                image.Width = bitmapSource.Width;
                image.Height = bitmapSource.Height;
                stackPanel.Children.Add(image);
                m_LbiCauHoi = listBoxItem;
                m_ListLbiDapAn.Add(listBoxItem);

            }
            Orientation = Orientation.Vertical;
            for (int i = 0; i < m_ListLbiDapAn.Count; ++i)
            {
                Children.Add(m_ListLbiDapAn[i]);
            }
        }

        void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            XuLyCheckBox();
        }

        void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            XuLyCheckBox();
        }

        public void DoiCho()
        {
            int viTriCheck1 = -1;
            int viTriCheck2 = -1;
            int dem = 0;
            for (int i = 0; i < m_ListLbiDapAn.Count(); i++)
            {
                ListBoxItem listBoxItem = m_ListLbiDapAn[i];
                StackPanel stackPanel = (StackPanel)listBoxItem.Content;
                Canvas canvas = new Canvas();
                canvas = (Canvas)stackPanel.Children[0];
                CheckBox checkBox = (CheckBox)canvas.Children[0];
                if (checkBox.IsChecked == true)
                {
                    if (viTriCheck1 == -1)
                    {
                        viTriCheck1 = i;
                    }
                    else
                    {
                        viTriCheck2 = i;
                    }
                    dem += 1;
                }
            }

            if (dem != 2)
            {
                return;
            }
            int Temp = m_ListViTriDapAn[viTriCheck1];
            m_ListViTriDapAn[viTriCheck1] = m_ListViTriDapAn[viTriCheck2];
            m_ListViTriDapAn[viTriCheck2] = Temp;


            BitmapSource bitmapSource1 = new BitmapImage(new Uri(m_Path + "\\" + m_BaiHoc.ToString() + "\\" + m_ListStrDapAn[m_ListViTriDapAn[viTriCheck1]], UriKind.RelativeOrAbsolute));
            ListBoxItem listBoxItem1 = m_ListLbiDapAn[viTriCheck1];
            StackPanel stackPanel1 = (StackPanel)listBoxItem1.Content;
            Image img1 = (Image)stackPanel1.Children[1];
            img1.Width = bitmapSource1.Width;
            img1.Height = bitmapSource1.Height;
            img1.Source = bitmapSource1;

            BitmapSource bitmapSource2 = new BitmapImage(new Uri(m_Path + "\\" + m_BaiHoc.ToString() + "\\" + m_ListStrDapAn[m_ListViTriDapAn[viTriCheck2]], UriKind.RelativeOrAbsolute));
            ListBoxItem listBoxItem2 = m_ListLbiDapAn[viTriCheck2];
            StackPanel stackPanel2 = (StackPanel)listBoxItem2.Content;
            Image image2 = (Image)stackPanel2.Children[1];

            image2.Width = bitmapSource2.Width;
            image2.Height = bitmapSource2.Height;
            image2.Source = bitmapSource2;

            for (int i = 0; i < m_ListStrDapAn.Count(); i++)
            {
                ListBoxItem listBoxItem = m_ListLbiDapAn[i];
                StackPanel sp = (StackPanel)listBoxItem.Content;
                Canvas cv = new Canvas();
                cv = (Canvas)sp.Children[0];
                CheckBox cb = (CheckBox)cv.Children[0];
                cb.IsEnabled = true;
                cb.IsChecked = false;
            }
        }

        public double KiemTra()
        {
            int soDapAn = m_ListLbiDapAn.Count();
            for (int i = 0; i < soDapAn; i++)
            {
                ListBoxItem listBoxItem = m_ListLbiDapAn[i];
                StackPanel stackPanel = (StackPanel)listBoxItem.Content;
                Image image = (Image)stackPanel.Children[1];
                string strDapAnNguoiDung = image.Source.ToString();

                if (strDapAnNguoiDung.Contains(m_ListStrDapAn[i]) != true)
                {
                    for (int j = i; j < soDapAn; j++)
                    {
                        ListBoxItem listBoxItemSai = m_ListLbiDapAn[j];
                        StackPanel stackPanelSai = (StackPanel)listBoxItemSai.Content;
                        Canvas canvasSai = (Canvas)stackPanelSai.Children[0];
                        CheckBox checkBoxSai = (CheckBox)canvasSai.Children[0];
                        checkBoxSai.Background = Brushes.Red;
                    }
                    return 0.0;

                }
                Canvas canvasDung = (Canvas)stackPanel.Children[0];
                CheckBox checkBoxDung = (CheckBox)canvasDung.Children[0];
                checkBoxDung.Background = Brushes.Blue;
            }
            return 1.0;
        }

        public void XuLyCheckBox()
        {
            int dem = 0;
            int viTriCheck1 = -1;
            int viTriCheck2 = -1;
            for (int i = 0; i < m_ListLbiDapAn.Count(); i++)
            {
                ListBoxItem listBoxItem = m_ListLbiDapAn[i];
                StackPanel stackPanel = (StackPanel)listBoxItem.Content;
                Canvas canvas = new Canvas();
                canvas = (Canvas)stackPanel.Children[0];
                CheckBox checkBox = (CheckBox)canvas.Children[0];
                if (checkBox.IsChecked == true)
                {

                    if (viTriCheck1 == -1)
                    {
                        viTriCheck1 = i;
                    }
                    else
                    {
                        viTriCheck2 = i;
                    }

                    dem += 1;
                }
            }

            for (int i = 0; i < m_ListStrDapAn.Count(); i++)
            {
                ListBoxItem listBoxItem = m_ListLbiDapAn[i];
                StackPanel stackPanel = (StackPanel)listBoxItem.Content;
                Canvas canvas = new Canvas();
                canvas = (Canvas)stackPanel.Children[0];
                CheckBox checkBox = (CheckBox)canvas.Children[0];
                checkBox.IsEnabled = false;
                if (i == viTriCheck1 || i == viTriCheck2 || dem < 2)
                {
                    checkBox.IsEnabled = true;
                }
            }
        }
    }
}