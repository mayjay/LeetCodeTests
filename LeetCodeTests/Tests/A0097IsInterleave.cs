using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0097IsInterleave
    {
        //给定三个字符串 s1, s2, s3, 验证 s3 是否是由 s1 和 s2 交错组成的。
        //示例 1:
        //输入: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
        //输出: true
        //示例 2:
        //输入: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
        //输出: false

        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;
            bool[,] dp = new bool[s1.Length + 1, s2.Length + 1];
            int row = dp.GetLength(0);
            int column = dp.GetLength(1);
            dp[0, 0] = true;
            for (int i = 1; i < row; i++)
                dp[i, 0] = dp[i - 1, 0] && s3[i - 1] == s1[i - 1];
            for (int j = 1; j < column; j++)
                dp[0, j] = dp[0, j - 1] && s3[j - 1] == s2[j - 1];
            for (int i = 1; i < row; i++)
                for (int j = 1; j < column; j++)
                    dp[i, j] = (dp[i, j - 1] && s3[j - 1 + i] == s2[j - 1]) || (dp[i - 1, j] && s3[i - 1 + j] == s1[i - 1]);
            return dp[s1.Length, s2.Length];
        }

        public void Test()
        {
            string s1 = "aabcc";
            string s2 = "dbbca";
            string s3 = "aadbbcbcac";
            bool result = IsInterleave(s1, s2, s3);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
