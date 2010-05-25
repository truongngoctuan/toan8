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

namespace TracNghiem.UC
{
    public partial class UCNoiDung : UserControl
    {
        public UCNoiDung(De de, out De newDe, int startIndex, out int endIndex)
        {
            InitializeComponent();
            endIndex = 0;
            newDe = de;
            
            if (startIndex < newDe.m_DanhSachCau.Count)
            {
                double H = Height - 200;
                double h = 0;
                StackPanel sp = new StackPanel();
                if (startIndex == 0)
                {
                    TextBlock txtTieuDe = new TextBlock();
                    txtTieuDe.TextAlignment = TextAlignment.Center;
                    txtTieuDe.Text = "\r\n" + de.m_Ten;
                    txtTieuDe.FontFamily = new FontFamily("Times New Roman");
                    txtTieuDe.FontSize = 40;
                    sp.Children.Add(txtTieuDe);
                    H -= 50;
                }
                else
                {
                    Label blank = new Label();
                    blank.Opacity = 0;
                    blank.Height = 50;
                    sp.Children.Add(blank);
                }

                sp.Width = Width;
                ListBox lb = new ListBox();
                lb.BorderBrush = Brushes.Transparent;
                sp.Orientation = Orientation.Vertical;
                sp.Children.Add(lb);
                h += newDe.m_DanhSachCau[startIndex + endIndex].Height;
                while (h <= H)
                {
                    lb.Items.Add(newDe.m_DanhSachCau[startIndex + endIndex]);
                    ++endIndex;
                    if (startIndex + endIndex < newDe.m_DanhSachCau.Count)
                    {
                        h += newDe.m_DanhSachCau[startIndex + endIndex].Height;
                    }
                    else
                    {
                        break;
                    }
                }
                endIndex = startIndex + endIndex;
                Content = sp;
            }
        }
    }
}
