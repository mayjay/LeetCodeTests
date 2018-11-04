using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0132MinCut
    {
        //给定一个字符串 s，将 s 分割成一些子串，使每个子串都是回文串。
        //返回符合要求的最少分割次数。
        //示例:
        //输入: "aab"
        //输出: 1
        //解释: 进行一次分割就可将 s 分割成 ["aa","b"] 这样两个回文子串。

        public int MinCut(string s)
        {
            bool[,] dp = new bool[s.Length, s.Length];
            int[] cut = new int[s.Length + 1];
            for (int i = s.Length - 1; i >= 0; i--)
            {
                cut[i] = int.MaxValue;
                for (int j = i; j < s.Length; j++)
                {
                    if (s[i] == s[j] && (j - i <= 1 || dp[i + 1, j - 1]))
                    {
                        dp[i, j] = true;
                        cut[i] = Math.Min(cut[i], 1 + cut[j + 1]);
                    }
                }
            }
            return cut[0] - 1;
        }

        public int MinCut2(string s)
        {
            return MinCut(s, 0, s.Length - 1) - 1;
        }

        public int MinCut(string s, int start, int end)
        {
            if (start > end)
                return 0;
            if (IsPalindrome(s, start, end))
                return 1;
            int min = int.MaxValue;
            for (int i = start; i <= end; i++)
            {
                if (IsPalindrome(s, start, i))
                {
                    int cut = 1 + MinCut(s, i + 1, end);
                    min = Math.Min(min, cut);
                }
            }
            return min;
        }

        private bool IsPalindrome(string s, int start, int end)
        {
            int i = start, j = end;
            while (i < j)
            {
                if (s[i] != s[j])
                    return false;
                i++;
                j--;
            }
            return true;
        }

        public void Test()
        {
            string input = "fifgbeajcacehiicccfecbfhhgfiiecdcjjffbghdidbhbdbfbfjccgbbdcjheccfbhafehieabbdfeigbiaggchaeghaijfbjhi";
            int result = MinCut(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
