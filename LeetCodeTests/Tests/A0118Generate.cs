using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0118Generate
    {
        //给定一个非负整数 numRows，生成杨辉三角的前 numRows 行。
        //在杨辉三角中，每个数是它左上方和右上方的数的和。
        //示例:
        //输入: 5
        //输出:
        //[
        //     [1],
        //    [1,1],
        //   [1,2,1],
        //  [1,3,3,1],
        // [1,4,6,4,1]
        //]

        public IList<IList<int>> Generate(int numRows)
        {
            List<List<int>> result = new List<List<int>>();
            int[] lastRow = null;
            for (int i = 1; i <= numRows; i++)
            {
                int[] row = new int[i];
                for (int j = 0; j < i; j++)
                {
                    if (j == 0 || j == i - 1)
                        row[j] = 1;
                    else
                        row[j] = lastRow[j - 1] + lastRow[j];
                }
                lastRow = row;
                result.Add(new List<int>(row));
            }
            return result.ToArray();
        }

        public void Test()
        {
            int input = 5;
            IList<IList<int>> result = Generate(input);
            foreach (IList<int> list in result)
            {
                foreach (int num in list)
                    Console.Write(num + " ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
