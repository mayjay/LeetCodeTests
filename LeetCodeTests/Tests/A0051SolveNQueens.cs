using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0051SolveNQueens
    {
        //n 皇后问题研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。
        //上图为 8 皇后问题的一种解法。
        //给定一个整数 n，返回所有不同的 n 皇后问题的解决方案。
        //每一种解法包含一个明确的 n 皇后问题的棋子放置方案，该方案中 'Q' 和 '.' 分别代表了皇后和空位。
        //示例:
        //输入: 4
        //输出: [
        // [".Q..",  // 解法 1
        //  "...Q",
        //  "Q...",
        //  "..Q."],
        // ["..Q.",  // 解法 2
        //  "Q...",
        //  "...Q",
        //  ".Q.."]
        //]
        //解释: 4 皇后问题存在两个不同的解法。

        public IList<IList<string>> SolveNQueens(int n)
        {
            List<List<string>> result = new List<List<string>>();
            List<int> indexList = new List<int>(n);
            DFS(result, indexList, 0);
            return result.ToArray();
        }

        private void DFS(List<List<string>> result, List<int> indexList, int row)
        {
            if (indexList.Count == indexList.Capacity)
            {
                //valid
                List<string> QList = new List<string>(indexList.Count);
                foreach (int index in indexList)
                {
                    StringBuilder sb = new StringBuilder(indexList.Count);
                    for (int i = 0; i < indexList.Count; i++)
                    {
                        if (i == index) sb.Append('Q');
                        else sb.Append('.');
                    }
                    QList.Add(sb.ToString());
                }
                result.Add(QList);
                return;
            }
            for (int i = 0; i < indexList.Capacity; i++)
            {
                if (IsValid(indexList, row, i))
                {
                    indexList.Add(i);
                    DFS(result, indexList, row + 1);
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
            IList<IList<string>> result = SolveNQueens(input);
            Console.WriteLine("result count " + result.Count());
            foreach (IList<string> e in result)
            {
                foreach (string str in e) 
                    Console.WriteLine(str);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
