using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0044IsMatch
    {
        //给定一个字符串 (s) 和一个字符模式 (p) ，实现一个支持 '?' 和 '*' 的通配符匹配。
        //'?' 可以匹配任何单个字符。
        //'*' 可以匹配任意字符串（包括空字符串）。
        //两个字符串完全匹配才算匹配成功。
        //说明:
        //s 可能为空，且只包含从 a-z 的小写字母。
        //p 可能为空，且只包含从 a-z 的小写字母，以及字符 ? 和 *。
        //示例 1:
        //输入:
        //s = "aa"
        //p = "a"
        //输出: false
        //解释: "a" 无法匹配 "aa" 整个字符串。
        //示例 2:
        //输入:
        //s = "aa"
        //p = "*"
        //输出: true
        //解释: '*' 可以匹配任意字符串。
        //示例 3:
        //输入:
        //s = "cb"
        //p = "?a"
        //输出: false
        //解释: '?' 可以匹配 'c', 但第二个 'a' 无法匹配 'b'。
        //示例 4:
        //输入:
        //s = "adceb"
        //p = "*a*b"
        //输出: true
        //解释: 第一个 '*' 可以匹配空字符串, 第二个 '*' 可以匹配字符串 "dce".
        //示例 5:
        //输入:
        //s = "acdcb"
        //p = "a*c?b"
        //输入: false

        public bool IsMatch(string s, string p)
        {
            p = Trim(p);
            int sCur = 0, pCur = 0, sStar = -1, pStar = -1;
            //traverse s
            while (sCur < s.Length)
            {
                if (pCur <= p.Length - 1 && (s[sCur] == p[pCur] || p[pCur] == '?'))
                {
                    sCur++;
                    pCur++;
                }
                else if (pCur <= p.Length - 1 && p[pCur] == '*')
                {
                    pStar = pCur;
                    pCur++;
                    sStar = sCur;
                }
                else if (pStar >= 0)
                {
                    pCur = pStar + 1;
                    sStar++;
                    sCur = sStar;
                }
                else return false;
            }
            //handle rest of p
            while (pCur < p.Length)
            {
                if (p[pCur] == '*') pCur++;
                else break;
            }
            return pCur == p.Length;
        }

        private string Trim(string p)
        {
            //remove repeat *
            StringBuilder sb = new StringBuilder(p.Length);
            for (int i = 0; i < p.Length; i++)
            {
                if (i == 0 || p[i] != '*') sb.Append(p[i]);
                else if (i > 0 && p[i - 1] != '*') sb.Append(p[i]);
            }
            return sb.ToString();
        }

        public void Test()
        {
            string s = "abcde";
            string p = "*?*?*?*?";
            bool result = IsMatch(s, p);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
