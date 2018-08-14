using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0030FindSubstring
    {
        //给定一个字符串 s 和一些长度相同的单词 words。在 s 中找出可以恰好串联 words 中所有单词的子串的起始位置。
        //注意子串要与 words 中的单词完全匹配，中间不能有其他字符，但不需要考虑 words 中单词串联的顺序。
        //示例 1:
        //输入:
        //  s = "barfoothefoobarman",
        //  words = ["foo","bar"]
        //输出: [0,9]
        //解释: 从索引 0 和 9 开始的子串分别是 "barfoor" 和 "foobar" 。
        //输出的顺序不重要, [9,0] 也是有效答案。
        //示例 2:
        //输入:
        //  s = "wordgoodstudentgoodword",
        //  words = ["word","student"]
        //输出: []

        public IList<int> FindSubstring(string s, string[] words)
        {
            Dictionary<string, int> count = new Dictionary<string, int>();

            foreach (var w in words)
            {
                count[w] = count.Keys.Contains(w) ? count[w] + 1 : 1;
            }

            if (s == "" || words.Length == 0)
                return new List<int>();

            List<int> ret = new List<int>();
            int l = words[0].Length;
            for (int i = 0; i < l; i++)
            {
                Dictionary<string, int> sets = new Dictionary<string, int>();
                Queue<string> q = new Queue<string>();

                for (int j = 0; j * l + l + i <= s.Length; j++)
                {

                    string w = s.Substring(j * l + i, l);
                    q.Enqueue(w);
                    sets[w] = sets.Keys.Contains(w) ? sets[w] + 1 : 1;

                    while (sets[w] > (count.Keys.Contains(w) ? count[w] : 0))
                        sets[q.Dequeue()]--;

                    if (q.Count == words.Length)
                        ret.Add(j * l + l + i - q.Count * l);
                }
            }
            return ret;
        }

        //last test timeout
        public IList<int> FindSubstring2(string s, string[] words)
        {
            List<int> indexList = new List<int>();
            if (words.Length == 0) return indexList;
            List<string> needleList = new List<string>();
            int step = words[0].Length;
            //check words elements length
            foreach (string word in words)
            {
                if (word.Length != step) return indexList;
            }
            bool startMatch = false;
            int matchIndex = 0;
            bool[] checks = new bool[words.Length];
            //traverse all offsets
            for (int offset = 0; offset < step; offset++)
            {
                //reset when start new loop
                startMatch = false;
                ResetChecks(checks);
                for (int i = offset; i < s.Length; i += step)
                {
                    //check if enough sub string length
                    if (s.Length - i < step) break;
                    string subStr = s.Substring(i, step);
                    if (MatchWord(subStr, words, checks))
                    {
                        if (!startMatch)
                        {
                            startMatch = true;
                            matchIndex = i;
                        }
                        if (MatchAll(checks))
                        {
                            indexList.Add(matchIndex);
                            startMatch = false;
                            ResetChecks(checks);
                            //set i back to matchIndex
                            i = matchIndex;
                        }
                    }
                    else
                    {
                        //if match part words, reset
                        if (startMatch)
                        {
                            startMatch = false;
                            ResetChecks(checks);
                            //set i back to matchIndex
                            i = matchIndex;
                        }
                    }
                }
            }
            return indexList;
        }

        private bool MatchWord(string subStr, string[] words, bool[] checks)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (subStr == words[i] && checks[i] == false)
                {
                    checks[i] = true;
                    return true;
                }
            }
            return false;
        }

        private void ResetChecks(bool[] checks)
        {
            for (int i = 0; i < checks.Length; i++) checks[i] = false;
        }

        private bool MatchAll(bool[] checks)
        {
            foreach (bool b in checks)
            {
                if (b == false) return false;
            }
            return true;
        }

        public void Test()
        {
            string s = "barfoothefoobarman";
            string[] words = { "foo", "bar" };
            IList<int> result = FindSubstring(s, words);
            Console.WriteLine("result count " + result.Count());
            foreach (int e in result)
            {
                Console.Write(e + " ");
            }
            Console.ReadLine();
        }
    }
}
