using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DAO;
using DTO;
using BUS;
namespace UnitTestFormDangNhap
{
    [TestFixture]
    public class FormDangNhapTest
    {        

        [Test]
        public void Test_LayDanhSachUser()
        {
            List<string> list = new List<string>();
            list.Add(".svn");
            list.Add("PupilUserName_1");
            list.Add("PupilUserName_2");
            Assert.AreEqual(list, DAO.UserDAO.LayDanhSachTaiKhoan(DTO.UserDTO.DuongDanThuMucPupilAccount));
        }

        [Test]
        public void Test_KiemTraTaiKhoanCoTonTaiHayKhong()
        {
            Assert.AreEqual(true, DAO.UserDAO.KiemTraTaiKhoanCoTonTaiHayKhong("TeacherUserName_1", DTO.UserDTO.DuongDanThuMucTeacherAccount));
        }

        [Test]
        public void Test_LayMatKhauCuaTaiKhoan()
        {
            Assert.AreEqual("pass_1", DAO.UserDAO.LayMatKhauCuaTaiKhoan("PupilUserName_1", DTO.UserDTO.DuongDanThuMucPupilAccount));
        }
        [Test]
        public void Test_BUS_KiemTraTaiKhoanCoTonTaiKhong()
        {
            Assert.AreEqual(1, BUS.UserBUS.KiemTraTenDangNhapCoTonTaiKhong("TeacherUserName_1"));
        }
        [Test]
        public void Test_BUS_LayMatKhauCuaTaiKhoan()
        {
            Assert.AreEqual("pass_2", BUS.UserBUS.LayMatKhauCuaTaiKhoan("TeacherUserName_2"));
        }
    }
}
