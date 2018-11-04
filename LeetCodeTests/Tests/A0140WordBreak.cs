using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0140WordBreak
    {
        //给定一个非空字符串 s 和一个包含非空单词列表的字典 wordDict，在字符串中增加空格来构建一个句子，使得句子中所有的单词都在词典中。返回所有这些可能的句子。
        //说明：
        //分隔时可以重复使用字典中的单词。
        //你可以假设字典中没有重复的单词。
        //示例 1：
        //输入:
        //s = "catsanddog"
        //wordDict = ["cat", "cats", "and", "sand", "dog"]
        //输出:
        //[
        //  "cats and dog",
        //  "cat sand dog"
        //]
        //示例 2：
        //输入:
        //s = "pineapplepenapple"
        //wordDict = ["apple", "pen", "applepen", "pine", "pineapple"]
        //输出:
        //[
        //  "pine apple pen apple",
        //  "pineapple pen apple",
        //  "pine applepen apple"
        //]
        //解释: 注意你可以重复使用字典中的单词。
        //示例 3：
        //输入:
        //s = "catsandog"
        //wordDict = ["cats", "dog", "sand", "and", "cat"]
        //输出:
        //[]

        private Dictionary<string, IList<string>> cache = new Dictionary<string, IList<string>>();

        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            if (cache.ContainsKey(s))
                return cache[s];
            IList<string> result = new List<string>();
            if (s.Length == 0)
            {
                result.Add("");
                return result;
            }
            foreach (string word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    IList<string> subWords = WordBreak(s.Substring(word.Length), wordDict);
                    foreach (string subWord in subWords)
                        result.Add(word + (subWord.Length == 0 ? "" : " ") + subWord);
                }
            }
            cache.Add(s, result);
            return result;
        }

        public void Test()
        {
            string s = "catsanddog";
            IList<string> wordDict = new List<string>(new string[] { "cat", "cats", "and", "sand", "dog" });
            IList<string> result = WordBreak(s, wordDict);
            foreach (string str in result)
                Console.WriteLine(str + " ");
            Console.ReadLine();
        }
    }
}
