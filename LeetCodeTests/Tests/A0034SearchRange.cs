using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0034SearchRange
    {
        //给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。
        //你的算法时间复杂度必须是 O(log n) 级别。
        //如果数组中不存在目标值，返回 [-1, -1]。
        //示例 1:
        //输入: nums = [5,7,7,8,8,10], target = 8
        //输出: [3,4]
        //示例 2:
        //输入: nums = [5,7,7,8,8,10], target = 6
        //输出: [-1,-1]

        public int[] SearchRange(int[] nums, int target)
        {
            int[] fail = { -1, -1 };
            if (nums.Length == 0) return fail;
            if (nums.Length == 1) return nums[0] == target ? new int[] { 0, 0 } : fail;
            int i = 0, j = nums.Length - 1;
            while (i < j)
            {
                if (i + 1 == j)
                {
                    if (nums[i] == target) return new int[] { i, nums[i + 1] == target ? i + 1: i };
                    if (nums[j] == target) return new int[]{ j, j };
                    else return fail;
                }
                int middle = (i + j) / 2;
                if (nums[middle] > target) j = middle;
                else if (nums[middle] < target) i = middle;
                else
                {
                    //be equal to target, find start and end index
                    //search from i to middle
                    int m = i, n = middle;
                    int startIndex = -1, endIndex = -1;
                    while (m < n)
                    {
                        if (m + 1 == n)
                        {
                            if (nums[m] == target)
                            {
                                startIndex = m;
                                break;
                            }
                            else if (nums[n] == target)
                            {
                                startIndex = n;
                                break;
                            }
                        }
                        int o = (m + n) / 2;
                        if (nums[o] == target)
                        {
                            if (o == m || nums[o - 1] != target)
                            {
                                startIndex = o;
                                break;
                            }
                            else
                            {
                                n = o;
                            }
                        }
                        else m = o;
                    }
                    //search from middle to j
                    m = middle; n = j;
                    while (m < n)
                    {
                        if (m + 1 == n)
                        {
                            if (nums[n] == target)
                            {
                                endIndex = n;
                                break;
                            }
                            else if (nums[m] == target)
                            {
                                endIndex = m;
                                break;
                            }
                        }
                        int o = (m + n + 1) / 2;
                        if (nums[o] == target)
                        {
                            if (o == n || nums[o + 1] != target)
                            {
                                endIndex = o;
                                break;
                            }
                            else
                            {
                                m = o;
                            }
                        }
                        else
                        {
                            n = o;
                        }
                    }
                    return new int[] { startIndex, endIndex };
                }
            }
            return fail;
        }

        public void Test()
        {
            int[] nums = { 0,0,1,2,3,3,4 };
            int target = 2;
            int[] result = SearchRange(nums, target);
            foreach (int e in result)
            {
                Console.Write(e + " ");
            }
            Console.ReadLine();
        }
    }
}
