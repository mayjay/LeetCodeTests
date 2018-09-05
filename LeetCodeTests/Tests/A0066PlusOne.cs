using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0066PlusOne
    {
        //给定一个由整数组成的非空数组所表示的非负整数，在该数的基础上加一。
        //最高位数字存放在数组的首位， 数组中每个元素只存储一个数字。
        //你可以假设除了整数 0 之外，这个整数不会以零开头。
        //示例 1:
        //输入: [1,2,3]
        //输出: [1,2,4]
        //解释: 输入数组表示数字 123。
        //示例 2:
        //输入: [4,3,2,1]
        //输出: [4,3,2,2]
        //解释: 输入数组表示数字 4321。

        public int[] PlusOne(int[] digits)
        {
            int[] result = new int[digits.Length];
            int exceed = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (i == digits.Length - 1)
                    result[i] = digits[i] + 1;
                else
                    result[i] = digits[i] + exceed;
                if (result[i] >= 10)
                {
                    exceed = 1;
                    result[i] = result[i] % 10;
                }
                else
                    exceed = 0;
            }
            //check exceed out of cycle
            if (exceed == 1)
            {
                result = new int[digits.Length + 1];
                result[0] = 1;
            }
            return result;
        }

        public void Test()
        {
            int[] input = { 7, 9, 9 };
            int[] result = PlusOne(input);
            foreach (int num in result)
                Console.Write(num + " ");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
