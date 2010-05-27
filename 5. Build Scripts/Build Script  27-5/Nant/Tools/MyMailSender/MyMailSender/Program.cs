using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMailSender;

namespace MyMailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] cmdline = Environment.GetCommandLineArgs(); // Get the command line parameter
            if (cmdline.Length == 7)
            {
                MyMailSender.MailSender a = new MailSender();
                a.SendEmail(cmdline[1], cmdline[2], cmdline[3], cmdline[4], cmdline[5], System.Web.Mail.MailFormat.Text, cmdline[6]);
            }
        }
    }
}
