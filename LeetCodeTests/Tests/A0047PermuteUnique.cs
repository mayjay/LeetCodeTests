using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0047PermuteUnique
    {
        //给定一个可包含重复数字的序列，返回所有不重复的全排列。
        //示例:
        //输入: [1,1,2]
        //输出:
        //[
        //  [1,1,2],
        //  [1,2,1],
        //  [2,1,1]
        //]

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            Array.Sort(nums);
            List<List<int>> result = new List<List<int>>();
            List<int> tmp = new List<int>();
            bool[] used = new bool[nums.Length];
            DFS(result, tmp, nums, used);
            return result.ToArray();
        }

        private void DFS(List<List<int>> result, List<int> tmp, int[] nums, bool[] used)
        {
            if (tmp.Count == nums.Length)
            {
                result.Add(new List<int>(tmp));
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i]) continue;
                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;
                tmp.Add(nums[i]);
                used[i] = true;
                DFS(result, tmp, nums, used);
                used[i] = false;
                tmp.RemoveAt(tmp.Count - 1);
            }
        }

        public void Test()
        {
            int[] input = { 1, 1, 2 };
            IList<IList<int>> result = PermuteUnique(input);
            Console.WriteLine("result count " + result.Count());
            foreach (IList<int> e in result)
            {
                foreach (int num in e) Console.Write(num + " ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
