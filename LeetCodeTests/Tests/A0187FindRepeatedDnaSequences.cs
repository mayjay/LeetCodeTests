using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0187FindRepeatedDnaSequences
    {
        //所有 DNA 由一系列缩写为 A，C，G 和 T 的核苷酸组成，例如：“ACGAATTCCG”。在研究 DNA 时，识别 DNA 中的重复序列有时会对研究非常有帮助。
        //编写一个函数来查找 DNA 分子中所有出现超多一次的10个字母长的序列（子串）。
        //示例:
        //输入: s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"
        //输出: ["AAAAACCCCC", "CCCCCAAAAA"]

        public IList<string> FindRepeatedDnaSequences(string s)
        {
            List<string> res = new List<string>();
            if (s == null || s.Length < 11) return res;
            int hash = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();
            map.Add('A', 0);
            map.Add('C', 1);
            map.Add('G', 2);
            map.Add('T', 3);
            HashSet<int> set = new HashSet<int>();
            HashSet<int> unique = new HashSet<int>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                hash = (hash << 2) + map[c];
                if (i >= 9)
                {
                    hash &= (1 << 20) - 1;
                    if (set.Contains(hash) && !unique.Contains(hash))
                    {
                        res.Add(s.Substring(i - 9, 10));
                        unique.Add(hash);
                    }
                    else
                        set.Add(hash);
                }
            }
            return res;
        }

        public void Test()
        {
            string input = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT";
            IList<string> result = FindRepeatedDnaSequences(input);
            foreach (string s in result)
                Console.WriteLine(s);
            Console.WriteLine();
            Console.ReadLine();
        }

    }
}
