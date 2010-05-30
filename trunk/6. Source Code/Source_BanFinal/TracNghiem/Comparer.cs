using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TracNghiem
{
    public class Comparer
    {
        public static int sapxepChuong(string s1, string s2)
        {
            if (s1.Length > s2.Length)
            {
                return 1;
            }

            if (s1.Length == s2.Length)
            {
                return s1.CompareTo(s2);
            }
            return -1;
        }
        public static int sapxepDe(string s1, string s2)
        {
            string[] Sp1 = s1.Split('\\', '.', '/');
            string[] Sp2 = s2.Split('\\', '.', '/');

            s1 = Sp1[Sp1.Length - 2];
            s2 = Sp2[Sp2.Length - 2];

            string[] sp1 = s1.Split('_');
            string[] sp2 = s2.Split('_');
            if (int.Parse(sp1[0]) > int.Parse(sp2[0]))
            {
                return 1;
            }
            else if (sp1[0] == sp2[0])
            {
                if (sp1.Length > sp2.Length)
                {
                    return 1;
                }

                if (sp1.Length == sp2.Length)
                {
                    if (sp1.Length == 1)
                    {
                        return 0;
                    }

                    if (int.Parse(sp1[1]) > int.Parse(sp2[1]))
                    {
                        return 1;
                    }
                }
            }
            return -1;
        }
    }
}
