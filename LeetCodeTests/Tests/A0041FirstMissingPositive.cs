using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0041FirstMissingPositive
    {
        //给定一个未排序的整数数组，找出其中没有出现的最小的正整数。
        //示例 1:
        //输入: [1,2,0]
        //输出: 3
        //示例 2:
        //输入: [3,4,-1,1]
        //输出: 2
        //示例 3:
        //输入: [7,8,9,11,12]
        //输出: 1
        //说明:
        //你的算法的时间复杂度应为O(n)，并且只能使用常数级别的空间。

        public int FirstMissingPositive(int[] nums)
        {
            //let number i on index i+1
            int result = 1;
            int index = 0;
            while (index < nums.Length)
            {
                if (nums[index] == index + 1) index++;
                //if same number ,skip
                else if (nums[index] > 0 && nums[index] <= nums.Length && nums[index] != nums[nums[index] - 1])
                {
                    //swap
                    int tmp = nums[index];
                    nums[index] = nums[tmp - 1];
                    nums[tmp - 1] = tmp;
                }
                else index++;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    return (i + 1);
                }
            }
            result = nums.Length + 1;
            return result;
        }

        public void Test()
        {
            int[] input = { 1, 1 };
            int result = FirstMissingPositive(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
