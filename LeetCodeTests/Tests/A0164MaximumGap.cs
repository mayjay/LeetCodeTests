using System;
namespace LeetCodeTests.Tests
{
    public class A0164MaximumGap
    {
        //给定一个无序的数组，找出数组在排序之后，相邻元素之间最大的差值。
        //如果数组元素个数小于 2，则返回 0。
        //示例 1:
        //输入: [3,6,9,1]
        //输出: 3
        //解释: 排序后的数组是[1, 3, 6, 9], 其中相邻元素(3,6) 和(6,9) 之间都存在最大差值 3。
        //示例 2:
        //输入: [10]
        //输出: 0
        //解释: 数组元素个数小于 2，因此返回 0。
        //说明:
        //你可以假设数组中所有元素都是非负整数，且数值在 32 位有符号整数范围内。
        //请尝试在线性时间复杂度和空间复杂度的条件下解决此问题。

        public int MaximumGap(int[] nums)
        {
            if (nums.Length < 2) return 0;
            int max = int.MinValue, min = int.MaxValue;
            foreach (int num in nums)
            {
                max = Math.Max(max, num);
                min = Math.Min(min, num);
            }
            if (min == max) return 0;
            int bucketNum = nums.Length;
            //each bucket record min and max
            int[,] buckets = new int[bucketNum, 2];
            for (int i = 0; i < bucketNum; i++)
            {
                buckets[i, 0] = int.MaxValue;
                buckets[i, 1] = int.MinValue;
            }
            foreach (int num in nums)
            {
                //check which bucket to put in
                long index = (long)(num - min) * (bucketNum - 1) / (max - min);
                buckets[index, 0] = Math.Min(buckets[index, 0], num);
                buckets[index, 1] = Math.Max(buckets[index, 1], num);
            }
            int maxGap = 0;
            int lastNum = 0;
            for (int i = 0; i < bucketNum; i++)
            {
                //check if empty bucket
                if (buckets[i, 0] == int.MaxValue && buckets[i, 1] == int.MinValue) continue;
                if (i > 0)
                    maxGap = Math.Max(maxGap, buckets[i, 0] - lastNum);
                lastNum = buckets[i, 1];
            }
            return maxGap;
        }

        public void Test()
        {
            int[] input = { 3, 6, 9, 1 };
            int result = MaximumGap(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
