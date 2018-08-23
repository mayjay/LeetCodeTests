using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0053MaxSubArray
    {
        //给定一个整数数组 nums ，找到一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。
        //示例:
        //输入: [-2,1,-3,4,-1,2,1,-5,4],
        //输出: 6
        //解释: 连续子数组 [4,-1,2,1] 的和最大，为 6。
        //进阶:
        //如果你已经实现复杂度为 O(n) 的解法，尝试使用更为精妙的分治法求解。

        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int sum = 0, maxSum = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (sum >= 0) sum += nums[i];
                else sum = nums[i];
                if (sum > maxSum) maxSum = sum;
            }
            return maxSum;
        }

        public void Test()
        {
            int[] input = { 8,-19,5,-4,20 };
            int result = MaxSubArray(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
