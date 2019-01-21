using System;
using System.Collections.Generic;
using System.Text;
namespace LeetCodeTests.Tests
{
    public class A0166FractionToDecimal
    {
        //给定两个整数，分别表示分数的分子 numerator 和分母 denominator，以字符串形式返回小数。
        //如果小数部分为循环小数，则将循环的部分括在括号内。
        //示例 1:
        //输入: numerator = 1, denominator = 2
        //输出: "0.5"
        //示例 2:
        //输入: numerator = 2, denominator = 1
        //输出: "2"
        //示例 3:
        //输入: numerator = 2, denominator = 3
        //输出: "0.(6)"

        public string FractionToDecimal(int numerator, int denominator)
        {
            if (denominator == 0) return "";
            Dictionary<long, int> records = new Dictionary<long, int>();
            List<long> numbers = new List<long>();
            int index = 0;
            int beginIndex = -1;
            StringBuilder result = new StringBuilder();
            long lNumerator = numerator;
            long lDenominaotr = denominator;
            //check if negative
            if ((lNumerator > 0 && lDenominaotr < 0) || (lNumerator < 0 && lDenominaotr > 0))
                result.Append('-');
            lNumerator = Math.Abs(lNumerator);
            lDenominaotr = Math.Abs(lDenominaotr);
            long val = lNumerator / lDenominaotr;
            result.Append(val);
            lNumerator = (lNumerator % lDenominaotr) * 10;
            while (lNumerator != 0)
            {
                if (records.ContainsKey(lNumerator))
                {
                    beginIndex = records[lNumerator];
                    break;
                }
                else
                {
                    records.Add(lNumerator, index++);
                    val = lNumerator / lDenominaotr;
                    lNumerator = (lNumerator % lDenominaotr) * 10;
                    numbers.Add(val);
                }
            }
            for (int i = 0; i < index; i++)
            {
                if (i == 0)
                    result.Append('.');
                if (i == beginIndex)
                    result.Append('(');
                result.Append(numbers[i]);
            }
            if (beginIndex != -1)
                result.Append(')');
            return result.ToString();
        }

        public void Test()
        {
            int numerator = 1;
            int denominator = 6;
            string result = FractionToDecimal(numerator, denominator);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
