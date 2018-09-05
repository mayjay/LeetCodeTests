using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0067AddBinary
    {
        //给定两个二进制字符串，返回他们的和（用二进制表示）。
        //输入为非空字符串且只包含数字 1 和 0。
        //示例 1:
        //输入: a = "11", b = "1"
        //输出: "100"
        //示例 2:
        //输入: a = "1010", b = "1011"
        //输出: "10101"

        public string AddBinary(string a, string b)
        {
            char[] addList1 = a.ToCharArray();
            Array.Reverse(addList1);
            char[] addList2 = b.ToCharArray();
            Array.Reverse(addList2);
            int len = Math.Max(addList1.Length, addList2.Length);
            List<char> sumList = new List<char>(len + 1);
            int exceed = 0;
            for (int i = 0; i < len; i++)
            {
                int add1 = i < addList1.Length ? addList1[i] - '0' : 0;
                int add2 = i < addList2.Length ? addList2[i] - '0' : 0;
                int sum = add1 + add2 + exceed;
                if (sum >= 2)
                {
                    exceed = 1;
                    sum %= 2;
                }
                else
                    exceed = 0;
                sumList.Add((char)(sum + '0'));
            }
            //check exceed out of cycle
            if (exceed == 1)
                sumList.Add('1');
            sumList.Reverse();
            return new string(sumList.ToArray());
        }

        public void Test()
        {
            string a = "1010";
            string b = "1011";
            string result = AddBinary(a, b);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
