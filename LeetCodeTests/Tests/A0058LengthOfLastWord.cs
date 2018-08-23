using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0058LengthOfLastWord
    {
        //给定一个仅包含大小写字母和空格 ' ' 的字符串，返回其最后一个单词的长度。
        //如果不存在最后一个单词，请返回 0 。
        //说明：一个单词是指由字母组成，但不包含任何空格的字符串。
        //示例:
        //输入: "Hello World"
        //输出: 5

        public int LengthOfLastWord(string s)
        {
            int length = 0;
            bool startWord = false;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (!startWord)
                {
                    if (s[i] == ' ') continue;
                    else
                    {
                        startWord = true;
                        length++;
                    }
                }
                else if (s[i] != ' ') length++;
                else break;
            }
            return length;
        }

        public void Test()
        {
            string input = "a ";
            int result = LengthOfLastWord(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
