using System;
using System.Text;
using System.Collections.Generic;

namespace LeetCodeTests.Tests
{
    public class A0151ReverseWords
    {
        //给定一个字符串，逐个翻转字符串中的每个单词。
        //示例:  
        //输入: "the sky is blue",
        //输出: "blue is sky the".
        //说明:
        //无空格字符构成一个单词。
        //输入字符串可以在前面或者后面包含多余的空格，但是反转后的字符不能包括。
        //如果两个单词间有多余的空格，将反转后单词间的空格减少到只含一个。
        //进阶: 请选用C语言的用户尝试使用 O(1) 空间复杂度的原地解法。

        public string ReverseWords(string s)
        {
            s = s.Trim();
            string[] words = s.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder(s.Length);
            for (int i = words.Length - 1; i >= 0; i--)
            {
                sb.Append(words[i]);
                if (i > 0)
                    sb.Append(' ');
            }
            return sb.ToString();
        }

        public void Test()
        {
            string input = "the sky is   blue";
            string result = ReverseWords(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
