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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;
using System.IO.Packaging;
namespace ColorSwatch
{
    /// <summary>
    /// Interaction logic for UCTrangLyThuyet.xaml
    /// </summary>
    public partial class UCTrangLyThuyet : UserControl
    {
        string strPath;
        public UCTrangLyThuyet()
        {
            InitializeComponent();
            //this.Loaded += new RoutedEventHandler(UCTrangLyThuyet_Loaded);
        }
        public UCTrangLyThuyet(string pathFile)
        {
            InitializeComponent();
            
            this.strPath = pathFile;
            
            //this.Loaded += new RoutedEventHandler(UCTrangLyThuyet_Loaded);
        }
        void UCTrangLyThuyet_Loaded(object sender, RoutedEventArgs e)
        {

            XpsDocument document = new XpsDocument(strPath, System.IO.FileAccess.Read);

            FixedDocument doc = new FixedDocument();
            FixedDocumentSequence fixedDoc = document.GetFixedDocumentSequence();

            xpsViewer.Document = fixedDoc;
            xpsViewer.FitToWidth();
        }


    }
}
