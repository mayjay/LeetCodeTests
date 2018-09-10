using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0076MinWindow
    {
        //给定一个字符串 S 和一个字符串 T，请在 S 中找出包含 T 所有字母的最小子串。
        //示例：
        //输入: S = "ADOBECODEBANC", T = "ABC"
        //输出: "BANC"
        //说明：
        //如果 S 中不存这样的子串，则返回空字符串 ""。
        //如果 S 中存在这样的子串，我们保证它是唯一的答案。

        public string MinWindow(string s, string t)
        {
            int l = 0, r = 0;
            string result = "";
            //record t in hash map
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in t)
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict.Add(c, 1);
            //slide l,r
            for (r = 0; r < s.Length; r++)
            {
                if (t.Contains(s[r]))
                {
                    dict[s[r]]--;
                    if (match(dict))
                    {
                        while (l <= r)
                        {
                            if (t.Contains(s[l]))
                            {
                                if (result.Length == 0 || result.Length > r - l + 1)
                                    result = s.Substring(l, r - l + 1);
                                dict[s[l]]++;
                                if (!match(dict))
                                {
                                    l++;
                                    break;
                                }
                            }
                            l++;
                        }
                    }
                }
            }
            return result;
        }

        private bool match(Dictionary<char, int> dict)
        {
            foreach (KeyValuePair<char, int> e in dict)
                if (e.Value > 0)
                    return false;
            return true;
        }

        public void Test()
        {
            string s = "ADOBECODEBANC";
            string t = "ABC";
            string result = MinWindow(s, t);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
