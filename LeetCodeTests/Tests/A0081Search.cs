using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0081Search
    {
        //假设按照升序排序的数组在预先未知的某个点上进行了旋转。
        //( 例如，数组 [0,0,1,2,2,5,6] 可能变为 [2,5,6,0,0,1,2] )。
        //编写一个函数来判断给定的目标值是否存在于数组中。若存在返回 true，否则返回 false。
        //示例 1:
        //输入: nums = [2,5,6,0,0,1,2], target = 0
        //输出: true
        //示例 2:
        //输入: nums = [2,5,6,0,0,1,2], target = 3
        //输出: false
        //进阶:
        //这是 搜索旋转排序数组 的延伸题目，本题中的 nums  可能包含重复元素。
        //这会影响到程序的时间复杂度吗？会有怎样的影响，为什么？

        public bool Search(int[] nums, int target)
        {
            //remove duplicates
            List<int> list = new List<int>(nums.Length);
            for (int index = 0; index < nums.Length; index++)
            {
                if (index == 0)
                    list.Add(nums[index]);
                else if (nums[index] != list.Last())
                    list.Add(nums[index]);
            }
            //check last element and avoid remove all elements
            if (list.Count > 1 && list.First() == list.Last())
                list.RemoveAt(0);
            nums = list.ToArray();
            if (nums.Length == 0) return false;
            if (nums.Length == 1) return nums[0] == target;
            int i = 0, j = nums.Length - 1;
            while (i < j)
            {
                if (i + 1 == j)
                {
                    if (nums[i] == target) return true;
                    if (nums[j] == target) return true;
                    else return false;
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
            return false;
        }

        public void Test()
        {
            int[] nums = {  };
            int target = 1;
            bool result = Search(nums, target);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
