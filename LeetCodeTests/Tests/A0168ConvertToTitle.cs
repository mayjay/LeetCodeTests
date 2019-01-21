using System;
using System.Collections.Generic;
using System.Text;
namespace LeetCodeTests.Tests
{
    public class A0168ConvertToTitle
    {
        //给定一个正整数，返回它在 Excel 表中相对应的列名称。
        //例如，
        //    1 -> A
        //    2 -> B
        //    3 -> C
        //    ...
        //    26 -> Z
        //    27 -> AA
        //    28 -> AB
        //    ...
        //示例 1:
        //输入: 1
        //输出: "A"
        //示例 2:
        //输入: 28
        //输出: "AB"
        //示例 3:
        //输入: 701
        //输出: "ZY"

        public string ConvertToTitle(int n)
        {
            List<int> alphabets = new List<int>();
            while (n > 0)
            {
                int mod = (n - 1) % 26 + 1;
                alphabets.Add(mod);
                n = (n - 1) / 26;
            }
            StringBuilder sb = new StringBuilder(alphabets.Count);
            for (int i = alphabets.Count - 1; i >= 0; i--)
                sb.Append((char)('A' + alphabets[i] - 1));
            return sb.ToString();
        }

        public void Test()
        {
            int input = 701;
            string result = ConvertToTitle(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
