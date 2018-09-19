using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0085MaximalRectangle
    {
        //给定一个仅包含 0 和 1 的二维二进制矩阵，找出只包含 1 的最大矩形，并返回其面积。
        //示例:
        //输入:
        //[
        //  ["1","0","1","0","0"],
        //  ["1","0","1","1","1"],
        //  ["1","1","1","1","1"],
        //  ["1","0","0","1","0"]
        //]
        //输出: 6

        public int MaximalRectangle(char[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int max = 0;
            //convert to 84 LargestRectangleArea
            int[,] histogram = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0)
                        histogram[i, j] = matrix[i, j] - '0';
                    else
                    {
                        if (matrix[i, j] == '1')
                            histogram[i, j] = histogram[i - 1, j] + matrix[i, j] - '0';
                        else
                            histogram[i, j] = 0;
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                int[] heights = new int[n];
                for (int j = 0; j < n; j++)
                    heights[j] = histogram[i, j];
                max = Math.Max(max, LargestRectangleArea(heights));
            }
            return max;
        }

        private int LargestRectangleArea(int[] heights)
        {
            return new A0084LargestRectangleArea().LargestRectangleArea(heights);
        }

        public void Test()
        {
            char[,] input = {
                            { '1', '0', '1', '0', '0' },
                            { '1', '0', '1', '1', '1' },
                            { '1', '1', '1', '1', '1' },
                            { '1', '0', '0', '1', '0' }
                            };
            int result = MaximalRectangle(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
