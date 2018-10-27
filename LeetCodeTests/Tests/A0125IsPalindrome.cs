using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0125IsPalindrome
    {
        //给定一个字符串，验证它是否是回文串，只考虑字母和数字字符，可以忽略字母的大小写。
        //说明：本题中，我们将空字符串定义为有效的回文串。
        //示例 1:
        //输入: "A man, a plan, a canal: Panama"
        //输出: true
        //示例 2:
        //输入: "race a car"
        //输出: false

        public bool IsPalindrome(string s)
        {
            int i = 0, j = s.Length - 1;
            while (i < j)
            {
                if (!Char.IsLetterOrDigit(s[i]))
                    i++;
                else if (!Char.IsLetterOrDigit(s[j]))
                    j--;
                else if (Char.ToUpper(s[i]) == Char.ToUpper(s[j]))
                {
                    i++;
                    j--;
                }
                else
                    return false;
            }
            return true;
        }

        public void Test()
        {
            string input = "A man, a plan, a canal: Panama";
            bool result = IsPalindrome(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
