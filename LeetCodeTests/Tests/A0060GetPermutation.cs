using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0060GetPermutation
    {
        //给出集合 [1,2,3,…,n]，其所有元素共有 n! 种排列。
        //按大小顺序列出所有排列情况，并一一标记，当 n = 3 时, 所有排列如下：
        //"123"
        //"132"
        //"213"
        //"231"
        //"312"
        //"321"
        //给定 n 和 k，返回第 k 个排列。
        //说明：
        //给定 n 的范围是 [1, 9]。
        //给定 k 的范围是[1,  n!]。
        //示例 1:
        //输入: n = 3, k = 3
        //输出: "213"
        //示例 2:
        //输入: n = 4, k = 9
        //输出: "2314"

        public string GetPermutation(int n, int k)
        {
            StringBuilder sb = new StringBuilder();
            List<int> nums = new List<int>(n);
            for (int i = 1; i <= n; i++) nums.Add(i);
            //k-- to convert to index
            k--;
            for (int i = n; i > 0; i--)
            {
                int divide = Factorial(i - 1);
                int index = k / divide;
                sb.Append(nums[index]);
                nums.RemoveAt(index);
                k = k % divide;
            }
            return sb.ToString();
        }

        private int Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }

        public void Test()
        {
            int n = 4;
            int k = 9;
            string result = GetPermutation(n, k);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
