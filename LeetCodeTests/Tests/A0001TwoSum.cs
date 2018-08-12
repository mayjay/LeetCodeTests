using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0001TwoSum
    {
        //给定一个整数数组和一个目标值，找出数组中和为目标值的两个数。
        //你可以假设每个输入只对应一种答案，且同样的元素不能被重复利用。
        //示例:
        //给定 nums = [], target = 9
        //因为 nums[0] + nums[1] = 2 + 7 = 9
        //所以返回 [0, 1]

        public int[] TwoSum(int[] nums, int target)
        {
            int[] ret = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        ret[0] = i;
                        ret[1] = j;
                        break;
                    }
                }
            }
            return ret;
        }

        public void Test()
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;
            int[] result = TwoSum(nums, target);
            foreach (int i in result)
            {
                Console.Write(i + " ");
            }
            Console.ReadLine();
        }
    }
}
