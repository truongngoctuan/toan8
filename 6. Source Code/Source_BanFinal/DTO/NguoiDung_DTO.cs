using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace DTO
{
    public class NguoiDung_DTO
    {

        public static string DuongDanThuMucAccount = "Account";
        public static string DuongDanThuMucTeacherAccount = string.Concat(DuongDanThuMucAccount, "/TeacherUserAccount");
        public static string DuongDanThuMucPupilAccount = string.Concat(DuongDanThuMucAccount, "/PupilUserAccount");
        private string m_UserName;
        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }

        private string m_Password;
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        private string m_HoTen;
        public string HoTen
        {
            get { return m_HoTen; }
            set { m_HoTen = value; }
        }

        private string m_Email;
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        private string m_Truong;
        public string Truong
        {
            get { return m_Truong; }
            set { m_Truong = value; }
        }

        private string m_Lop;
        public string Lop
        {
            get { return m_Lop; }
            set { m_Lop = value; }
        }

        private int m_LoaiNguoiDung;
        public int LoaiNguoiDung
        {
            get { return m_LoaiNguoiDung; }
            set { m_LoaiNguoiDung = value; }
        }

        public NguoiDung_DTO()
        {            
            m_UserName = string.Empty;
            m_Password = string.Empty;
            m_HoTen = string.Empty;
            m_Truong = string.Empty;
            m_Lop = string.Empty;
            m_Email = string.Empty;
            m_LoaiNguoiDung = 1;
        }
    }
}
