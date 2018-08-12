using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0007Reverse
    {
        //给定一个 32 位有符号整数，将整数中的数字进行反转。
        //示例 1:
        //输入: 123
        //输出: 321
        // 示例 2:
        //输入: -123
        //输出: -321
        //示例 3:
        //输入: 120
        //输出: 21
        //注意:
        //假设我们的环境只能存储 32 位有符号整数，其数值范围是 [−2`31,  2`31 − 1]。根据这个假设，如果反转后的整数溢出，则返回 0。

        public int Reverse(int x)
        {
            int factor = x < 0 ? -1 : 1;
            long absX = Math.Abs((long)x);
            List<int> arr = new List<int>();
            int bit = 0;
            while (absX >= Math.Pow(10, bit))
            {
                long value = (absX / (long)Math.Pow(10, bit)) % 10;
                arr.Add((int)value);
                bit++;
            }
            arr.Reverse();
            long result = 0;
            for(int i = 0; i < arr.Count(); i++)
            {
                result += arr[i] * (long)Math.Pow(10, i);
            }
            result *= factor;
            if (result > Int32.MaxValue || result < Int32.MinValue) result = 0;
            return (int)result;
        }

        public void Test()
        {
            int input = 123;
            int result = Reverse(input);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
