using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0069MySqrt
    {
        //实现 int sqrt(int x) 函数。
        //计算并返回 x 的平方根，其中 x 是非负整数。
        //由于返回类型是整数，结果只保留整数的部分，小数部分将被舍去。
        //示例 1:
        //输入: 4
        //输出: 2
        //示例 2:
        //输入: 8
        //输出: 2
        //说明: 8 的平方根是 2.82842..., 
        //     由于返回类型是整数，小数部分将被舍去。

        public int MySqrt(int x)
        {
            if (x <= 1) return x;
            int left = 0;
            int right = x;
            long middle = 0;
            while (left < right)
            {
                middle = (left + right) / 2;
                long square = middle * middle;
                if (square == x)
                    return (int)middle;
                else if (square > x)
                    right = (int)middle;
                else
                    left = (int)middle;
                if (left + 1 == right)
                    return left;
            }
            return (int)middle;
        }

        public void Test()
        {
            int input = 2147395599;
            int result = MySqrt(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
