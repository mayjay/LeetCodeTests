using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0064MinPathSum
    {
        //给定一个包含非负整数的 m x n 网格，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
        //说明：每次只能向下或者向右移动一步。
        //示例:
        //输入:
        //[
        //  [1,3,1],
        //  [1,5,1],
        //  [4,2,1]
        //]
        //输出: 7
        //解释: 因为路径 1→3→1→1→1 的总和最小。

        public int MinPathSum(int[,] grid)
        {
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            int[,] dp = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                        dp[i, j] = grid[i, j];
                    else
                    {
                        if (i == 0)
                            dp[i, j] = dp[i, j - 1] + grid[i, j];
                        else if (j == 0)
                            dp[i, j] = dp[i - 1, j] + grid[i, j];
                        else
                            dp[i, j] = Math.Min(dp[i, j - 1], dp[i - 1, j]) + grid[i, j];
                    }
                }
            }
            return dp[m - 1, n - 1];
        }

        public void Test()
        {
            int[,] input = { 
                             { 1, 3, 1 },
                             { 1, 5, 1 }, 
                             { 4, 2, 1 }
                           };
            int result = MinPathSum(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
