using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0119GetRow
    {
        //给定一个非负索引 k，其中 k ≤ 33，返回杨辉三角的第 k 行。
        //在杨辉三角中，每个数是它左上方和右上方的数的和。
        //示例:
        //输入: 3
        //输出: [1,3,3,1]
        //进阶：
        //你可以优化你的算法到 O(k) 空间复杂度吗？

        public IList<int> GetRow(int rowIndex)
        {
            int[] lastRow = null;
            for (int i = 0; i <= rowIndex; i++)
            {
                int[] row = new int[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                        row[j] = 1;
                    else
                        row[j] = lastRow[j - 1] + lastRow[j];
                }
                lastRow = row;
            }
            return new List<int>(lastRow);
        }

        public void Test()
        {
            int input = 4;
            IList<int> result = GetRow(input);
            foreach (int num in result)
                Console.Write(num + " ");
            Console.ReadLine();
        }
    }
}
