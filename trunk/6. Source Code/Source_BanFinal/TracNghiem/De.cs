using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;

namespace TracNghiem
{
    public class De
    {
        public string m_Ten;
        public List<ListBoxItem> m_DanhSachCau;
        public List<bool> m_TinhTrangCheck;

        public De(string folderPath, double width)
        {
            string fileDapAn = Directory.GetFiles(folderPath, "Dap*.txt")[0];
            string[] fileDe = Directory.GetFiles(folderPath, "*.png");
            List<string> dsFilede = new List<string>(fileDe);
            dsFilede.Sort(Comparer.sapxepDe);
            m_DanhSachCau = new List<ListBoxItem>();
            StreamReader sr = new StreamReader(fileDapAn);
            m_Ten = sr.ReadLine().Trim();
            m_TinhTrangCheck = new List<bool>();
            int nDapAn = 0;
            int nPhuongAn = 0;
            string groupName = "";
            
            for (int i = 0; i < dsFilede.Count; ++i)
            {
                string[] fileNameparts = dsFilede[i].Split('/', '\\', '.');
                string[] namepart = fileNameparts[fileNameparts.Length - 2].Split('_');

                if (namepart.Length == 1)
                {
                    groupName = i.ToString();
                    m_TinhTrangCheck.Add(bool.Parse(sr.ReadLine().Trim()));
                    ListBoxItem lbi = new ListBoxItem();
                    StackPanel sp = new StackPanel();
                    BitmapSource bs = new BitmapImage(new Uri(dsFilede[i]));
                    Image img = new Image();
                    img.Source = bs;
                    img.Height = bs.Height;
                    img.Width = bs.Width;
                    sp.Height = bs.Height;
                    sp.Width = bs.Width;
                    sp.Tag = "de";
                    lbi.Height = bs.Height;
                    lbi.Width = width;
                    sp.Width = width;
                    sp.Orientation = Orientation.Horizontal;
                    sp.Children.Add(img);
                    lbi.Content = sp;
                    m_DanhSachCau.Add(lbi);

                    if (nDapAn > 1)
                    {
                        for (int j = i - nPhuongAn; j < i; ++j)
                        {
                            m_DanhSachCau.RemoveAt(j);
                            ListBoxItem lbiPhuongAn = new ListBoxItem();
                            StackPanel spPhuongAn = new StackPanel();
                            spPhuongAn.Tag = "cb";
                            CheckBox cb = new CheckBox();
                            Canvas cv = new Canvas();
                            cv.Children.Add(cb);
                            cb.IsChecked = false;
                            BitmapSource bsPhuongAn = new BitmapImage(new Uri(dsFilede[j]));
                            Image imgPhuongAn = new Image();
                            imgPhuongAn.Source = bsPhuongAn;
                            imgPhuongAn.Height = bsPhuongAn.Height;
                            imgPhuongAn.Width = bsPhuongAn.Width;
                            spPhuongAn.Height = bsPhuongAn.Height;
                            spPhuongAn.Width = bsPhuongAn.Width;
                            cb.Width = 25;
                            cb.Height = 25;
                            cb.Arrange(new Rect(0, 0, cb.Width, cb.Height));
                            cb.Margin = new Thickness(10, (bsPhuongAn.Height - cb.Height) / 2 + 6, 0, 0);
                            cv.Width = cb.Width + 30;
                            cv.Height = bsPhuongAn.Height;

                            lbiPhuongAn.Height = bsPhuongAn.Height;
                            lbiPhuongAn.Width = width - 60;
                            spPhuongAn.Orientation = Orientation.Horizontal;
                            spPhuongAn.Width = width;
                            spPhuongAn.Children.Add(cv);
                            spPhuongAn.Children.Add(imgPhuongAn);
                            lbiPhuongAn.Content = spPhuongAn;
                            m_DanhSachCau.Insert(j, lbiPhuongAn);    
                        }
                    }
                    nDapAn = 0;
                    nPhuongAn = 0;
                }
                else
                {
                    m_TinhTrangCheck.Add(bool.Parse(sr.ReadLine().Trim()));
                    ++nPhuongAn;
                    if (m_TinhTrangCheck[i])
                    {
                        ++nDapAn;
                    }
                    ListBoxItem lbi = new ListBoxItem();
                    StackPanel sp = new StackPanel();
                    sp.Tag = "rd";
                    RadioButton rd = new RadioButton();
                    rd.GroupName = groupName;
                    Canvas cv = new Canvas();
                    rd.IsChecked = false;
                    BitmapSource bs = new BitmapImage(new Uri(dsFilede[i]));
                    Image img = new Image();
                    img.Source = bs;
                    img.Height = bs.Height;
                    img.Width = bs.Width;
                    sp.Height = bs.Height;
                    sp.Width = bs.Width;
                    rd.Width = 25;
                    rd.Height = 25;
                    rd.Arrange(new Rect(0, 0, rd.Width, rd.Height));
                    rd.Margin = new Thickness(10, (bs.Height - rd.Height)/2 + 6, 0, 0);
                    cv.Width = rd.Width + 30;
                    cv.Height = bs.Height;
                    cv.Children.Add(rd);                    
                    lbi.Height = bs.Height;
                    lbi.Width = width - 60;
                    sp.Orientation = Orientation.Horizontal;
                    sp.Width = width;
                    sp.Children.Add(cv);
                    sp.Children.Add(img);
                    lbi.Content = sp;
                    m_DanhSachCau.Add(lbi);

                    if (i == dsFilede.Count - 1 && nDapAn > 1)
                    {
                        for (int j = i - nPhuongAn + 1; j <= i; ++j)
                        {
                            m_DanhSachCau.RemoveAt(j);
                            ListBoxItem lbiPhuongAn = new ListBoxItem();
                            StackPanel spPhuongAn = new StackPanel();
                            spPhuongAn.Tag = "cb";
                            CheckBox cb = new CheckBox();
                            Canvas cbcv = new Canvas();
                            cbcv.Children.Add(cb);
                            cb.IsChecked = false;
                            BitmapSource bsPhuongAn = new BitmapImage(new Uri(dsFilede[j]));
                            Image imgPhuongAn = new Image();
                            imgPhuongAn.Source = bsPhuongAn;
                            imgPhuongAn.Height = bsPhuongAn.Height;
                            imgPhuongAn.Width = bsPhuongAn.Width;
                            spPhuongAn.Height = bsPhuongAn.Height;
                            spPhuongAn.Width = bsPhuongAn.Width;
                            cb.Width = 25;
                            cb.Height = 25;
                            cb.Arrange(new Rect(0, 0, cb.Width, cb.Height));
                            cb.Margin = new Thickness(10, (bsPhuongAn.Height - cb.Height) / 2 + 6, 0, 0);
                            cbcv.Width = cb.Width + 30;
                            cbcv.Height = bsPhuongAn.Height;

                            lbiPhuongAn.Height = bsPhuongAn.Height;
                            lbiPhuongAn.Width = width - 60;
                            spPhuongAn.Orientation = Orientation.Horizontal;
                            spPhuongAn.Width = width;
                            spPhuongAn.Children.Add(cbcv);
                            spPhuongAn.Children.Add(imgPhuongAn);
                            lbiPhuongAn.Content = spPhuongAn;
                            m_DanhSachCau.Insert(j, lbiPhuongAn);
                        }
                        nDapAn = 0;
                        nPhuongAn = 0;
                    }
                }
            }
            sr.Close();
        }        
    }
}
