using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0150EvalRPN
    {
        //根据逆波兰表示法，求表达式的值。
        //有效的运算符包括 +, -, *, / 。每个运算对象可以是整数，也可以是另一个逆波兰表达式。
        //说明：
        //整数除法只保留整数部分。
        //给定逆波兰表达式总是有效的。换句话说，表达式总会得出有效数值且不存在除数为 0 的情况。
        //示例 1：
        //输入: ["2", "1", "+", "3", "*"]
        //输出: 9
        //解释: ((2 + 1) * 3) = 9
        //示例 2：
        //输入: ["4", "13", "5", "/", "+"]
        //输出: 6
        //解释: (4 + (13 / 5)) = 6
        //示例 3：
        //输入: ["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"]
        //输出: 22
        //解释: 
        //  ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
        //= ((10 * (6 / (12 * -11))) + 17) + 5
        //= ((10 * (6 / -132)) + 17) + 5
        //= ((10 * 0) + 17) + 5
        //= (0 + 17) + 5
        //= 17 + 5
        //= 22

        public int EvalRPN(string[] tokens)
        {
            return EvalRPN(new List<string>(tokens));
        }

        private int EvalRPN(List<string> tokens)
        {
            if (tokens.Count == 1)
                return int.Parse(tokens[0]);
            for (int i = 0; i < tokens.Count; i++)
            {
                if (IsOperator(tokens[i]))
                {
                    Calculate(tokens, i - 2);
                    return EvalRPN(tokens);
                }
            }
            return 0;
        }

        private bool IsOperator(string input)
        {
            return (input == "+" || input == "-" || input == "*" || input == "/");
        }

        private void Calculate(List<string> tokens, int index)
        {
            int operand1 = int.Parse(tokens[index]);
            int operand2 = int.Parse(tokens[index + 1]);
            string op = tokens[index + 2];
            int result = 0;
            switch (op)
            {
                case "+":
                    result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    result = operand1 / operand2;
                    break;
            }
            tokens.RemoveRange(index, 3);
            tokens.Insert(index, result.ToString());
        }

        public void Test()
        {
            string[] input = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            int result = EvalRPN(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
