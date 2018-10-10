using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0096NumTrees
    {
        //给定一个整数 n，求以 1 ... n 为节点组成的二叉搜索树有多少种？
        //示例:
        //输入: 3
        //输出: 5
        //解释:
        //给定 n = 3, 一共有 5 种不同结构的二叉搜索树:
        //   1         3     3      2      1
        //    \       /     /      / \      \
        //     3     2     1      1   3      2
        //    /     /       \                 \
        //   2     1         2                 3

        public int NumTrees(int n)
        {
            if (n <= 1) return 1;
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    dp[i] += dp[j - 1] * dp[i - j];
                }
            }
            return dp[n];
        }

        public void Test()
        {
            int input = 1;
            int result = NumTrees(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
