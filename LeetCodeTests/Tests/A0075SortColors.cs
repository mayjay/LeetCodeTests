using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0075SortColors
    {
        //给定一个包含红色、白色和蓝色，一共 n 个元素的数组，原地对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。
        //此题中，我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。
        //注意:
        //不能使用代码库中的排序函数来解决这道题。
        //示例:
        //输入: [2,0,2,1,1,0]
        //输出: [0,0,1,1,2,2]
        //进阶：
        //一个直观的解决方案是使用计数排序的两趟扫描算法。
        //首先，迭代计算出0、1 和 2 元素的个数，然后按照0、1、2的排序，重写当前数组。
        //你能想出一个仅使用常数空间的一趟扫描算法吗？

        public void SortColors(int[] nums)
        {
            //i, j, k represents last index of 0, 1, 2
            int i = -1, j = -1, k = -1;
            for (int index = 0; index < nums.Length; index++)
            {
                switch (nums[index])
                {
                    case 0:
                        k++;
                        nums[k] = 2;
                        j++;
                        nums[j] = 1;
                        i++;
                        nums[i] = 0;
                        break;
                    case 1:
                        k++;
                        nums[k] = 2;
                        j++;
                        nums[j] = 1;
                        break;
                    case 2:
                        k++;
                        nums[k] = 2;
                        break;
                }
            }
        }

        public void SortColors2(int[] nums)
        {
            int[] count = { 0, 0, 0 };
            foreach (int num in nums)
                count[num]++;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < count[0])
                    nums[i] = 0;
                else if (i < count[0] + count[1])
                    nums[i] = 1;
                else
                    nums[i] = 2;
            }
        }

        public void Test()
        {
            int[] input = { 2, 0, 2, 1, 1, 0 };
            SortColors(input);
            foreach (int e in input)
                Console.Write(e + " ");
            Console.ReadLine();
        }
    }
}
