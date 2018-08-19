using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0035SearchInsert
    {
        //给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
        //你可以假设数组中无重复元素。
        //示例 1:
        //输入: [1,3,5,6], 5
        //输出: 2
        //示例 2:
        //输入: [1,3,5,6], 2
        //输出: 1
        //示例 3:
        //输入: [1,3,5,6], 7
        //输出: 4
        //示例 4:
        //输入: [1,3,5,6], 0
        //输出: 0

        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0] >= target ? 0 : 1;
            if (target <= nums[0]) return 0;
            if (target > nums[nums.Length - 1]) return nums.Length;
            if (target == nums[nums.Length - 1]) return nums.Length - 1;
            int i = 0, j = nums.Length - 1;
            while (i < j)
            {
                if (i + 1 == j)
                {
                    if (nums[i] == target) return i;
                    else return j;
                }
                int middle = (i + j) / 2;
                if (target < nums[middle]) j = middle;
                else if (target > nums[middle]) i = middle;
                else return middle;
            }
            return 0;
        }

        public void Test()
        {
            int[] nums = { 1, 3, 5, 6 };
            int target = 4;
            int result = SearchInsert(nums, target);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
