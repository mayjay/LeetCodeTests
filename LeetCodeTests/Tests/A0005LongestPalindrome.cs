using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LeetCodeTests.Tests
{
    class A0005LongestPalindrome
    {
        //给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为1000。
        //示例 1：
        //输入: "babad"
        //输出: "bab"
        //注意: "aba"也是一个有效答案。
        //示例 2：
        //输入: "cbbd"
        //输出: "bb"

        public string LongestPalindrome(string s)
        {
            //Debug.Assert(s.Length <= 1000, "string too long");
            string longestPalindrome = "";
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 1; j <= s.Length - i; j++)
                {
                    //if sub string length smaller than length of longestPalindrome, just continue
                    if (j <= longestPalindrome.Length) continue;
                    if (IsPalindrome(s, i, j))
                    {
                        longestPalindrome = s.Substring(i, j);
                    }
                }
            }
            return longestPalindrome;
        }

        private bool IsPalindrome(string s, int offset, int length)
        {
            for(int i = 0; i < length / 2; i++)
            {
                if (s[i + offset] != s[length - i - 1 + offset]) return false;
            }
            return true;
        }

        public void Test()
        {
            string input = "babad";
            string result = LongestPalindrome(input);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
