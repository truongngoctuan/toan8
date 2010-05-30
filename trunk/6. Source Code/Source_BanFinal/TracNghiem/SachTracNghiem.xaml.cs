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
        List<string> m_DanhSachTuaBai;
        public SachTracNghiem()
        {
            InitializeComponent();
            myBook.CurrentSheetIndex = 0;
            m_QuanLyDe = new List<De>();
            m_DanhSachTuaBai = new List<string>();
            myBook.Items.Add(new UCBiaTruoc());
            myBook.Items.Add(new UCThuNgo());

            List<string> folders = new List<string>(Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + @"Dữ liệu\"));
            folders.Sort();
            for (int i = 0; i < folders.Count; ++i)
            {
                List<string> childfolders = new List<string>(Directory.GetDirectories(folders[i]));
                string []arr = folders[i].Split('\\', '/');
                m_DanhSachTuaBai.Add(arr[arr.Length - 1]);
                for (int j = 0; j < childfolders.Count; ++j)
                {
                    LayNoiDungDeBai(childfolders[j]);
                }
            }

            UCMucLuc mucluc = new UCMucLuc(AppDomain.CurrentDomain.BaseDirectory + @"Dữ liệu");
            mucluc.m_Parent = this;
            myBook.Items.Add(mucluc);

            string prevTen = "";
            for (int i = 0; i < m_QuanLyDe.Count; ++i)
            {
                string Ten = "";
                int count = 0;
                while (m_DanhSachTuaBai[i][0] != '|')
                {
                    ++count;
                    Ten += m_DanhSachTuaBai[i] + "|";
                    UCTuaBai tuabai = new UCTuaBai(m_DanhSachTuaBai[i]);
                    tuabai.Tag = Ten.Replace("|", "");
                    myBook.Items.Add(tuabai);
                    m_DanhSachTuaBai.RemoveAt(i);
                }

                if (count == 2)
                {
                    prevTen = Ten;
                }
                else if (count == 1)
                {
                    prevTen = prevTen.Remove(prevTen.IndexOf('|') + 1);
                    prevTen += Ten;
                    Ten = prevTen;
                    UCTuaBai tuabai = (UCTuaBai)myBook.Items[myBook.Items.Count - 1];
                    tuabai.Tag = prevTen.Replace("|", "");
                }
                else
                {
                    Ten = prevTen;
                }

                Ten = Ten.Replace("|", "");
                Ten += m_DanhSachTuaBai[i];

                int startIndex = 0;
                while (startIndex < m_QuanLyDe[i].m_DanhSachCau.Count)
                {
                    De de;
                    UCNoiDung noidung = new UCNoiDung(m_QuanLyDe[i], out de, startIndex, out startIndex);
                    noidung.m_Sach = this;
                    noidung.vitriDe = i;
                    noidung.m_Ten = Ten;
                    myBook.Items.Add(noidung);
                    m_QuanLyDe.RemoveAt(i);
                    m_QuanLyDe.Insert(i, de);
                }
            }

            if (myBook.Items.Count % 2 != 0)
            {
                myBook.Items.Add(new UCTrangTrong());
            }

            myBook.Items.Add(new UCTrangTrong());
            myBook.Items.Add(new UCBiaSau());
        }

        public void HienKetQua(int vitriDe)
        {
            De de = m_QuanLyDe[vitriDe];
            int tongsoCau = 0;
            int socauSai = 0;
            bool sai = false;
            for (int i = 0; i < de.m_DanhSachCau.Count; ++i)
            {
                StackPanel sp = (StackPanel)de.m_DanhSachCau[i].Content;
                if (sp.Tag.ToString() != "de")
                {
                    Canvas cv = (Canvas)sp.Children[0];
                    if (sp.Tag.ToString() == "cb")
                    {
                        CheckBox cb = (CheckBox)cv.Children[0];
                        if (cb.IsChecked == de.m_TinhTrangCheck[i] && cb.IsChecked == true)
                        {
                            cb.Background = Brushes.Blue;
                            cv.Children.RemoveAt(0);
                            cv.Children.Insert(0, cb);
                        }
                        else if (cb.IsChecked == true && de.m_TinhTrangCheck[i] == false)
                        {
                            cb.Background = Brushes.Red;
                            cb.IsChecked = de.m_TinhTrangCheck[i];
                            cv.Children.RemoveAt(0);
                            cv.Children.Insert(0, cb);
                            if (!sai)
                            {
                                ++socauSai;
                                sai = true;
                            }
                        }
                        else if (cb.IsChecked == false && de.m_TinhTrangCheck[i] == true)
                        {
                            cb.Background = Brushes.DarkViolet;
                            cb.IsChecked = de.m_TinhTrangCheck[i];
                            cv.Children.RemoveAt(0);
                            cv.Children.Insert(0, cb);
                            if (!sai)
                            {
                                ++socauSai;
                                sai = true;
                            }
                        }
                    }
                    else if (sp.Tag.ToString() == "rd")
                    {
                        RadioButton rd = (RadioButton)cv.Children[0];
                        if (rd.IsChecked == de.m_TinhTrangCheck[i] && rd.IsChecked == true)
                        {
                            rd.Background = Brushes.Blue;
                            cv.Children.RemoveAt(0);
                            cv.Children.Insert(0, rd);
                        }
                        else if (rd.IsChecked == true && de.m_TinhTrangCheck[i] == false)
                        {
                            rd.Background = Brushes.Red;
                            rd.IsChecked = de.m_TinhTrangCheck[i];
                            cv.Children.RemoveAt(0);
                            cv.Children.Insert(0, rd);
                            if (!sai)
                            {
                                ++socauSai;
                                sai = true;
                            }
                        }
                        else if (rd.IsChecked == false && de.m_TinhTrangCheck[i] == true)
                        {
                            rd.Background = Brushes.DarkViolet;
                            rd.IsChecked = de.m_TinhTrangCheck[i];
                            cv.Children.RemoveAt(0);
                            cv.Children.Insert(0, rd);
                            if (!sai)
                            {
                                ++socauSai;
                                sai = true;
                            }
                        }
                    }
                    sp.Children.RemoveAt(0);
                    sp.Children.Insert(0, cv);
                    de.m_DanhSachCau[i].Content = sp;
                }
                else
                {
                    sai = false;
                    ++tongsoCau;
                }
            }

            if (tongsoCau > 0)    
            {
                double ddiem = 10.0 * (tongsoCau - socauSai)/ tongsoCau;
                string diem = ddiem.ToString();
                string danhgia;
                if (diem.Length > 5)
                {
                    diem = diem.Remove(5);
                }

                if (ddiem >= 9)
                {
                    danhgia = "Xuất sắc";
                }
                else if (ddiem >= 8)
                {
                    danhgia = "Giỏi";
                }
                else if (ddiem >= 7)
                {
                    danhgia = "Khá";
                }
                else if (ddiem >= 5)
                {
                    danhgia = "Trung Bình";
                }
                else if (ddiem >= 3.5)
                {
                    danhgia = "Yếu";
                }
                else
                {
                    danhgia = "Kém";
                }

                DanhGia dg = new DanhGia(diem, danhgia);
                dg.ShowDialog();
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs args)
        {
            
        }

        private void LayNoiDungDeBai(string folderPath)
        {
            string[] directories = Directory.GetDirectories(folderPath);
            List<string> direcroryList = new List<string>(directories);
            string[] arr = folderPath.Split('\\', '/');
            m_DanhSachTuaBai.Add(arr[arr.Length - 1]);
            direcroryList.Sort(Comparer.sapxepChuong);
            for (int i = 0; i < direcroryList.Count; ++i)
            {
                arr = direcroryList[i].Split('\\', '/');
                m_DanhSachTuaBai.Add("|" + arr[arr.Length -1]);
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

        public void ChuyenDe(string strDe)
        {
            for (int i = 0; i < myBook.Items.Count; ++i)
            {
                if (myBook.Items[i].ToString().IndexOf("UCNoiDung") >= 0)
                {
                    UCNoiDung noidung = (UCNoiDung)myBook.Items[i];
                    if (noidung.m_Ten == strDe)
                    {
                        myBook.CurrentSheetIndex = (i + 1) / 2;
                        break;
                    }
                }
                else if (myBook.Items[i].ToString().IndexOf("UCTuaBai") >= 0)
                {
                    UCTuaBai tuabai = (UCTuaBai)myBook.Items[i];
                    if (tuabai.Tag.ToString() == strDe)
                    {
                        myBook.CurrentSheetIndex = (i + 1) / 2;
                        break;
                    }
                }
            }
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Home)
            {
                for (int i = myBook.CurrentSheetIndex * 2 - 1; i >= 0; --i)
                {
                    if (myBook.Items[i].ToString().IndexOf("UCNoiDung") >= 0)
                    {
                        UCNoiDung noidung = (UCNoiDung)myBook.Items[i];
                        if (noidung.Tag.ToString() == "0")
                        {
                            myBook.CurrentSheetIndex = (i + 1) / 2;
                            break;
                        }
                    }
                }
            }
            else if (e.Key == Key.Down)
            {
                bool blnFlag = false;
                for (int i = myBook.CurrentSheetIndex*2; i >= 0; --i)
                {
                    if (myBook.Items[i].ToString().IndexOf("UCNoiDung") >= 0)
                    {
                        UCNoiDung noidung = (UCNoiDung)myBook.Items[i];
                        if (noidung.Tag.ToString() == "0")
                        {
                            if (blnFlag)
                            {
                                myBook.CurrentSheetIndex = (i + 1) / 2;
                                break;
                            }
                            else
                            {
                                blnFlag = true;
                            }
                        }
                    }
                }
            }
            else if (e.Key == Key.Up)
            {
                for (int i = myBook.CurrentSheetIndex * 2 + 1; i < myBook.Items.Count; ++i)
                {
                    if (myBook.Items[i].ToString().IndexOf("UCNoiDung") >= 0)
                    {
                        UCNoiDung noidung = (UCNoiDung)myBook.Items[i];
                        if (noidung.Tag.ToString() == "0")
                        {
                            myBook.CurrentSheetIndex = (i + 1) / 2;
                            break;
                        }
                    }
                }
            }
            else if (e.Key == Key.Left)
            {
                myBook.AnimateToPreviousPage(true, 700);
                myBook.Focus();
            }
            else if (e.Key == Key.Right)
            {
                myBook.AnimateToNextPage(true, 700);
                myBook.Focus();
            }
            else if (e.Key == Key.M)
            {
                for (int i = 0; i < myBook.Items.Count; ++i)
                {
                    if (myBook.Items[i].ToString().IndexOf("UCMucLuc") >= 0)
                    {
                        myBook.CurrentSheetIndex = (i + 1) / 2;
                        break;
                    }
                }
            }
        }
    }
}
