using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0031NextPermutation
    {
        //实现获取下一个排列的函数，算法需要将给定数字序列重新排列成字典序中下一个更大的排列。
        //如果不存在下一个更大的排列，则将数字重新排列成最小的排列（即升序排列）。
        //必须原地修改，只允许使用额外常数空间。
        //以下是一些例子，输入位于左侧列，其相应输出位于右侧列。
        //1,2,3 → 1,3,2
        //3,2,1 → 1,2,3
        //1,1,5 → 1,5,1

        public void NextPermutation(int[] nums)
        {
            //从后往前遍历数组，找到当前节点右侧第一个比当前节点大的数，交换他们，然后使当前右侧有序即可。 
            //假设数组nums长度为n（从0开始编号），数组中nums[i]到第nums[n-1]逆序（降序排列），且nums[i-1]<nums[i]，则下一个全排列时只需要考虑nums[i-1]到nums[n-1]即可，在i-1 右侧找到第一个大于nums[i-1] 的数，交换他们顺序，则后面升序排列就是最小的数，即下一个全排列
            int anchorIndex = -1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1])
                {
                    anchorIndex = i;
                    break;
                }
            }
            if (anchorIndex == -1)
            {
                //biggest number
                List<int> sortList = new List<int>(nums);
                sortList.Sort();
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = sortList[i];
                }
            }
            else
            {
                int swapIndex = nums.Length - 1;
                int minSwapNum = int.MaxValue;
                for (int i = anchorIndex + 1; i < nums.Length; i++)
                {
                    if (nums[i] > nums[anchorIndex] && nums[i] < minSwapNum)
                    {
                        swapIndex = i;
                        minSwapNum = nums[i];
                    }
                }
                //swap value of anchorIndex and swapIndex
                int tmp = nums[anchorIndex];
                nums[anchorIndex] = nums[swapIndex];
                nums[swapIndex] = tmp;
                //sort right part of array
                int[] rightNums = new int[nums.Length - 1 - anchorIndex];
                for (int i = 0; i < rightNums.Length; i++)
                {
                    rightNums[i] = nums[i + anchorIndex + 1];
                }
                List<int> rightSortList = new List<int>(rightNums);
                rightSortList.Sort();
                for (int i = 0; i < rightNums.Length; i++)
                {
                    nums[i + anchorIndex + 1] = rightSortList[i];
                }
            }
        }

        public void Test()
        {
            int[] nums = { 1, 2, 3 };
            NextPermutation(nums);
            foreach (int e in nums)
            {
                Console.Write(e + " ");
            }
            Console.ReadLine();
        }
    }
}
