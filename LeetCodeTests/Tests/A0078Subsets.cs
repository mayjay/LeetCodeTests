using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0078Subsets
    {
        //给定一组不含重复元素的整数数组 nums，返回该数组所有可能的子集（幂集）。
        //说明：解集不能包含重复的子集。
        //示例:
        //输入: nums = [1,2,3]
        //输出:
        //[
        //  [3],
        //  [1],
        //  [2],
        //  [1,2,3],
        //  [1,3],
        //  [2,3],
        //  [1,2],
        //  []
        //]

        public IList<IList<int>> Subsets(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            int count = (int)Math.Pow(2, nums.Length);
            for (int i = 0; i < count; i++)
            {
                List<int> list = new List<int>(nums.Length);
                int index = i;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (index % 2 == 1)
                        list.Add(nums[j]);
                    index = index / 2;
                }
                result.Add(list);
            }
            return result.ToArray();
        }

        public void Test()
        {
            int[] input = { 1, 2, 3, 4 };
            IList<IList<int>> result = Subsets(input);
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
