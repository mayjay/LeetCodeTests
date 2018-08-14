using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0028StrStr
    {
        //实现 strStr() 函数。
        //给定一个 haystack 字符串和一个 needle 字符串，在 haystack 字符串中找出 needle 字符串出现的第一个位置 (从0开始)。如果不存在，则返回  -1。
        //示例 1:
        //输入: haystack = "hello", needle = "ll"
        //输出: 2
        //示例 2:
        //输入: haystack = "aaaaa", needle = "bba"
        //输出: -1
        //说明:
        //当 needle 是空字符串时，我们应当返回什么值呢？这是一个在面试中很好的问题。
        //对于本题而言，当 needle 是空字符串时我们应当返回 0 。这与C语言的 strstr() 以及 Java的 indexOf() 定义相符。

        public int StrStr(string haystack, string needle)
        {
            if (needle == null || needle.Length == 0) return 0;
            else if (haystack == null || haystack.Length == 0) return -1;
            int index = -1;
            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                if (haystack[i] == needle[0])
                {
                    //if match first letter, check all
                    index = i;
                    if (needle.Length == 1) return index;
                    for (int j = 1; j < needle.Length; j++)
                    {
                        if (haystack[i + j] != needle[j]) break;
                        else if (j == needle.Length - 1) return index;
                    }
                }
            }
            return -1;
        }

        public void Test()
        {
            string haystack = "mississippi";
            string needle = "issipi";
            int result = StrStr(haystack, needle);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
