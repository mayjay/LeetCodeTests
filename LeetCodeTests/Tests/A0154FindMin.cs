using System;
namespace LeetCodeTests.Tests
{
    public class A0154FindMin
    {
        //假设按照升序排序的数组在预先未知的某个点上进行了旋转。
        //(例如，数组[0, 1, 2, 4, 5, 6, 7] 可能变为[4, 5, 6, 7, 0, 1, 2] )。
        //请找出其中最小的元素。
        //注意数组中可能存在重复的元素。
        //示例 1：
        //输入: [1,3,5]
        //输出: 1
        //示例 2：
        //输入: [2,2,2,0,1]
        //输出: 0
        //说明：
        //这道题是 寻找旋转排序数组中的最小值 的延伸题目。
        //允许重复会影响算法的时间复杂度吗？会如何影响，为什么？

        public int FindMin(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0, j = nums.Length - 1;
            if (i == j) return nums[i];
            //in correct order
            if (nums[i] < nums[j]) return nums[i];
            while (i < j)
            {
                if (i + 1 == j)
                    return Math.Min(nums[i], nums[j]);
                int m = (i + j) / 2;
                bool minInFirstHalf = true;
                if (nums[i] == nums[m])
                {
                    if (nums[m] == nums[j])
                    {
                        //can not decide min in which part, have to handle all parts
                        int[] left = new int[m - i + 1];
                        Array.Copy(nums, left, left.Length);
                        int[] right = new int[nums.Length - left.Length];
                        Array.Copy(nums, m + 1, right, 0, right.Length);
                        return Math.Min(FindMin(left), FindMin(right));
                    }
                    else
                        //nums[m] must be larger than nums[j], otherwise the array is in correct order which is already solved
                        minInFirstHalf = false;
                }
                else if (nums[i] < nums[m])
                    minInFirstHalf = false;
                else
                    minInFirstHalf = true;
                if (minInFirstHalf)
                    j = m;
                else
                    i = m;
            }
            return nums[i];
        }

        public void Test()
        {
            int[] input = { 10, 1, 10, 10, 10 };
            int result = FindMin(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
