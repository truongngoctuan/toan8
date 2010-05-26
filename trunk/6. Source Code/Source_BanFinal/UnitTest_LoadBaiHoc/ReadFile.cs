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
using System.IO;

namespace ChonVaHienThiBaiHoc
{
    public class ReadFile
    {
        public string[] LoadFiles()
        {
            string[] filename = System.IO.Directory.GetFiles(@"Lessons\\");
            return filename;
        }

        public int LoadRTFPackage(string _fileName, RichTextBox _richtext)
        {
            if (_fileName != "")
            {
                TextRange range;
                FileStream fStream;
                _richtext.IsReadOnly = true;
                string strPath = System.IO.Directory.GetCurrentDirectory() + _fileName;
                if (File.Exists(strPath))
                {
                    range = new TextRange(_richtext.Document.ContentStart, _richtext.Document.ContentEnd);
                    fStream = new FileStream(strPath, FileMode.OpenOrCreate);
                    range.Load(fStream, DataFormats.Rtf);
                    fStream.Close();
                }

                return 1;
            }
            return 0;            
        }
    }
}
