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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using NUnit.Framework;


namespace UnitTest
{
    [TestFixture]
    public class ClassToTest
    {
        //Test ham LoadFile
        [Test]
        public void UNitTest_LoadFile()
        {
            ReadFile rf = new ReadFile();
            string[] filename = rf.LoadFiles();
            Assert.AreEqual("Lessons\\chuong1.rtf", filename[0]);
        }

        //Test ham LoadRTFPackage
        [Test]
        public void UNitTest_LoadRTFPackage()
        {
            ReadFile rf = new ReadFile();
            string[] filename = rf.LoadFiles();
            string path = "\\" + filename[0];

           // ChonVaHienThiBaiHoc.Window1 ch = new Window1();
           
           // Assert.AreEqual(1,  rf.LoadRTFPackage(path, ch.return_Rich()));
        }
    }
}
