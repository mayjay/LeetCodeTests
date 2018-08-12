using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0004FindMedianSortedArrays
    {
        //给定两个大小为 m 和 n 的有序数组 nums1 和 nums2 。
        //请找出这两个有序数组的中位数。要求算法的时间复杂度为 O(log (m+n)) 。
        //你可以假设 nums1 和 nums2 均不为空。
        //示例 1:
        //nums1 = [1, 3]
        //nums2 = [2]
        //中位数是 2.0
        //示例 2:
        //nums1 = [1, 2]
        //nums2 = [3, 4]
        //中位数是 (2 + 3)/2 = 2.5

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            //ensure nums1 is shorter than num2, if not exchange them
            if (nums1.Length > nums2.Length)
            {
                int[] tmp = nums1;
                nums1 = nums2;
                nums2 = tmp;
            }

            int indexMin = 0;
            int indexMax = nums1.Length;
            int leftLenSum = (nums1.Length + nums2.Length + 1) / 2; //ensure left not shorter than right
            while(indexMin <= indexMax)
            {
                int index1 = (indexMin + indexMax) / 2;
                int index2 = leftLenSum - index1;
                if (index1 > indexMin && nums1[index1 - 1] > nums2[index2])
                {
                    //index1 too big
                    indexMax = index1 - 1;
                }
                else if (index1 < indexMax && nums1[index1] < nums2[index2 - 1])
                {
                    //index1 too small
                    indexMin = index1 + 1;
                }
                else
                {
                    int leftMax = 0;
                    //correct index1
                    if (index1 == 0)
                    {
                        leftMax = nums2[index2 - 1];
                    }
                    else if (index2 == 0)
                    {
                        leftMax = nums1[index1 - 1];
                    }
                    else
                    {
                        leftMax = Math.Max(nums1[index1 - 1], nums2[index2 - 1]);
                    }
                    //check sum of length is odd or even
                    if ((nums1.Length + nums2.Length) % 2 == 0)
                    {
                        int rightMin = 0;
                        if (index1 == nums1.Length)
                        {
                            rightMin = nums2[index2];
                        }
                        else if (index2 == nums2.Length)
                        {
                            rightMin = nums1[index1];
                        }
                        else
                        {
                            rightMin = Math.Min(nums1[index1], nums2[index2]);
                        }
                        return (leftMax + rightMin) / 2.0;
                    }
                    else
                    {
                        return leftMax;
                    }
                }
            }
            return 0;
        }

        public void Test()
        {
            int[] nums1 = { 1, 2 };
            int[] nums2 = { 3, 4 };
            double result = FindMedianSortedArrays(nums1, nums2);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
