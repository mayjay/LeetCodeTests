using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0128LongestConsecutive
    {
        //给定一个未排序的整数数组，找出最长连续序列的长度。
        //要求算法的时间复杂度为 O(n)。
        //示例:
        //输入: [100, 4, 200, 1, 3, 2]
        //输出: 4
        //解释: 最长连续序列是 [1, 2, 3, 4]。它的长度为 4。

        public int LongestConsecutive(int[] nums)
        {
            int res = 0;
            HashSet<int> s = new HashSet<int>(nums);
            foreach (int num in nums)
            {
                if (s.Remove(num))
                {
                    int pre = num - 1, next = num + 1;
                    while (s.Remove(pre)) --pre;
                    while (s.Remove(next)) ++next;
                    res = Math.Max(res, next - pre - 1);
                }
            }
            return res;
        }

        public int LongestConsecutive2(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return 1;
            HashSet<int> set = new HashSet<int>(nums);
            List<int> range = new List<int>();
            int longest = 0;
            foreach (int num in nums)
            {
                //check if in range to skip or not
                bool contains = false;
                for (int i = 0; i < range.Count; i += 2)
                {
                    if (num >= range[i] && num <= range[i + 1])
                    {
                        contains = true;
                        break;
                    }
                }
                if (contains) continue;
                int length = 1;
                int lower = num - 1;
                //lower
                while (set.Contains(lower))
                {
                    length++;
                    lower--;
                }
                //upper
                int upper = num + 1;
                while (set.Contains(upper))
                {
                    length++;
                    upper++;
                }
                //record range
                if (length > 1)
                {
                    range.Add(lower);
                    range.Add(upper);
                }
                longest = Math.Max(length, longest);
            }
            return longest;
        }

        public void Test()
        {
            int[] input = { 100, 4, 200, 1, 3, 2 };
            int result = LongestConsecutive(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
