using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0077Combine
    {
        //给定两个整数 n 和 k，返回 1 ... n 中所有可能的 k 个数的组合。
        //示例:
        //输入: n = 4, k = 2
        //输出:
        //[
        //  [2,4],
        //  [3,4],
        //  [2,3],
        //  [1,2],
        //  [1,3],
        //  [1,4],
        //]

        public IList<IList<int>> Combine(int n, int k)
        {
            List<List<int>> result = new List<List<int>>();
            Combine(n, k - 1, 1, true, result, new List<int>(k));
            Combine(n, k, 1, false, result, new List<int>(k));
            return result.ToArray();
        }

        private void Combine(int n, int k, int start, bool add, List<List<int>> result, List<int> list)
        {
            if (add) list.Add(start);
            if (k == 0)
            {
                result.Add(list);
                return;
            }
            if (start + 1 <= n)
            {
                Combine(n, k - 1, start + 1, true, result, new List<int>(list));
                Combine(n, k, start + 1, false, result, new List<int>(list));
            }
        }

        public void Test()
        {
            int n = 4;
            int k = 2;
            IList<IList<int>> result = Combine(n, k);
            foreach (IList<int> list in result)
            {
                foreach (int e in list)
                    Console.Write(e + " ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
