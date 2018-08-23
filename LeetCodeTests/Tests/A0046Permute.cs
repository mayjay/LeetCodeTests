using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0046Permute
    {
        //给定一个没有重复数字的序列，返回其所有可能的全排列。
        //示例:
        //输入: [1,2,3]
        //输出:
        //[
        //  [1,2,3],
        //  [1,3,2],
        //  [2,1,3],
        //  [2,3,1],
        //  [3,1,2],
        //  [3,2,1]
        //]

        public IList<IList<int>> Permute(int[] nums)
        {
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
                tmp.Add(nums[i]);
                used[i] = true;
                DFS(result, tmp, nums, used);
                used[i] = false;
                tmp.RemoveAt(tmp.Count - 1);
            }
        }

        public IList<IList<int>> Permute2(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            if (nums.Length == 0) return result.ToArray();
            if (nums.Length == 1)
            {
                List<int> list = new List<int>(nums);
                result.Add(list);
                return result.ToArray();
            }
            for (int i = 2; i <= nums.Length; i++)
            {
                if (i == 2)
                {
                    List<int> list1 = new List<int>(nums.Length);
                    list1.Add(nums[0]);
                    list1.Add(nums[1]);
                    result.Add(list1);
                    List<int> list2 = new List<int>(nums.Length);
                    list2.Add(nums[1]);
                    list2.Add(nums[0]);
                    result.Add(list2);
                }
                else
                {
                    //record old count
                    int count = result.Count;
                    //clone (i - 1) * count
                    for (int j = 0; j < i - 1; j++)
                    {
                        for (int k = 0; k < count; k++)
                        {
                            List<int> cloneList = new List<int>(result[k]);
                            result.Add(cloneList);
                        }
                    }
                    //insert ist element
                    for (int index = 0; index < result.Count; index++)
                    {
                        int insertIndex = index / (result.Count / i);
                        result[index].Insert(insertIndex, nums[i - 1]);
                    }
                }
            }
            return result.ToArray();
        }

        public void Test()
        {
            int[] input = { 1, 2, 3 };
            IList<IList<int>> result = Permute(input);
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
