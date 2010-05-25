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

        private string m_Ten;
        public string Ten
        {
            get { return m_Ten; }
            set { m_Ten = value; }
        }

        private string m_Ho;
        public string Ho
        {
            get { return m_Ho; }
            set { m_Ho = value; }
        }

        private string m_Email;
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        public NguoiDung_DTO()
        {            
            m_UserName = string.Empty;
            m_Password = string.Empty;
            m_Ten = string.Empty;
            m_Ho = string.Empty;
            m_Email = string.Empty;
        }
    }
}
