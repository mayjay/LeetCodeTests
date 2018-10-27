using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0126FindLadders
    {
        //给定两个单词（beginWord 和 endWord）和一个字典 wordList，找出所有从 beginWord 到 endWord 的最短转换序列。转换需遵循如下规则：
        //每次转换只能改变一个字母。
        //转换过程中的中间单词必须是字典中的单词。
        //说明:
        //如果不存在这样的转换序列，返回一个空列表。
        //所有单词具有相同的长度。
        //所有单词只由小写字母组成。
        //字典中不存在重复的单词。
        //你可以假设 beginWord 和 endWord 是非空的，且二者不相同。
        //示例 1:
        //输入:
        //beginWord = "hit",
        //endWord = "cog",
        //wordList = ["hot","dot","dog","lot","log","cog"]
        //输出:
        //[
        //  ["hit","hot","dot","dog","cog"],
        //  ["hit","hot","lot","log","cog"]
        //]
        //示例 2:
        //输入:
        //beginWord = "hit"
        //endWord = "cog"
        //wordList = ["hot","dot","dog","lot","log"]
        //输出: []
        //解释: endWord "cog" 不在字典中，所以不存在符合要求的转换序列。

        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            List<List<string>> result = new List<List<string>>();
		    if (!wordList.Contains(beginWord))
                wordList.Add(beginWord);
            int begin = wordList.IndexOf(beginWord);
            int end = wordList.IndexOf(endWord);
		    //建立邻接表
            Dictionary<int, List<int>> nextWords = new Dictionary<int, List<int>>();
		    for (int i = 0; i < wordList.Count; i++) {
                nextWords.Add(i, new List<int>());
		    }
		    for (int i = 0; i < wordList.Count; i++) {
			    for (int j = i + 1; j < wordList.Count; j++) {
				    if(IsSimilar(wordList[i], wordList[j])) {
					    nextWords[i].Add(j);
					    nextWords[j].Add(i);
				    }
			    }
		    }
		
		    Dictionary<int, int> distance = new Dictionary<int, int>();
		    //广度优先遍历bfs
		    Queue<int> queue = new Queue<int>();
		    queue.Enqueue(begin);
		    distance.Add(begin, 0);
		    while(queue.Count > 0) {
			    int temp = queue.Dequeue();
			    for (int i = 0; i < nextWords[temp].Count; i++) {
				    if(!distance.ContainsKey(nextWords[temp][i])) {
					    distance.Add(nextWords[temp][i], distance[temp] + 1);
					    queue.Enqueue(nextWords[temp][i]);
				    }
			    }
		    }
		    List<int> list = new List<int>();
		    list.Add(begin);
		    //深度优先遍历dfs
		    DFS(nextWords, begin, end, distance, wordList, list, result);
            return result.ToArray();
        }

        private void DFS(Dictionary<int, List<int>> nextWords, int temp, int end, Dictionary<int, int> distance, IList<String> wordList, List<int> list, List<List<String>> retListList) 
        {
		    if(list.Count > 0 && list.Last() == end) {
			    retListList.Add(GetPath(list, wordList));
			    return;
		    }
		
		    for (int i = 0; i < nextWords[temp].Count; i++) {
			    if(distance[nextWords[temp][i]] == distance[temp] + 1) {
				    list.Add(nextWords[temp][i]);
				    DFS(nextWords, nextWords[temp][i], end, distance, wordList, list, retListList);
				    int index = list.Count - 1;
				    list.RemoveAt(index);
			    }
		    }
		    return;
	    }
	
	    private List<String> GetPath(List<int> list, IList<String> wordList) 
        {
		    List<String> retList = new List<string>();
		    for (int i = 0; i < list.Count; i++) {
			    retList.Add(wordList[list[i]]);
		    }
		    return retList;
	    }

        //Time Limit Exceed
        public IList<IList<string>> FindLadders2(string beginWord, string endWord, IList<string> wordList)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> candidate = new List<string>(wordList.Count);
            candidate.Add(beginWord);
            FindLadders(beginWord, endWord, wordList, candidate, result);
            List<List<string>> shortestList = new List<List<string>>();
            int shortLength = 0;
            foreach (List<string> list in result)
            {
                if (shortLength == 0 || list.Count < shortLength)
                    shortLength = list.Count;
            }
            foreach (List<string> list in result)
            {
                if (list.Count == shortLength)
                    shortestList.Add(list);
            }
            return shortestList.ToArray();
        }

        private void FindLadders(string beginWord, string endWord, IList<string> wordList, List<string> candidate, List<List<string>> result)
        {
            if (beginWord == endWord)
            {
                result.Add(new List<string>(candidate));
                return;
            }
            for (int i = 0; i < wordList.Count; i++)
            {
                if (IsSimilar(beginWord, wordList[i]))
                {
                    //DFS
                    string newBeginWord = wordList[i];
                    candidate.Add(newBeginWord);
                    wordList.RemoveAt(i);
                    FindLadders(newBeginWord, endWord, wordList, candidate, result);
                    candidate.RemoveAt(candidate.Count - 1);
                    wordList.Insert(i, newBeginWord);
                }
            }
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
            IList<IList<string>> result = FindLadders(beginWord, endWord, wordList);
            foreach (IList<string> list in result)
            {
                foreach (string str in list)
                    Console.Write(str + " ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
