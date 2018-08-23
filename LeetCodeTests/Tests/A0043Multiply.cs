using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0043Multiply
    {
        //给定两个以字符串形式表示的非负整数 num1 和 num2，返回 num1 和 num2 的乘积，它们的乘积也表示为字符串形式。
        //示例 1:
        //输入: num1 = "2", num2 = "3"
        //输出: "6"
        //示例 2:
        //输入: num1 = "123", num2 = "456"
        //输出: "56088"
        //说明：
        //num1 和 num2 的长度小于110。
        //num1 和 num2 只包含数字 0-9。
        //num1 和 num2 均不以零开头，除非是数字 0 本身。
        //不能使用任何标准库的大数类型（比如 BigInteger）或直接将输入转换为整数来处理。

        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";
            char[] numArr1 = num1.ToCharArray();
            Array.Reverse(numArr1);
            for (int i = 0; i < numArr1.Length; i++) numArr1[i] -= '0';
            char[] numArr2 = num2.ToCharArray();
            Array.Reverse(numArr2);
            for (int i = 0; i < numArr2.Length; i++) numArr2[i] -= '0';
            char[] resultArr = new char[numArr1.Length + numArr2.Length];
            for (int i = 0; i < numArr2.Length; i++)
            {
                int carry = 0;
                for (int j = 0; j < numArr1.Length; j++)
                {
                    int value = numArr1[j] * numArr2[i] + carry + resultArr[i + j];
                    resultArr[i + j] = (char)(value % 10);
                    carry = value / 10;
                    //check if last one, handle carry
                    if (j == numArr1.Length - 1)
                    {
                        int k = i + j + 1;
                        while (carry > 0)
                        {
                            int v = resultArr[k] + carry;
                            resultArr[k] = (char)(v % 10);
                            carry = v / 10;
                            k++;
                        }
                    }
                }
            }
            //ignore '\0' at end of result array
            StringBuilder builder = new StringBuilder();
            bool skip = true;
            for (int i = resultArr.Length - 1; i >= 0; i--)
            {
                if (resultArr[i] != 0 || !skip)
                {
                    char num = (char)(resultArr[i] + '0');
                    builder.Append(num);
                    skip = false;
                }
            }
            return builder.ToString();
        }

        public void Test()
        {
            string num1 = "123";
            string num2 = "456";
            string result = Multiply(num1, num2);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
