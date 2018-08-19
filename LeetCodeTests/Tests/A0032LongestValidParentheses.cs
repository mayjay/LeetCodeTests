using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0032LongestValidParentheses
    {
        //给定一个只包含 '(' 和 ')' 的字符串，找出最长的包含有效括号的子串的长度。
        //示例 1:
        //输入: "(()"
        //输出: 2
        //解释: 最长有效括号子串为 "()"
        //示例 2:
        //输入: ")()())"
        //输出: 4
        //解释: 最长有效括号子串为 "()()"

        public int LongestValidParentheses(string s)
        {
            //借助栈来求解，需要定义个start变量来记录合法括号串的起始位置，
            //遍历字符串，如果遇到左括号，则将当前下标压入栈，
            //如果遇到右括号，如果当前栈为空，则将下一个坐标位置记录到start，如果栈不为空，则将栈顶元素取出，此时若栈为空，则更新结果和i - start + 1中的较大值，否则更新结果和i - 栈顶元素中的较大值
            int length = 0;
            int startIndex = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') stack.Push(i);
                else
                {
                    if (stack.Count == 0) startIndex = i + 1;
                    else
                    {
                        stack.Pop();
                        if (stack.Count == 0) length = Math.Max(length, i + 1 - startIndex);
                        else length = Math.Max(length, i - stack.Peek());
                    }
                }
            }
            return length;
        }

        public int LongestValidParentheses2(string s)
        {
            int length = 0;
            for (int i = 0; i < s.Length; i++)
            {
                //if length already longer than whole sub string, quit loop
                if (s.Length - i <= length) break;
                //only check sub string that longer than length
                for (int j = s.Length; j - i > length; j--)
                {
                    if ((j - i) % 2 != 0) continue;
                    string subStr = s.Substring(i, j - i);
                    if (IsValid(subStr))
                    {
                        length = j - i;
                        //if valid, skip shorter sub string for j--
                        break;
                    }
                }
            }
            return length;
        }

        private bool IsValid(string s)
        {
            return new A0020IsValid().IsValid(s);
        }

        public void Test()
        {
            string s = ")()";
            int result = LongestValidParentheses(s);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
