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

namespace ColorSwatch
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ControlTracNghiem"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ControlTracNghiem;assembly=ControlTracNghiem"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class TracNghiem : StackPanel
    {
        List<ListBoxItem> Cau;
        List<bool> DapAn;
        static TracNghiem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TracNghiem), new FrameworkPropertyMetadata(typeof(TracNghiem)));
        }

        public void LayCauHoi(string folder, int htab, int wtab)
        {
            Cau = new List<ListBoxItem>();
            List<string> files = new List<string>(Directory.GetFiles(folder, "*.png"));
            files.Sort();
            string filedapan = folder + "\\Dapan.txt";
            DapAn = new List<bool>();
            StreamReader sr = new StreamReader(filedapan);
            while (!sr.EndOfStream)
            {
                DapAn.Add(bool.Parse(sr.ReadLine().Trim().ToLower()));
            }
            sr.Close();

            if (files.Count > 1)
            {
                ListBoxItem lbi = new ListBoxItem();
                StackPanel sp = new StackPanel();
                lbi.Content = sp;
                Image img = new Image();
                BitmapSource bs = new BitmapImage(new Uri(files[0]));
                img.Source = bs;
                img.Width = bs.Width;
                img.Height = bs.Height;
                sp.Children.Add(img);
                Cau.Add(lbi);
                int nDapAn = DapAn.FindAll(delegate(bool b1) { return b1;}).Count;
                for (int i = 1; i < files.Count; ++i)
                {
                    ListBoxItem lbiPhuongAn = new ListBoxItem();
                    StackPanel spPhuongAn = new StackPanel();
                    spPhuongAn.Orientation = Orientation.Horizontal;
                    Canvas cv = new Canvas();
                    if (nDapAn == 1)
                    {
                        RadioButton rd = new RadioButton();
                        rd.GroupName = files[0].Replace("\\", "").Replace(".", "").Replace(":", "");
                        rd.Width = 25;
                        rd.Height = 25;
                        rd.Margin = new Thickness(wtab, htab, 0, 0);
                        cv.Width = rd.Width + wtab;
                        cv.Height = rd.Height + htab;
                        cv.Children.Add(rd);
                    }
                    else
                    {
                        CheckBox cb = new CheckBox();
                        cb.Width = 25;
                        cb.Height = 25;
                        cb.Margin = new Thickness(wtab, htab, 0, 0);
                        cv.Width = cb.Width + wtab;
                        cv.Height = cb.Height + htab;
                        cv.Children.Add(cb);
                    }
                    cv.Arrange(new Rect(0, 0, cv.Width, cv.Height));
                    spPhuongAn.Children.Add(cv);
                    Image imgPhuongan = new Image();
                    BitmapSource bsPhuongAn = new BitmapImage(new Uri(files[i]));
                    imgPhuongan.Source = bsPhuongAn;
                    imgPhuongan.Width = bsPhuongAn.Width;
                    imgPhuongan.Height = bsPhuongAn.Height;
                    spPhuongAn.Children.Add(imgPhuongan);
                    lbiPhuongAn.Content = spPhuongAn;
                    Cau.Add(lbiPhuongAn);
                }
            }

            Orientation = Orientation.Vertical;
            for (int i = 0; i < Cau.Count; ++i)
            {
                Children.Add(Cau[i]);
            }
        }

        public double ChamDiem()
        {
            int socauDung = 0;
            int socauSai = 0;
            int nDapAn = DapAn.FindAll(delegate(bool b1) { return b1; }).Count;
            for (int i = 0; i < DapAn.Count; ++i)
            {
                ListBoxItem lbi = Cau[i + 1];
                StackPanel sp = (StackPanel)lbi.Content;
                Canvas cv = new Canvas();
                cv = (Canvas)sp.Children[0];
                
                if (nDapAn == 1)
                {
                    RadioButton rd = (RadioButton)cv.Children[0];
                    if (rd.IsChecked == true && DapAn[i])
                    {
                        ++socauDung;
                    }
                    else if (rd.IsChecked == true && DapAn[i] == false)
                    {
                        rd.Background = Brushes.Red;
                       // rd.IsChecked = false;
                        ++socauSai;
                    }
                    else if (rd.IsChecked == false && DapAn[i] == true)
                    {
                        rd.Background = Brushes.Blue;
                        rd.IsChecked = false;
                        ++socauSai;
                        //rd.IsChecked = true;
                    }
                }
                else
                {
                    CheckBox cb = (CheckBox)cv.Children[0];
                    if (cb.IsChecked == true && DapAn[i])
                    {
                        ++socauDung;
                    }
                    else if (cb.IsChecked == true && DapAn[i] == false)
                    {
                        cb.Background = Brushes.Red;
                        //cb.IsChecked = false;
                        ++socauSai;
                    }
                    else if (cb.IsChecked == false && DapAn[i] == true)
                    {
                        cb.Background = Brushes.Blue;
                        cb.IsChecked = false;
                        ++socauSai;
                     //   cb.IsChecked = true;
                    }
                }                
            }

            if (socauDung + socauSai > 0)
            {
                return socauDung * 10.0 / (socauDung + socauSai);
            }
            return 0.0;
        }
    }
}
