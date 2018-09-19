using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0087IsScramble
    {
        //给定一个字符串 s1，我们可以把它递归地分割成两个非空子字符串，从而将其表示为二叉树。
        //下图是字符串 s1 = "great" 的一种可能的表示形式。
        //    great
        //   /    \
        //  gr    eat
        // / \    /  \
        //g   r  e   at
        //           / \
        //          a   t
        //在扰乱这个字符串的过程中，我们可以挑选任何一个非叶节点，然后交换它的两个子节点。
        //例如，如果我们挑选非叶节点 "gr" ，交换它的两个子节点，将会产生扰乱字符串 "rgeat" 。
        //    rgeat
        //   /    \
        //  rg    eat
        // / \    /  \
        //r   g  e   at
        //           / \
        //          a   t
        //我们将 "rgeat” 称作 "great" 的一个扰乱字符串。
        //同样地，如果我们继续将其节点 "eat" 和 "at" 进行交换，将会产生另一个新的扰乱字符串 "rgtae" 。
        //    rgtae
        //   /    \
        //  rg    tae
        // / \    /  \
        //r   g  ta  e
        //       / \
        //      t   a
        //我们将 "rgtae” 称作 "great" 的一个扰乱字符串。
        //给出两个长度相等的字符串 s1 和 s2，判断 s2 是否是 s1 的扰乱字符串。
        //示例 1:
        //输入: s1 = "great", s2 = "rgeat"
        //输出: true
        //示例 2:
        //输入: s1 = "abcde", s2 = "caebd"
        //输出: false

        private static int loop = 0;

        public bool IsScramble(string s1, string s2)
        {
            loop = 0;
            if (s1.Length != s2.Length) return false;
            if (s1.Length <= 1) return s1 == s2;
            return IsScramble(s1, 0, s2, 0, s1.Length);
        }

        private bool IsScramble(string s1, int index1, string s2, int index2, int length)
        {
            if (length == 1) return s1[index1] == s2[index2];
            if (length == 2) return (s1[index1] == s2[index2] && s1[index1 + 1] == s2[index2 + 1]) || (s1[index1] == s2[index2 + 1] && s1[index1 + 1] == s2[index2]);
            for (int i = 1; i < length; i++)
            {
                loop++;
                //check if same characters first
                char[] sub1 = s1.Substring(index1, length).ToCharArray();
                Array.Sort(sub1);
                char[] sub2 = s2.Substring(index2, length).ToCharArray();
                Array.Sort(sub2);
                for (int j = 0; j < length; j++)
                    if (sub1[j] != sub2[j]) return false;
                //check sub string
                bool condition1 = IsScramble(s1, index1, s2, index2, i) && IsScramble(s1, index1 + i, s2, index2 + i, length - i);
                bool condition2 = IsScramble(s1, index1, s2, index2 + length - i, i) && IsScramble(s1, index1 + i, s2, index2, length - i);
                if (condition1 || condition2)
                    return true;
            }
            return false;
        }

        public void Test()
        {
            string s1 = "ccabcbabcbabbbbcbb";
            string s2 = "bbbbabccccbbbabcba";
            bool result = IsScramble(s1, s2);
            Console.WriteLine("loop count " + loop);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
