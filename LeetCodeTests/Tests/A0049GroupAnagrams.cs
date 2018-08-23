using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0049GroupAnagrams
    {
        //给定一个字符串数组，将字母异位词组合在一起。字母异位词指字母相同，但排列不同的字符串。
        //示例:
        //输入: ["eat", "tea", "tan", "ate", "nat", "bat"],
        //输出:
        //[
        //  ["ate","eat","tea"],
        //  ["nat","tan"],
        //  ["bat"]
        //]
        //说明：
        //所有输入均为小写字母。
        //不考虑答案输出的顺序。

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<List<string>> result = new List<List<string>>();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach (string str in strs)
            {
                char[] charList = str.ToCharArray();
                Array.Sort(charList);
                string sortStr = new string(charList);
                if (!dict.ContainsKey(sortStr))
                {
                    List<string> stringList = new List<string>();
                    stringList.Add(str);
                    dict.Add(sortStr, stringList);
                }
                else dict[sortStr].Add(str);
            }
            foreach (KeyValuePair<string, List<string>> pair in dict)
                result.Add(pair.Value);
            return result.ToArray();
        }

        public void Test()
        {
            string[] input = { "eat", "tea", "tan", "ate", "nat", "bat" };
            IList<IList<string>> result = GroupAnagrams(input);
            Console.WriteLine("result count " + result.Count());
            foreach (IList<string> e in result)
            {
                foreach (string str in e) Console.Write(str + " ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
