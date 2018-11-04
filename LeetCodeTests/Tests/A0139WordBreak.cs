using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0139WordBreak
    {
        //给定一个非空字符串 s 和一个包含非空单词列表的字典 wordDict，判定 s 是否可以被空格拆分为一个或多个在字典中出现的单词。
        //说明：
        //拆分时可以重复使用字典中的单词。
        //你可以假设字典中没有重复的单词。
        //示例 1：
        //输入: s = "leetcode", wordDict = ["leet", "code"]
        //输出: true
        //解释: 返回 true 因为 "leetcode" 可以被拆分成 "leet code"。
        //示例 2：
        //输入: s = "applepenapple", wordDict = ["apple", "pen"]
        //输出: true
        //解释: 返回 true 因为 "applepenapple" 可以被拆分成 "apple pen apple"。
        //     注意你可以重复使用字典中的单词。
        //示例 3：
        //输入: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
        //输出: false

        public bool WordBreak(string s, IList<string> wordDict)
        {
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int i = 1; i < dp.Length; i++)
            {
                foreach (string word in wordDict)
                {
                    if (i >= word.Length && dp[i - word.Length] && word == s.Substring(i - word.Length, word.Length))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];
        }

        public void Test()
        {
            string s = "catsandog";
            IList<string> wordDict = new List<string>(new string[] { "cats", "dog", "sand", "and", "cat" });
            bool result = WordBreak(s, wordDict);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
