using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0127LadderLength
    {
        //给定两个单词（beginWord 和 endWord）和一个字典，找到从 beginWord 到 endWord 的最短转换序列的长度。转换需遵循如下规则：
        //每次转换只能改变一个字母。
        //转换过程中的中间单词必须是字典中的单词。
        //说明:
        //如果不存在这样的转换序列，返回 0。
        //所有单词具有相同的长度。
        //所有单词只由小写字母组成。
        //字典中不存在重复的单词。
        //你可以假设 beginWord 和 endWord 是非空的，且二者不相同。
        //示例 1:
        //输入:
        //beginWord = "hit",
        //endWord = "cog",
        //wordList = ["hot","dot","dog","lot","log","cog"]
        //输出: 5
        //解释: 一个最短转换序列是 "hit" -> "hot" -> "dot" -> "dog" -> "cog",
        //     返回它的长度 5。
        //示例 2:
        //输入:
        //beginWord = "hit"
        //endWord = "cog"
        //wordList = ["hot","dot","dog","lot","log"]
        //输出: 0
        //解释: endWord "cog" 不在字典中，所以无法进行转换。

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<string> wordSet = new HashSet<string>(wordList);
            HashSet<string> visited = new HashSet<string>();
            visited.Add(beginWord);
            int length = 1;
            //BFS
            while (!visited.Contains(endWord))
            {
                HashSet<string> tmp = new HashSet<string>();
                foreach (string vword in visited)
                {
                    foreach (string word in wordSet)
                    {
                        if (IsSimilar(vword, word))
                        {
                            tmp.Add(word);
                        }
                    }
                }
                if (tmp.Count == 0)
                    return 0;
                //remove visited words in wordList
                foreach (string word in tmp)
                    wordSet.Remove(word);
                length++;
                visited = tmp;
            }
            return length;
        }

        private bool IsSimilar(string word1, string word2)
        {
            int diff = 0;
            for (int i = 0; i < word1.Length; i++)
            {
                if (word1[i] != word2[i])
                    diff++;
                if (diff > 1)
                    return false;
            }
            return diff == 1;
        }

        public void Test()
        {
            string beginWord = "hit";
            string endWord = "cog";
            List<string> wordList = new List<string>(new string[] { "hot", "dot", "dog", "lot", "log", "cog" });
            int result = LadderLength(beginWord, endWord, wordList);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
