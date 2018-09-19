using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0090SubsetsWithDup
    {
        //给定一个可能包含重复元素的整数数组 nums，返回该数组所有可能的子集（幂集）。
        //说明：解集不能包含重复的子集。
        //示例:
        //输入: [1,2,2]
        //输出:
        //[
        //  [2],
        //  [1],
        //  [1,2,2],
        //  [2,2],
        //  [1,2],
        //  []
        //]

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            //sort at first
            Array.Sort(nums);
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
            //try sort by count
            Comparison<List<int>> comp = new Comparison<List<int>>((List<int> list1, List<int> list2) =>
            {
                return list1.Count - list2.Count;
            });
            result.Sort(comp);
            //remove duplicate
            List<List<int>> newList = new List<List<int>>(result.Count);
            foreach (List<int> list in result)
            {
                bool duplicate = false;
                foreach (List<int> existList in newList)
                {
                    if (EqualList(list, existList))
                    {
                        duplicate = true;
                        break;
                    }
                }
                if (!duplicate)
                    newList.Add(list);
            }
            return newList.ToArray();
        }

        private bool EqualList(List<int> list1, List<int> list2)
        {
            if (list1.Count != list2.Count) return false;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                    return false;
            }
            return true;
        }

        public void Test()
        {
            int[] input = { 4, 4, 4, 1, 4 };
            IList<IList<int>> result = SubsetsWithDup(input);
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
