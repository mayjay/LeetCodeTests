using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0029Divide
    {
        //给定两个整数，被除数 dividend 和除数 divisor。将两数相除，要求不使用乘法、除法和 mod 运算符。
        //返回被除数 dividend 除以除数 divisor 得到的商。
        //示例 1:
        //输入: dividend = 10, divisor = 3
        //输出: 3
        //示例 2:
        //输入: dividend = 7, divisor = -3
        //输出: -2
        //说明:
        //被除数和除数均为 32 位有符号整数。
        //除数不为 0。
        //假设我们的环境只能存储 32 位有符号整数，其数值范围是 [−2`31,  2`31 − 1]。本题中，如果除法结果溢出，则返回 2`31 − 1。

        public int Divide(int dividend, int divisor)
        {
            long result = 0;
            bool bPositive = true;
            if ((dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0)) bPositive = false;
            long dividendL = Math.Abs((long)dividend);
            long divisorL = Math.Abs((long)divisor);
            if (divisorL == 0) return Int32.MaxValue;
            if (dividendL == 0 || dividendL < divisorL) return 0;
            result = DivideRecurse(dividendL, divisorL);
            result = bPositive ? result : -result;
            if (result > Int32.MaxValue || result < Int32.MinValue) result = Int32.MaxValue;
            return (int)result;
        }

        private long DivideRecurse(long dividendL, long divisorL)
        {
            if (dividendL < divisorL) return 0;
            long divide = 1;
            long sum = divisorL;
            while (dividendL > sum + sum)
            {
                sum += sum;
                divide += divide;
            }
            return divide + DivideRecurse(dividendL - sum, divisorL);
        }

        public void Test()
        {
            int dividend = 10;
            int divisor = 3;
            int result = Divide(dividend, divisor);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
