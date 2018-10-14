using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0120MinimumTotal
    {
        //给定一个三角形，找出自顶向下的最小路径和。每一步只能移动到下一行中相邻的结点上。
        //例如，给定三角形：
        //[
        //     [2],
        //    [3,4],
        //   [6,5,7],
        //  [4,1,8,3]
        //]
        //自顶向下的最小路径和为 11（即，2 + 3 + 5 + 1 = 11）。
        //说明：
        //如果你可以只使用 O(n) 的额外空间（n 为三角形的总行数）来解决这个问题，那么你的算法会很加分。

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle == null) return 0;
            //update each row
            for (int i = 1; i < triangle.Count; i++)
            {
                IList<int> lastRow = triangle[i - 1];
                IList<int> row = triangle[i];
                for (int j = 0; j < row.Count; j++)
                {
                    if (j == 0)
                        row[j] += lastRow[j];
                    else if (j == row.Count - 1)
                        row[j] += lastRow[j - 1];
                    else
                        row[j] += Math.Min(lastRow[j - 1], lastRow[j]);
                }
            }
            //find minimum of last row
            IList<int> last = triangle.Last();
            int min = int.MaxValue;
            foreach (int num in last)
                min = Math.Min(num, min);
            return min;
        }

        public void Test()
        {
            List<List<int>> input = new List<List<int>>();
            input.Add(new List<int>(new int[] { 2 }));
            input.Add(new List<int>(new int[] { 3, 4 }));
            input.Add(new List<int>(new int[] { 6, 5, 7 }));
            input.Add(new List<int>(new int[] { 4, 1, 8, 3 }));
            int result = MinimumTotal(input.ToArray());
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
