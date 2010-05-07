using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DAO;
namespace UnitTestFormDangNhap
{
    [TestFixture]
    public class FormDangNhapTest
    {
        [Test]
        public void Test_LayDanhSachPupilUser()
        {
            List<string> list = new List<string>();
            list.Add(".svn");
            list.Add("PupilUserName_1");
            list.Add("PupilUserName_2");
            Assert.AreEqual(list, DAO.PupilUserDAO.LayDanhSachPupilUser());
        }

        [Test]
        public void Test_KiemTraTenDangNhapCoTonTaiKhong()
        {
            Assert.AreEqual(true, DAO.PupilUserDAO.KiemTraTenDangNhapCoTonTaiKhong("PupilUserName_1"));
        }

        [Test]
        public void Test_LayMatKhauCuaTaiKhoan()
        {
            Assert.AreEqual("pass_1", DAO.PupilUserDAO.LayMatKhauCuaTaiKhoan("PupilUserName_1"));
        }
    }
}
