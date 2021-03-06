﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0088Merge
    {
        //给定两个有序整数数组 nums1 和 nums2，将 nums2 合并到 nums1 中，使得 num1 成为一个有序数组。
        //说明:
        //初始化 nums1 和 nums2 的元素数量分别为 m 和 n。
        //你可以假设 nums1 有足够的空间（空间大小大于或等于 m + n）来保存 nums2 中的元素。
        //示例:
        //输入:
        //nums1 = [1,2,3,0,0,0], m = 3
        //nums2 = [2,5,6],       n = 3
        //输出: [1,2,2,3,5,6]

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            //traverse from end to start
            int i = m - 1;
            int j = n - 1;
            int k = nums1.Length - 1;
            while (i >= 0 || j >= 0)
            {
                if (i < 0)
                {
                    nums1[k] = nums2[j];
                    k--;
                    j--;
                }
                else if (j < 0)
                {
                    nums1[k] = nums1[i];
                    k--;
                    i--;
                }
                else
                {
                    if (nums1[i] <= nums2[j])
                    {
                        nums1[k] = nums2[j];
                        k--;
                        j--;
                    }
                    else
                    {
                        nums1[k] = nums1[i];
                        k--;
                        i--;
                    }
                }
            }
        }

        public void Test()
        {
            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int m = 3;
            int[] nums2 = { 2, 5, 6 };
            int n = 3;
            Merge(nums1, m, nums2, n);
            foreach (int e in nums1)
                Console.Write(e + " ");
            Console.ReadLine();
        }
    }
}
