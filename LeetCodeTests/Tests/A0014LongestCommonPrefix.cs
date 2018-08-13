using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0014LongestCommonPrefix
    {
        //编写一个函数来查找字符串数组中的最长公共前缀。
        //如果不存在公共前缀，返回空字符串 ""。
        //示例 1:
        //输入: ["flower","flow","flight"]
        //输出: "fl"
        //示例 2:
        //输入: ["dog","racecar","car"]
        //输出: ""
        //解释: 输入不存在公共前缀。
        //说明:
        //所有输入只包含小写字母 a-z 。

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0) return "";
            if (strs.Length == 1) return strs[0];

            int minLen = int.MaxValue;
            foreach (string s in strs)
            {
                if (s.Length < minLen) minLen = s.Length;
            }
            StringBuilder commonPrefix = new StringBuilder();
            for (int i = 0; i < minLen; i++)
            {
                char commonChar = '\0';
                for(int j = 0; j < strs.Length; j++)
                {
                    if (j == 0)
                    {
                        commonChar = strs[j][i];
                    }
                    else if (commonChar == strs[j][i])
                    {
                        if (j == strs.Length - 1)
                        {
                            commonPrefix.Append(commonChar);
                        }
                    }
                    else
                    {
                        return commonPrefix.ToString();
                    }
                }
            }
            return commonPrefix.ToString();
        }

        public void Test()
        {
            string[] input = { "flower", "flow", "flight" };
            string result = LongestCommonPrefix(input);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
