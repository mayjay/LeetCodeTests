using System;
namespace LeetCodeTests.Tests
{
    public class A0153FindMin
    {
        //假设按照升序排序的数组在预先未知的某个点上进行了旋转。
        //(例如，数组[0, 1, 2, 4, 5, 6, 7] 可能变为[4, 5, 6, 7, 0, 1, 2] )。
        //请找出其中最小的元素。
        //你可以假设数组中不存在重复元素。
        //示例 1:
        //输入: [3,4,5,1,2]
        //输出: 1
        //示例 2:
        //输入: [4,5,6,7,0,1,2]
        //输出: 0

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
                if (nums[i] < nums[m])
                {
                    //first half in order
                    i = m;
                }
                else
                {
                    //min in first half
                    j = m;
                }
            }
            return nums[i];
        }

        public void Test()
        {
            int[] input = { 1, 2, 3 };
            int result = FindMin(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
