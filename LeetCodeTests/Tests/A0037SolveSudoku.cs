using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0037SolveSudoku
    {
        //编写一个程序，通过已填充的空格来解决数独问题。
        //一个数独的解法需遵循如下规则：
        //数字 1-9 在每一行只能出现一次。
        //数字 1-9 在每一列只能出现一次。
        //数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。
        //空白格用 '.' 表示。
        //一个数独。
        //答案被标成红色。
        //Note:
        //给定的数独序列只包含数字 1-9 和字符 '.' 。
        //你可以假设给定的数独只有唯一解。
        //给定数独永远是 9x9 形式的。

        public void SolveSudoku(char[,] board)
        {
            SolveSudoku(board, 0, 0);
        }

        private bool IsValid(char[,] board, int i, int j, char c)
        {
            for (int index = 0; index < 9; index++)
            {
                if (board[i, index] == c) return false;
                if (board[index, j] == c) return false;
                if (board[3 * (i / 3) + index / 3, 3 * (j / 3) + index % 3] == c) return false;
            }
            return true;
        }

        private bool SolveSudoku(char[,] board, int i, int j)
        {
            if (i == 9) return true;
            if (j == 9) return SolveSudoku(board, i + 1, 0);
            if (board[i, j] != '.') return SolveSudoku(board, i, j + 1);
            for (char c = '1'; c <= '9'; c++)
            {
                if (IsValid(board, i, j, c))
                {
                    board[i, j] = c;
                    if (SolveSudoku(board, i, j + 1)) return true;
                    board[i, j] = '.';
                }
            }
            return false;
        }

        public void Test()
        {
            char[,] input = {
                                { '5', '3', '.', '.', '7', '.', '.', '.', '.' }, 
                                { '6', '.', '.', '1', '9', '5', '.', '.', '.' }, 
                                { '.', '9', '8', '.', '.', '.', '.', '6', '.' }, 
                                { '8', '.', '.', '.', '6', '.', '.', '.', '3' }, 
                                { '4', '.', '.', '8', '.', '3', '.', '.', '1' }, 
                                { '7', '.', '.', '.', '2', '.', '.', '.', '6' }, 
                                { '.', '6', '.', '.', '.', '.', '2', '8', '.' }, 
                                { '.', '.', '.', '4', '1', '9', '.', '.', '5' }, 
                                { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
                            };
            SolveSudoku(input);
            int count = 0;
            foreach (char e in input)
            {
                Console.Write(e + " ");
                count++;
                if (count == 9)
                {
                    count = 0;
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}
