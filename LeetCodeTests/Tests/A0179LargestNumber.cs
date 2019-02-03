using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0179LargestNumber
    {
        //给定一组非负整数，重新排列它们的顺序使之组成一个最大的整数。
        //示例 1:
        //输入: [10,2]
        //输出: 210
        //示例 2:
        //输入: [3,30,34,5,9]
        //输出: 9534330
        //说明: 输出结果可能非常大，所以你需要返回一个字符串而不是整数。

        public string LargestNumber(int[] nums)
        {
            if (nums.Length == 0) return "";
            List<string> strList = new List<string>(nums.Length);
            foreach (int num in nums)
                strList.Add(num.ToString());
            Comparison<string> comparison = new Comparison<string>((string s1, string s2) =>
            {
                string str1 = s1 + s2;
                string str2 = s2 + s1;
                return str1.CompareTo(str2);
            });
            strList.Sort(comparison);
            StringBuilder sb = new StringBuilder();
            bool firstZero = true;
            for (int i = strList.Count - 1; i >= 0; i--)
            {
                if (firstZero && strList[i] == "0") continue;
                sb.Append(strList[i]);
                firstZero = false;
            }
            if (sb.Length == 0) return "0";
            return sb.ToString();
        }

        public void Test()
        {
            int[] input = { 12, 121 };
            string result = LargestNumber(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
