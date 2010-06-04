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
    public class TracNghiem : StackPanel
    {
        List<ListBoxItem> m_DanhSachCau;
        List<bool> m_DanhSachDapAn;

        static TracNghiem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TracNghiem), new FrameworkPropertyMetadata(typeof(TracNghiem)));
        }

        public void LayCauHoi(string folder, string soThutu, int verticalTab, int horizontalTab)
        {
            m_DanhSachCau = new List<ListBoxItem>();
            List<string> files = new List<string>();
            
            //Lấy đề theo số thứ tự:
            files.Add(folder + "\\" + soThutu + ".png");
            //Lấy danh sách phương án chọn lựa theo số thứ tự:
            files.AddRange(Directory.GetFiles(folder, soThutu + "_*.png"));
            //Sắp xếp các phương án đúng theo thứ tự:
            files.Sort();
            //Lấy đáp án của câu:
            string fileDapan = folder + "\\" + soThutu + ".txt";
            m_DanhSachDapAn = new List<bool>();
            StreamReader streamReader = new StreamReader(fileDapan);
            while (!streamReader.EndOfStream)
            {
                m_DanhSachDapAn.Add(bool.Parse(streamReader.ReadLine().Trim().ToLower()));
            }
            streamReader.Close();
            //Phần đáp án dư đáp án đầu:
            m_DanhSachDapAn.RemoveAt(0);

            if (files.Count > 1)
            {
                ListBoxItem listboxItem = new ListBoxItem();
                StackPanel stackPanel = new StackPanel();
                listboxItem.Content = stackPanel;
                Image image = new Image();
                BitmapSource bitmapSource = new BitmapImage(new Uri(files[0]));
                image.Source = bitmapSource;
                image.Width = bitmapSource.Width;
                image.Height = bitmapSource.Height;
                stackPanel.Children.Add(image);
                m_DanhSachCau.Add(listboxItem);
                
                //Đếm số phần tử có giá trị bằng True trong danh sách đáp án:
                int soDapan = m_DanhSachDapAn.FindAll(
                                                        delegate(bool cauDung) 
                                                        { 
                                                            return cauDung; 
                                                        }
                                                     ).Count;

                for (int i = 1; i < files.Count; ++i)
                {
                    ListBoxItem listboxItemphuongan = new ListBoxItem();
                    StackPanel stackPanelphuongan = new StackPanel();
                    stackPanelphuongan.Orientation = Orientation.Horizontal;
                    Canvas canvas = new Canvas();
                    if (soDapan == 1)
                    {
                        RadioButton radioButton = new RadioButton();
                        radioButton.GroupName = files[0].Replace("\\", "").Replace(".", "").Replace(":", "");
                        radioButton.Width = 25;
                        radioButton.Height = 25;
                        radioButton.Margin = new Thickness(horizontalTab, verticalTab, 0, 0);
                        canvas.Width = radioButton.Width + horizontalTab;
                        canvas.Height = radioButton.Height + verticalTab;
                        canvas.Children.Add(radioButton);
                    }
                    else
                    {
                        CheckBox checkBox = new CheckBox();
                        checkBox.Width = 25;
                        checkBox.Height = 25;
                        checkBox.Margin = new Thickness(horizontalTab, verticalTab, 0, 0);
                        canvas.Width = checkBox.Width + horizontalTab;
                        canvas.Height = checkBox.Height + verticalTab;
                        canvas.Children.Add(checkBox);
                    }
                    canvas.Arrange(new Rect(0, 0, canvas.Width, canvas.Height));
                    stackPanelphuongan.Children.Add(canvas);
                    Image imagePhuongan = new Image();
                    BitmapSource bitmapSourcephuongan = new BitmapImage(new Uri(files[i]));
                    imagePhuongan.Source = bitmapSourcephuongan;
                    imagePhuongan.Width = bitmapSourcephuongan.Width;
                    imagePhuongan.Height = bitmapSourcephuongan.Height;
                    stackPanelphuongan.Children.Add(imagePhuongan);
                    listboxItemphuongan.Content = stackPanelphuongan;
                    m_DanhSachCau.Add(listboxItemphuongan);
                }
            }

            Orientation = Orientation.Vertical;
            for (int i = 0; i < m_DanhSachCau.Count; ++i)
            {
                Children.Add(m_DanhSachCau[i]);
            }
        }

        public double ChamDiem(double diem)
        {
            //Đếm số phần tử có giá trị bằng True trong danh sách đáp án:
            int soDapan = m_DanhSachDapAn.FindAll(
                                                       delegate(bool cauDung) 
                                                       { 
                                                           return cauDung; 
                                                       }
                                                 ).Count;
            bool giaiSai = false;
            for (int i = 0; i < m_DanhSachCau.Count -1 ; ++i)
            {
                ListBoxItem listboxItem = m_DanhSachCau[i + 1];
                StackPanel stackPanel = (StackPanel)listboxItem.Content;
                Canvas canvas = new Canvas();
                canvas = (Canvas)stackPanel.Children[0];
                if (soDapan == 1)
                {
                    RadioButton radioButton = (RadioButton)canvas.Children[0];
                    if (radioButton.IsChecked == true && m_DanhSachDapAn[i])
                    {
                        
                    }
                    else if (radioButton.IsChecked == true && m_DanhSachDapAn[i] == false)
                    {
                        radioButton.Background = Brushes.Red;
                        radioButton.IsChecked = false;
                        giaiSai = true;
                    }
                    else if (radioButton.IsChecked == false && m_DanhSachDapAn[i] == true)
                    {
                        radioButton.Background = Brushes.Blue;
                        radioButton.IsChecked = true;
                        giaiSai = true;
                    }
                }
                else
                {
                    CheckBox checkBox = (CheckBox)canvas.Children[0];
                    if (checkBox.IsChecked == true && m_DanhSachDapAn[i])
                    {
                        
                    }
                    else if (checkBox.IsChecked == true && m_DanhSachDapAn[i] == false)
                    {
                        checkBox.Background = Brushes.Red;
                        checkBox.IsChecked = false;
                        giaiSai = true;
                    }
                    else if (checkBox.IsChecked == false && m_DanhSachDapAn[i] == true)
                    {
                        checkBox.Background = Brushes.Blue;
                        checkBox.IsChecked = true;
                        giaiSai = true;
                    }
                }
            }
            if (giaiSai)
            {
                return 0;
            }
            return diem;
        }
    }
}
