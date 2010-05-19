using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFMitsuControls;
using System.Windows.Xps.Packaging;
using System.IO.Packaging;
namespace ColorSwatch
{
    /// <summary>
    /// Interaction logic for HocDaiSo.xaml
    /// </summary>
    public partial class HocDaiSo : Window
    {
        int iSoBaiLiThuyet = 4;//Tuy sach
        public HocDaiSo()
        {
            InitializeComponent();
        }
        private void OnLoaded(object sender, RoutedEventArgs args)
        {
            List<int> listISoBaiHoc = new List<int>();
            int i = 0;
            for (; i < iSoBaiLiThuyet; i++)
            {
                string fileName = System.IO.Directory.GetCurrentDirectory() + "/SachDaiSo/" + (i + 1).ToString() + ".xps";
                // tạo một trang sách lý thuyết
                DocumentViewer temp = new DocumentViewer();
                //temp.Width = 480;
                //dung User control tốn nhiều tài nguyên hơn nên dùng thẳng DocumentViewer 
                //UCTrangLyThuyet trangLyThuyet = new UCTrangLyThuyet(fileName);
                XpsDocument document = new XpsDocument(fileName, System.IO.FileAccess.Read);
                FixedDocument doc = new FixedDocument();
                FixedDocumentSequence fixedDoc = document.GetFixedDocumentSequence();
                
                temp.Document = fixedDoc;
                
                this.myBook.Items.Add(temp);
                // trang bài tập: Có truyền tham số vào. đây chỉ là vi dụ
                UCTrangBaiTap trangBaiTap = new UCTrangBaiTap();
                this.myBook.Items.Add(trangBaiTap);
                listISoBaiHoc.Add(i);
            }
            listISoBaiHoc.Add(i);
            this.cbDanhSachBai.ItemsSource = listISoBaiHoc;
            this.cbDanhSachBai.SelectionChanged += new SelectionChangedEventHandler(cbDanhSachBai_SelectionChanged);
        }

        void temp_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void cbDanhSachBai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int iTrangHienTai = this.cbDanhSachBai.SelectedIndex;
            if (iTrangHienTai != -1)
            {
                //if (iTrangHienTai > myBook.CurrentSheetIndex  )
                //   myBook.AnimateToLeftSheet();
                //else
                //   myBook.AnimateToRightSheet();

                myBook.CurrentSheetIndex =  iTrangHienTai;
                
                myBook.Focus();
            }
        }
        //private void NextClick(object sender, RoutedEventArgs args)
        //{
        //    if (myBook.CurrentSheetIndex < myBook.GetItemsCount() / 2)
        //        myBook.CurrentSheetIndex++;
        //}
        //private void PreviousClick(object sender, RoutedEventArgs args)
        //{
        //    if (myBook.CurrentSheetIndex > 0)
        //        myBook.CurrentSheetIndex--;
        //}

        public static string CombineFileInCurrentDirectory(string fileName)
        {
            return System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), fileName);
        }

        //private void AutoNextClick(object sender, RoutedEventArgs e)
        //{
        //    myBook.AnimateToNextPage(cbFromTop.SelectedIndex == 0, 700);
        //    myBook.Focus();
        //}
        private void AutoNextClick(object sender, RoutedEventArgs e)
        {
            myBook.AnimateToNextPage(true, 700);
            myBook.Focus();
        }
        //private void AutoPreviousClick(object sender, RoutedEventArgs e)
        //{
        //    myBook.AnimateToPreviousPage(cbFromTop.SelectedIndex == 0, 700);
        //    myBook.Focus();
        //}
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

        private void btThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
