using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0022GenerateParenthesis
    {
        //给出 n 代表生成括号的对数，请你写出一个函数，使其能够生成所有可能的并且有效的括号组合。
        //例如，给出 n = 3，生成结果为：
        //[
        //  "((()))",
        //  "(()())",
        //  "(())()",
        //  "()(())",
        //  "()()()"
        //]

        public IList<string> GenerateParenthesis(int n)
        {
            char[] brackets = { '(', ')' };
            List<string> result = new List<string>();
            if (n > 0)
            {
                //generate all possible brackets
                int count = (int)Math.Pow(2, 2 * n);
                List<int> divide = new List<int>();
                for (int i = 0; i < 2 * n; i++)
                {
                    if (i == 0) divide.Add(count / 2);
                    else divide.Add(divide[i - 1] / 2);
                }
                for (int i = 0; i < count; i++)
                {
                    List<char> candidate = new List<char>();
                    for (int j = 0; j < 2 * n; j++)
                    {
                        int index = 0;
                        if (j == 0) index = i / divide[j];
                        else index = (i % divide[j - 1]) / divide[j];
                        candidate.Add(brackets[index]);
                    }
                    if (IsValidBracket(candidate)) result.Add(new string(candidate.ToArray()));
                }
            }
            return result.ToArray();
        }

        private bool IsValidBracket(List<char> bracket)
        {
            if (bracket[0] != '(') return false;
            int balance = 0;
            for (int i = 0; i < bracket.Count(); i++)
            {
                if (bracket[i] == '(') balance++;
                else balance--;
                if (balance < 0) return false;
            }
            return balance == 0;
        }

        public void Test()
        {
            int input = 3;
            IList<string> result = GenerateParenthesis(input);
            Console.WriteLine("result count " + result.Count());
            foreach (string e in result)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }

    }
}
