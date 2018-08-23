using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0050MyPow
    {
        //实现 pow(x, n) ，即计算 x 的 n 次幂函数。
        //示例 1:
        //输入: 2.00000, 10
        //输出: 1024.00000
        //示例 2:
        //输入: 2.10000, 3
        //输出: 9.26100
        //示例 3:
        //输入: 2.00000, -2
        //输出: 0.25000
        //解释: 2`-2 = 1/2`2 = 1/4 = 0.25
        //说明:
        //-100.0 < x < 100.0
        //n 是 32 位有符号整数，其数值范围是 [−2`31, 2`31 − 1] 。

        public double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            if (x == 0) return 0;
            if (x == 1) return 1;
            double result = 1;
            //avoid minimun negative number
            long pow = Math.Abs((long)n);
            List<double> powPool = new List<double>();
            powPool.Add(x);
            while (pow > 0)
            {
                if (pow % 2 == 1)
                    result *= powPool.Last();
                powPool.Add(powPool.Last() * powPool.Last());
                pow /= 2;
            }
            //check if negative n
            if (n < 0) result = 1 / result;
            return result;
        }

        public void Test()
        {
            double x = 2.00000;
            int n = -2147483648;
            double result = MyPow(x, n);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
