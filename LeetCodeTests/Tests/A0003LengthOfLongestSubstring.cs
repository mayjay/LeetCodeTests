using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0003LengthOfLongestSubstring
    {
        //给定一个字符串，找出不含有重复字符的最长子串的长度。
        //示例：
        //给定 "abcabcbb" ，没有重复字符的最长子串是 "abc" ，那么长度就是3。
        //给定 "bbbbb" ，最长的子串就是 "b" ，长度是1。
        //给定 "pwwkew" ，最长子串是 "wke" ，长度是3。请注意答案必须是一个子串，"pwke" 是子序列而不是子串。

        public int LengthOfLongestSubstring(string s)
        {
            int maxLength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 1; j <= s.Length - i; j++)
                {
                    //if sub string length smaller than maxLength, just continue
                    if (j < maxLength) continue;
                    string subStr = s.Substring(i, j);
                    if (Nonredundant(subStr))
                    {
                        maxLength = subStr.Length;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return maxLength;
        }

        private bool Nonredundant(string s)
        {
            HashSet<char> set = new HashSet<char>();
            for(int i = 0; i < s.Length; i++)
            {
                if(!set.Add(s[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public void Test()
        {
            string input = "abcabcbb";
            int result = LengthOfLongestSubstring(input);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
