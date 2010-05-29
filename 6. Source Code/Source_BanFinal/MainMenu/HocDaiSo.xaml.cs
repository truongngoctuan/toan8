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
using System.Xml;
using System.Xml.Linq;
using System.Linq;
namespace ColorSwatch
{
    /// <summary>
    /// Interaction logic for HocDaiSo.xaml
    /// </summary>
    public partial class HocDaiSo : Window
    {
        List<BaiHoc> listDSBaiHoc;
        List<bool> listTrangSachDaDuocTao;
        string _mpathSach;
        public HocDaiSo()
        {
            InitializeComponent();
           // KhoiTaoCuonSach();
            
        }
        public HocDaiSo(string duongDanToiSach)
        {
            InitializeComponent();
            _mpathSach = duongDanToiSach;
            KhoiTaoCuonSach();

        }
        protected void KhoiTaoCuonSach()
        {
            listDSBaiHoc = new List<BaiHoc>();

            LoadDanhSachBaiHoc();
            for (int i = 1; i < listDSBaiHoc.Count - 1; i++)//bỏ qua trang bìa và trang cuối
            {
                // tạo một trang sách lý thuyết
                TrangLyThuyet temp = new TrangLyThuyet();
                // TrangLyThuyet temp = new TrangLyThuyet(System.IO.Directory.GetCurrentDirectory()+ listDSBaiHoc[i].StrDuongDan);
                this.myBook.Items.Add(temp);
                // trang bài tập: Có truyền tham số vào. đây chỉ là vi dụ
                //UCTrangBaiTap trangBaiTap = new UCTrangBaiTap(listDSBaiHoc[i].IChuong, listDSBaiHoc[i].IBai);
                UCTrangBaiTap trangBaiTap = new UCTrangBaiTap();
                this.myBook.Items.Add(trangBaiTap);
            }
            //thêm trang cuối
            this.myBook.Items.Add(new UCTheEnd());
            //Khỏi tạo cờ đánh dấu trang nào đã được tạo
            listTrangSachDaDuocTao = new List<bool>();
            for (int i = 0; i < listDSBaiHoc.Count * 2 + 2; i++)
            {
                listTrangSachDaDuocTao.Add(false);
            }
            // listTrangSachDaDuocTao
            this.cbDanhSachBai.ItemsSource = listDSBaiHoc;
            this.cbDanhSachBai.DisplayMemberPath = "StrName";
            cbDanhSachBai.SelectedIndex = 0;
            this.cbDanhSachBai.SelectionChanged += new SelectionChangedEventHandler(cbDanhSachBai_SelectionChanged);
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            int iTrangHienTai = this.myBook.CurrentSheetIndex;
            if (iTrangHienTai+1 < listDSBaiHoc.Count - 1 )
            {

                if (listTrangSachDaDuocTao[(iTrangHienTai + 1) * 2] == false)
                {
                    UCTrangBaiTap trangBaiTap = new UCTrangBaiTap(_mpathSach,listDSBaiHoc[iTrangHienTai + 1].IChuong, listDSBaiHoc[iTrangHienTai + 1].IBai);
                    myBook.Items[(iTrangHienTai + 1) * 2] = trangBaiTap;
                }
                if (listTrangSachDaDuocTao[(iTrangHienTai + 1) * 2 - 1] == false)
                {
                    TrangLyThuyet trangLyThuyet = new TrangLyThuyet(System.IO.Directory.GetCurrentDirectory() + listDSBaiHoc[iTrangHienTai + 1].StrDuongDan);
                    myBook.Items[(iTrangHienTai + 1) * 2 - 1] = trangLyThuyet;
                }
            }
            // Nếu trang chưa được tạo thì tạo mới
            if (iTrangHienTai -1 > 0  )
            {
                if (listTrangSachDaDuocTao[(iTrangHienTai - 1) * 2 ] == false)
                {
                    UCTrangBaiTap trangBaiTap = new UCTrangBaiTap(_mpathSach,listDSBaiHoc[iTrangHienTai - 1].IChuong, listDSBaiHoc[iTrangHienTai - 1].IBai);
                    myBook.Items[(iTrangHienTai - 1) * 2] = trangBaiTap;
                }
                if (listTrangSachDaDuocTao[(iTrangHienTai - 1) * 2 - 1] == false)
                {
                    TrangLyThuyet trangLyThuyet = new TrangLyThuyet(System.IO.Directory.GetCurrentDirectory() + listDSBaiHoc[iTrangHienTai - 1].StrDuongDan);
                    myBook.Items[(iTrangHienTai - 1) * 2 - 1] = trangLyThuyet;
                }
            }
        }
        //protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        //{
        //    base.OnMouseLeftButtonUp(e);
        //    this.cbDanhSachBai.SelectedIndex = myBook.CurrentSheetIndex;
        //}
        void LoadDanhSachBaiHoc()
        {
            // thêm trang bìa
            BaiHoc bia = new BaiHoc();
            bia.StrName = "Trang bìa";
            bia.StrDuongDan = "";
            listDSBaiHoc.Add(bia);
            //thêm danh sách các bài học
            var xElement = XElement.Load(_mpathSach);
            var DSBaiHocThu = from c in xElement.Descendants("BaiHoc")
                            select c;
            if (DSBaiHocThu.Count() != 0)
            {
                for (int i = 0; i < DSBaiHocThu.Count(); i++)
                {
                    XElement baiHocLT = DSBaiHocThu.ElementAt(i);
                    BaiHoc temp = new BaiHoc();
                    try
                    {
                        temp.IBai = int.Parse(baiHocLT.Attribute("Bai").Value);
                        temp.IChuong = int.Parse(baiHocLT.Attribute("Chuong").Value);
                    }
                    catch
                    {
                        MessageBox.Show("Trong file xml Muc bai học thuộc tính Chuong,Bai Phải là số");
                    }
                    if (temp.IBai == 1)
                    {
                        temp.StrName = "Chương " + temp.IChuong.ToString()+ ":\n" + "\t" + baiHocLT.Attribute("Name").Value;
                    }
                    else
                    {
                        temp.StrName = "\t" + baiHocLT.Attribute("Name").Value;
                    }
                    temp.StrDuongDan = baiHocLT.Attribute("Source").Value;
                    
                    
                    listDSBaiHoc.Add(temp);

                }
                BaiHoc trangCuoi = new BaiHoc();
                trangCuoi.StrName = "Trang Cuối";
                trangCuoi.StrDuongDan = "";
                listDSBaiHoc.Add(trangCuoi);
            }

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
                myBook.CurrentSheetIndex = iTrangHienTai;
                if (iTrangHienTai > 0 && iTrangHienTai < listDSBaiHoc.Count -1 && listTrangSachDaDuocTao[iTrangHienTai * 2]==false)
                {
                    
                    UCTrangBaiTap trangBaiTap = new UCTrangBaiTap(_mpathSach, listDSBaiHoc[iTrangHienTai].IChuong, listDSBaiHoc[iTrangHienTai].IBai);
                    myBook.Items[iTrangHienTai * 2] = trangBaiTap;
                }
                // Nếu trang chưa được tạo thì tạo mới
                if (iTrangHienTai > 0 && iTrangHienTai < listDSBaiHoc.Count - 1 && listTrangSachDaDuocTao[iTrangHienTai * 2 - 1] == false)
                {
                    TrangLyThuyet trangLyThuyet = new TrangLyThuyet(System.IO.Directory.GetCurrentDirectory() + listDSBaiHoc[iTrangHienTai].StrDuongDan);
                    myBook.Items[iTrangHienTai * 2 - 1] = trangLyThuyet;
                }
                
                
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
            myBook.AnimateToNextPage(true, 400);
            
            cbDanhSachBai.SelectedIndex = myBook.CurrentSheetIndex + 1;
            myBook.Focus();
        }
        //private void AutoPreviousClick(object sender, RoutedEventArgs e)
        //{
        //    myBook.AnimateToPreviousPage(cbFromTop.SelectedIndex == 0, 700);
        //    myBook.Focus();
        //}
        private void AutoPreviousClick(object sender, RoutedEventArgs e)
        {
            myBook.AnimateToPreviousPage(true, 400);
            cbDanhSachBai.SelectedIndex = myBook.CurrentSheetIndex - 1;
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
    public class BaiHoc
    {
        string _strDuongDan;

        public string StrDuongDan
        {
            get { return _strDuongDan; }
            set { _strDuongDan = value; }
        }
        string _strName;

        public string StrName
        {
            get { return _strName; }
            set { _strName = value; }
        }
        int iChuong;

        public int IChuong
        {
            get { return iChuong; }
            set { iChuong = value; }
        }
        int iBai;

        public int IBai
        {
            get { return iBai; }
            set { iBai = value; }
        }
    }
}
