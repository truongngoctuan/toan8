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
using WPFMitsuControls;

namespace TracNghiem.UC
{
    public partial class UCMucLuc : UserControl
    {
        public SachTracNghiem m_Parent;
        private Canvas m_MucLuc;
        private bool islbidbClick;
        private bool isexchilddbClick;
        public UCMucLuc(string thumucDuLieu)
        {
            InitializeComponent();
            HienThiMucLuc(thumucDuLieu);
            islbidbClick = false;
            isexchilddbClick = false;
        }

        private void HienThiMucLuc(string thumucDuLieu)
        {
            List<string> directories = new List<string>(Directory.GetDirectories(thumucDuLieu));
            directories.Sort();
            m_MucLuc = new Canvas();
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Vertical;
            Label blank = new Label();
            blank.Height = 50;
            blank.Opacity = 0;
            sp.Children.Add(blank);
            
            for (int i = 0; i < directories.Count; ++i)
            {
                Expander ex = new Expander();
                string []arrdir = directories[i].Split('\\');
                ex.Header = arrdir[arrdir.Length - 1];
                ex.FontFamily = new FontFamily("Times New Roman");
                ex.FontSize = 30;
                ex.FontStyle = FontStyles.Oblique;
                ex.Background = Brushes.Transparent;
                ex.Margin = new Thickness(50, 0, 0, 0);
                ex.Width = 510;
                ex.IsExpanded = true;
                
                StackPanel spchild = new StackPanel();
                spchild.Orientation = Orientation.Vertical;
                List<string> chuong = new List<string>(Directory.GetDirectories(directories[i]));
                chuong.Sort(Comparer.sapxepChuong);
                for (int j = 0; j < chuong.Count; ++j)
                {
                    Expander exchild = new Expander();
                    string[] arrch = chuong[j].Split('\\');
                    exchild.Header = arrch[arrch.Length - 1];
                    exchild.Tag = ex.Header.ToString() + exchild.Header.ToString();
                    exchild.Margin = new Thickness(50, 0, 0, 0);
                    exchild.FontSize = 25;
                    exchild.Background = Brushes.Transparent;
                    List<string> de = new List<string>(Directory.GetDirectories(chuong[j]));
                    de.Sort(Comparer.sapxepChuong);
                    ListBox lb = new ListBox();
                    lb.BorderBrush = Brushes.Transparent;
                    lb.Background = Brushes.White;
                    for (int k = 0; k < de.Count; ++k)
                    {
                        ListBoxItem lbi = new ListBoxItem();
                        lbi.Background = Brushes.Transparent;
                        string []arr = de[k].Split('\\');
                        lbi.Content = " Bài " + arr[arr.Length - 1];
                        lbi.Tag = ex.Header.ToString() + exchild.Header.ToString() + "|" + arr[arr.Length - 1];
                        lbi.FontSize = 20;
                        lbi.Margin = new Thickness(20, 0, 0, 0);
                        lbi.MouseDoubleClick += new MouseButtonEventHandler(lbi_MouseDoubleClick);
                        lb.Items.Add(lbi);
                    }
                    exchild.Content = lb;
                    exchild.MouseDoubleClick += new MouseButtonEventHandler(exchild_MouseDoubleClick);
                    spchild.Children.Add(exchild);
                }
                ex.Content = spchild;
                ex.MouseDoubleClick += new MouseButtonEventHandler(ex_MouseDoubleClick);
                sp.Children.Add(ex);
            }
            m_MucLuc.Children.Add(sp);
            Content = m_MucLuc;
        }

        void exchild_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            isexchilddbClick = true;
            if (!islbidbClick)
            {
                Expander exchild = (Expander)sender;
                m_Parent.ChuyenDe(exchild.Tag.ToString());
            }
            else
            {
                islbidbClick = false;
            }
        }

        void ex_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!islbidbClick && !isexchilddbClick)
            {
                Expander ex = (Expander)sender;
                m_Parent.ChuyenDe(ex.Header.ToString());
            }
            else
            {
                isexchilddbClick = false;
                islbidbClick = false;
            }
        }

        void lbi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            islbidbClick = true;
            ListBoxItem lbi = (ListBoxItem)sender;
            m_Parent.ChuyenDe(lbi.Tag.ToString());
        }
    }
}
