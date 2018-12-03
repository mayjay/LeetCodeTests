using System;
using System.Collections.Generic;

namespace LeetCodeTests.Tests
{
    public class A0152MaxProduct
    {
        //给定一个整数数组 nums ，找出一个序列中乘积最大的连续子序列（该序列至少包含一个数）。
        //示例 1:
        //输入: [2,3,-2,4]
        //输出: 6
        //解释: 子数组[2, 3] 有最大乘积 6。
        //示例 2:
        //输入: [-2,0,-1]
        //输出: 0
        //解释: 结果不能为 2, 因为[-2, -1] 不是子数组。

        public int MaxProduct(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int maxEnd = nums[0];
            int minEnd = nums[0];
            int maxResult = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                int end1 = maxEnd * nums[i];
                int end2 = minEnd * nums[i];
                maxEnd = Math.Max(Math.Max(end1, end2), nums[i]);
                minEnd = Math.Min(Math.Min(end1, end2), nums[i]);
                maxResult = Math.Max(maxResult, maxEnd);
            }
            return maxResult;
        }

        public int MaxProduct2(int[] nums)
        {
            if (nums.Length == 0) return 0;
            return MaxProduct(nums, 0, nums.Length - 1);
        }

        public int MaxProduct(int[] nums, int start, int end)
        {
            if (end - start == 0) return nums[start];
            //find 0
            for (int i = start; i <= end; i++)
            {
                if (nums[i] == 0)
                {
                    if (i == start)
                        return Math.Max(0, MaxProduct(nums, start + 1, end));
                    else if (i == end)
                        return Math.Max(0, MaxProduct(nums, start, end - 1));
                    else
                        return Math.Max(0, Math.Max(MaxProduct(nums, start, i - 1), MaxProduct(nums, i + 1, end)));
                }
            }
            //remove 1s first, then remove sibling even -1s
            List<int> numList = new List<int>(nums.Length);
            bool hasOne = false;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1) hasOne = true;
                else numList.Add(nums[i]);
            }
            if (hasOne)
                numList.Add(1);
            nums = numList.ToArray();
            numList.Clear();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == -1 && i < nums.Length - 1 && nums[i + 1] == -1) i++;
                else numList.Add(nums[i]);
            }
            //if no element, presents all numbers -1
            if (numList.Count == 0)
                return 1;
            nums = numList.ToArray();
            int[,] products = new int[nums.Length, nums.Length];
            for (int i = 0; i < nums.Length; i++)
                products[i, i] = nums[i];
            for (int i = 0; i < nums.Length; i++)
                for (int j = i + 1; j < nums.Length; j++)
                    products[i, j] = products[i, j - 1] * nums[j];
            int max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
                for (int j = i; j < nums.Length; j++)
                    if (products[i, j] > max)
                        max = products[i, j];
            return max;
        }

        public void Test()
        {
            int[] input = { -2, 0, -1 };
            int result = MaxProduct(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
