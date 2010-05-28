using System;
using System.IO;
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
using WPFMitsuControls;
using TracNghiem.UC;

namespace TracNghiem
{
    public partial class SachTracNghiem : Window
    {
        private List<De> m_QuanLyDe;
        public SachTracNghiem()
        {
            InitializeComponent();
            m_QuanLyDe = new List<De>();
            myBook.Items.Add(new UCBiaTruoc());
            myBook.Items.Add(new UCTrangTrong());
            myBook.Items.Add(new UCBiaGiaTruoc());
            myBook.Items.Add(new UCTrangTrong());
            myBook.Items.Add(new UCLoiNoiDau());
            myBook.Items.Add(new UCThuNgo());
            LayNoiDungDeBai(AppDomain.CurrentDomain.BaseDirectory + @"DeTracNghiem\DaiSo\Chuong\1");
            
            for (int i = 0; i < m_QuanLyDe.Count; ++i)
            {
                int startIndex = 0;
                myBook.Items.Add(new UCMucLuc());
                while (startIndex < m_QuanLyDe[i].m_DanhSachCau.Count)
                {
                    De de;
                    myBook.Items.Add(new UCNoiDung(m_QuanLyDe[i], out de, startIndex, out startIndex));
                    m_QuanLyDe.RemoveAt(i);
                    m_QuanLyDe.Insert(i, de);
                }
                if (myBook.Items.Count % 2 != 0)
                {
                    myBook.Items.Add(new UCTrangTrong());
                }
            }            
            myBook.Items.Add(new UCTrangTrong());
            myBook.Items.Add(new UCBiaGiaSau());
            myBook.Items.Add(new UCTrangTrong());
            myBook.Items.Add(new UCBiaSau());
        }

        private void OnLoaded(object sender, RoutedEventArgs args)
        {
            
        }

        private void LayNoiDungDeBai(string folderPath)
        {
            string[] directories = Directory.GetDirectories(folderPath);
            List<string> direcroryList = new List<string>(directories);
            direcroryList.Sort(Comparer.sapxepChuong);
            for (int i = 0; i < direcroryList.Count; ++i)
            {
                De de = new De(direcroryList[i], myBook.Width/2 - 50);
                m_QuanLyDe.Add(de);
            }
        }

        public static string CombineFileInCurrentDirectory(string fileName)
        {
            return System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), fileName);
        }

        private void AutoNextClick(object sender, RoutedEventArgs e)
        {
            myBook.AnimateToNextPage(true, 700);
            myBook.Focus();
        }

        private void AutoPreviousClick(object sender, RoutedEventArgs e)
        {
            myBook.AnimateToPreviousPage(true, 700);
            myBook.Focus();
        }
        private void DisplayModeChecked(object sender, RoutedEventArgs e)
        {
            bool result = (sender as CheckBox).IsChecked.Value;
            myBook.DisplayMode = result ? BookDisplayMode.ZoomOnPage : BookDisplayMode.Normal;
        }

        private void AutoPreviousPageClick(object sender, RoutedEventArgs e)
        {
            myBook.MoveToPreviousPage();
        }

        private void AutoNextPageClick(object sender, RoutedEventArgs e)
        {
            myBook.MoveToNextPage();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
