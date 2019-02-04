using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0189Rotate
    {
        //给定一个数组，将数组中的元素向右移动 k 个位置，其中 k 是非负数。
        //示例 1:
        //输入: [1,2,3,4,5,6,7] 和 k = 3
        //输出: [5,6,7,1,2,3,4]
        //解释:
        //向右旋转 1 步: [7,1,2,3,4,5,6]
        //向右旋转 2 步: [6,7,1,2,3,4,5]
        //向右旋转 3 步: [5,6,7,1,2,3,4]
        //示例 2:
        //输入: [-1,-100,3,99] 和 k = 2
        //输出: [3,99,-1,-100]
        //解释: 
        //向右旋转 1 步: [99,-1,-100,3]
        //向右旋转 2 步: [3,99,-1,-100]
        //说明:
        //尽可能想出更多的解决方案，至少有三种不同的方法可以解决这个问题。
        //要求使用空间复杂度为 O(1) 的原地算法。

        public void Rotate(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0) return;
            k = k % nums.Length;
            if (k == 0) return;
            for (int i = 0; i < k; i++)
            {
                int tmp = nums[nums.Length - 1];
                for (int j = nums.Length - 1; j >= 0; j--)
                {
                    if (j == 0)
                        nums[j] = tmp;
                    else
                        nums[j] = nums[j - 1];
                }
            }
        }

        public void Test()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            Rotate(nums, k);
            foreach (int num in nums)
                Console.Write(num + " ");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
