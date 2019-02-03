using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0171TitleToNumber
    {
        //给定一个Excel表格中的列名称，返回其相应的列序号。
        //例如，
        //    A -> 1
        //    B -> 2
        //    C -> 3
        //    ...
        //    Z -> 26
        //    AA -> 27
        //    AB -> 28 
        //    ...
        //示例 1:
        //输入: "A"
        //输出: 1
        //示例 2:
        //输入: "AB"
        //输出: 28
        //示例 3:
        //输入: "ZY"
        //输出: 701

        public int TitleToNumber(string s)
        {
            char[] arr = s.ToCharArray();
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
                result += (arr[i] - 'A' + 1) * (int)Math.Pow(26, arr.Length - i - 1);
            return result;
        }

        public void Test()
        {
            string input = "ZY";
            int result = TitleToNumber(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
