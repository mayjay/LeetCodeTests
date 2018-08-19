using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0020IsValid
    {
        //给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。
        //有效字符串需满足：
        //左括号必须用相同类型的右括号闭合。
        //左括号必须以正确的顺序闭合。
        //注意空字符串可被认为是有效字符串。
        //示例 1:
        //输入: "()"
        //输出: true
        //示例 2:
        //输入: "()[]{}"
        //输出: true
        //示例 3:
        //输入: "(]"
        //输出: false
        //示例 4:
        //输入: "([)]"
        //输出: false
        //示例 5:
        //输入: "{[]}"
        //输出: true

        public bool IsValid(string s)
        {
            if (s.Length == 0) return true;
            //if odd length, false
            if (s.Length % 2 == 1) return false;
            char[] brackets = { '(', ')', '{', '}', '[', ']' };
            //if first bracket is right, false
            if (!IsLeftBracket(brackets, s[0])) return false;
            List<bool> checkedList = new List<bool>(s.Length);
            for (int i = 0; i < s.Length; i++) checkedList.Add(false);
            int index = 0;
            int checkCount = 0;
            while (checkCount < s.Length)
            {
                if (index < 0 || index >= s.Length) return false;
                //find first unchecked right bracket and match left
                if (checkedList[index] == false && !IsLeftBracket(brackets, s[index]))
                {
                    //find left unchecked bracket index, if can not find, return false
                    for (int i = index - 1; i >= -1; i--)
                    {
                        if (i < 0) return false;
                        if (checkedList[i] == false)
                        {
                            char left = s[i];
                            if (MatchBracket(brackets, left, s[index]))
                            {
                                checkedList[i] = true;
                                checkedList[index] = true;
                                checkCount += 2;
                                index++;
                                break;
                            }
                            else return false;
                        }
                    }
                }
                else
                {
                    index++;
                }
            }
            return true;
        }

        private bool IsLeftBracket(char[] brackets, char c)
        {
            for (int i = 0; i < brackets.Length; i++)
            {
                if (c == brackets[i])
                {
                    if (i % 2 == 0) return true;
                    else return false;
                }
            }
            return false;
        }

        private bool MatchBracket(char[] brackets, char left, char right)
        {
            for (int i = 0; i < brackets.Length; i += 2)
            {
                if (left == brackets[i] && right == brackets[i + 1]) return true;
            }
            return false;
        }

        public void Test()
        {
            string input = "(([]){})";
            bool result = IsValid(input);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
