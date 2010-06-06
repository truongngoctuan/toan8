using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
//using MainMenu;
using ColorSwatch;
namespace MyUnitTest
{
    [TestFixture]
    public class UnitTestSapXepChungMinh
    {
        SapXepChungMinh sapXepChungMinh = new SapXepChungMinh();
        [SetUp]
        public void KhoiTao()
        {
            sapXepChungMinh.m_Path = "DeSapXepChungMinh\\BaiTapDaiSo\\Chuong01";
            sapXepChungMinh.m_BaiHoc = 1;
            sapXepChungMinh.m_CauHoi = 1;
            sapXepChungMinh.m_Chuong = 1;
        }
        // test lay noi dung cau hoi dai so cau 1 bai 1 chuong 1.
        [Test]
        public void TestLaySoCauHoi()
        {
            sapXepChungMinh.LayDuLieuCauHoi();
            string ketQuaMongDoi = "DS_C1_B1_C1.png";
            Assert.AreEqual(ketQuaMongDoi, sapXepChungMinh.m_StrCauHoi);
        }
        // test lay dap an cua cau 1, bai 1, chuong 1 dai so
        public void TestLayDuLieuDapAn()
        {
            List<string> ketQuaMongDoi = new List<string>();
            ketQuaMongDoi.Add("DS_C1_B1_C1_DA1.png");
            ketQuaMongDoi.Add("DS_C1_B1_C1_DA2.png");
            sapXepChungMinh.LayDuLieuDapAn();
            Assert.AreEqual(ketQuaMongDoi, sapXepChungMinh.m_ListStrDapAn);
        }
    }
}