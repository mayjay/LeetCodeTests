using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0009IsPalindrome
    {
        //判断一个整数是否是回文数。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。
        //示例 1:
        //输入: 121
        //输出: true
        //示例 2:
        //输入: -121
        //输出: false
        //解释: 从左向右读, 为 -121 。 从右向左读, 为 121- 。因此它不是一个回文数。
        //示例 3:
        //输入: 10
        //输出: false
        //解释: 从右向左读, 为 01 。因此它不是一个回文数。
        //进阶:
        //你能不将整数转为字符串来解决这个问题吗？

        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            List<int> arr = new List<int>();
            int bit = 0;
            while (x >= Math.Pow(10, bit))
            {
                int value = (x / (int)Math.Pow(10, bit)) % 10;
                arr.Add((int)value);
                bit++;
            }
            for(int i = 0; i < arr.Count() / 2; i++)
            {
                if (arr[i] != arr[arr.Count() - i - 1]) return false;
            }
            return true;
        }

        public void Test()
        {
            int input = 10;
            bool result = IsPalindrome(input);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
