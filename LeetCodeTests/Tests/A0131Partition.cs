using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0131Partition
    {
        //给定一个字符串 s，将 s 分割成一些子串，使每个子串都是回文串。
        //返回 s 所有可能的分割方案。
        //示例:
        //输入: "aab"
        //输出:
        //[
        //  ["aa","b"],
        //  ["a","a","b"]
        //]

        public IList<IList<string>> Partition(string s)
        {
            List<List<string>> result = new List<List<string>>();
            Partition(s, 0, s.Length - 1, new List<string>(), result);
            return result.ToArray();
        }

        private void Partition(string s, int start, int end, List<string> candidate, List<List<string>> result)
        {
            if (IsPalindrome(s, start, end))
            {
                candidate.Add(s.Substring(start, end - start + 1));
                result.Add(new List<string>(candidate));
                candidate.RemoveAt(candidate.Count - 1);
            }
            for (int i = start; i < end; i++)
            {
                if (IsPalindrome(s, start, i))
                {
                    candidate.Add(s.Substring(start, i - start + 1));
                    Partition(s, i + 1, end, candidate, result);
                    candidate.RemoveAt(candidate.Count - 1);
                }
            }
        }

        private bool IsPalindrome(string s, int start, int end)
        {
            int i = start, j = end;
            while (i < j)
            {
                if (s[i] != s[j])
                    return false;
                i++;
                j--;
            }
            return true;
        }

        public void Test()
        {
            string input = "aab";
            IList<IList<string>> result = Partition(input);
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
