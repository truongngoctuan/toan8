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
using System.Windows.Xps.Packaging;
namespace ColorSwatch
{
    public class TrangLyThuyet:DocumentViewer
    {
        public TrangLyThuyet(string Path)
        {
            XpsDocument document = new XpsDocument(Path, System.IO.FileAccess.Read);
            FixedDocument doc = new FixedDocument();
            FixedDocumentSequence fixedDoc = document.GetFixedDocumentSequence();
            this.Document = fixedDoc;
        }
        public TrangLyThuyet()
        { 
        }
    }
}
