using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0017LetterCombinations
    {
        //给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。
        //给出数字到字母的映射如下（与电话按键相同）。注意 1 不对应任何字母。
        //示例:
        //输入："23"
        //输出：["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
        //说明:
        //尽管上面的答案是按字典序排列的，但是你可以任意选择答案输出的顺序。

        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0) return new List<string>().ToArray();
            string[] phoneNumbers = new string[] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            List<string> combination = new List<string>();
            int loopCount = 1;
            foreach (char c in digits)
            {
                int index = c - '0';
                string phoneStr = phoneNumbers[index];
                combination.Add(phoneStr);
                loopCount *= phoneStr.Length;
            }
            List<int> divide = new List<int>();
            for (int i = 0; i < combination.Count(); i++)
            {
                if (i == 0) divide.Add(loopCount / combination[i].Count());
                else divide.Add(divide[i - 1] / combination[i].Count());
            }
            List<string> result = new List<string>();
            for (int i = 0; i < loopCount; i++)
            {
                List<char> candidate = new List<char>();
                for (int j = 0; j < combination.Count(); j++)
                {
                    int index = 0;
                    if (j == 0) index = i / divide[j];
                    else index = (i % divide[j - 1]) / divide[j];
                    candidate.Add(combination[j][index]);
                }
                result.Add(new string(candidate.ToArray()));
            }
            return result.ToArray();
        }

        public void Test()
        {
            string input = "23";
            IList<string> result = LetterCombinations(input);
            Console.WriteLine("result count " + result.Count());
            foreach (string e in result)
            {
                Console.Write(e + " ");
            }
            Console.ReadLine();
        }
    }
}
