﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0115NumDistinct
    {
        //给定一个字符串 S 和一个字符串 T，计算在 S 的子序列中 T 出现的个数。
        //一个字符串的一个子序列是指，通过删除一些（也可以不删除）字符且不干扰剩余字符相对位置所组成的新字符串。（例如，"ACE" 是 "ABCDE" 的一个子序列，而 "AEC" 不是）
        //示例 1:
        //输入: S = "rabbbit", T = "rabbit"
        //输出: 3
        //解释:
        //如下图所示, 有 3 种可以从 S 中得到 "rabbit" 的方案。
        //(上箭头符号 ^ 表示选取的字母)
        //rabbbit
        //^^^^ ^^
        //rabbbit
        //^^ ^^^^
        //rabbbit
        //^^^ ^^^
        //示例 2:
        //输入: S = "babgbag", T = "bag"
        //输出: 5
        //解释:
        //如下图所示, 有 5 种可以从 S 中得到 "bag" 的方案。 
        //(上箭头符号 ^ 表示选取的字母)
        //babgbag
        //^^ ^
        //babgbag
        //^^    ^
        //babgbag
        //^    ^^
        //babgbag
        //  ^  ^^
        //babgbag
        //    ^^^

        public int NumDistinct(string s, string t)
        {
            if (s == null || s.Length == 0 || t == null || t.Length == 0 || s.Length < t.Length)
                return 0;
            int[,] dp = new int[s.Length + 1, t.Length + 1];
            dp[0, 0] = 1;
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j <= t.Length; j++)
                {
                    if (j == 0)
                        dp[i, j] = 1;
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                        if (s[i - 1] == t[j - 1])
                            dp[i, j] += dp[i - 1, j - 1];
                    }
                }
            }
            return dp[s.Length, t.Length];
        }

        public void Test()
        {
            string s = "rabbbit";
            string t = "rabbit";
            int result = NumDistinct(s, t);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
