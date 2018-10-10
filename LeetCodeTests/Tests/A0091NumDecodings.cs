using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0091NumDecodings
    {
        //一条包含字母 A-Z 的消息通过以下方式进行了编码：
        //'A' -> 1
        //'B' -> 2
        //...
        //'Z' -> 26
        //给定一个只包含数字的非空字符串，请计算解码方法的总数。
        //示例 1:
        //输入: "12"
        //输出: 2
        //解释: 它可以解码为 "AB"（1 2）或者 "L"（12）。
        //示例 2:
        //输入: "226"
        //输出: 3
        //解释: 它可以解码为 "BZ" (2 26), "VF" (22 6), 或者 "BBF" (2 2 6) 。

        public int NumDecodings(string s)
        {
            if (s.Length == 0) return 0;
            int[] dp = new int[s.Length + 1];
            dp[0] = 1;
            if (s[0] > '9' || s[0] < '1') return 0;
            dp[1] = 1;
            for (int index = 2; index <= s.Length; index++)
            {
                //handle special condition 0
                if (s[index - 1] == '0')
                {
                    //only 10 and 20 is valid
                    if (s[index - 2] != '1' && s[index - 2] != '2') return 0;
                    //if 10 or 20, just skip these 2 characters
                    dp[index] = dp[index - 2];
                }
                else
                {
                    string sub = s.Substring(index - 2, 2);
                    int parse = int.Parse(sub);
                    //if last character is 0 when sub like 01 or 05, equals to last
                    if (parse >= 1 && parse <= 26 && s[index - 2] != '0')
                        dp[index] = dp[index - 1] + dp[index - 2];
                    else
                        dp[index] = dp[index - 1];
                }
            }
            return dp[s.Length];
        }

        public void Test()
        {
            string input = "1029";
            int result = NumDecodings(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
