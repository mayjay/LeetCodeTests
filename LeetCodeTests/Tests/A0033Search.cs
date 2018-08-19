using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0033Search
    {
        //假设按照升序排序的数组在预先未知的某个点上进行了旋转。
        //( 例如，数组 [0,1,2,4,5,6,7] 可能变为 [4,5,6,7,0,1,2] )。
        //搜索一个给定的目标值，如果数组中存在这个目标值，则返回它的索引，否则返回 -1 。
        //你可以假设数组中不存在重复的元素。
        //你的算法时间复杂度必须是 O(log n) 级别。
        //示例 1:
        //输入: nums = [4,5,6,7,0,1,2], target = 0
        //输出: 4
        //示例 2:
        //输入: nums = [4,5,6,7,0,1,2], target = 3
        //输出: -1

        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;
            int i = 0, j = nums.Length - 1;
            while (i < j)
            {
                if (i + 1 == j)
                {
                    if (nums[i] == target) return i;
                    if (nums[j] == target) return j;
                    else return -1;
                }
                int middle = (i + j) / 2;
                if (nums[i] < nums[middle])
                {
                    if (target >= nums[i] && target <= nums[middle]) j = middle;
                    else i = middle;
                }
                else
                {
                    if (target >= nums[middle] && target <= nums[j]) i = middle;
                    else j = middle;
                }
            }
            return -1;
        }

        public void Test()
        {
            int[] nums = { 1, 3 };
            int target = 2;
            int result = Search(nums, target);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
