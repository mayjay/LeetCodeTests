using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0052TotalNQueens
    {
        //n 皇后问题研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。
        //上图为 8 皇后问题的一种解法。
        //给定一个整数 n，返回 n 皇后不同的解决方案的数量。
        //示例:
        //输入: 4
        //输出: 2
        //解释: 4 皇后问题存在如下两个不同的解法。
        //[
        // [".Q..",  // 解法 1
        //  "...Q",
        //  "Q...",
        //  "..Q."],
        // ["..Q.",  // 解法 2
        //  "Q...",
        //  "...Q",
        //  ".Q.."]
        //]

        public int TotalNQueens(int n)
        {
            //IList<IList<string>> result = new A0051SolveNQueens().SolveNQueens(n);
            //return result.Count;
            int result = 0;
            List<int> indexList = new List<int>(n);
            DFS(ref result, indexList, 0);
            return result;
        }
        private void DFS(ref int result, List<int> indexList, int row)
        {
            if (indexList.Count == indexList.Capacity)
            {
                result++;
                return;
            }
            for (int i = 0; i < indexList.Capacity; i++)
            {
                if (IsValid(indexList, row, i))
                {
                    indexList.Add(i);
                    DFS(ref result, indexList, row + 1);
                    indexList.RemoveAt(indexList.Count - 1);
                }
            }
        }

        private bool IsValid(List<int> indexList, int row, int column)
        {
            for (int index = 0; index < indexList.Count; index++)
            {
                if (indexList[index] == column || Math.Abs(column - indexList[index]) == row - index)
                    return false;
            }
            return true;
        }

        public void Test()
        {
            int input = 8;
            int result = TotalNQueens(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
