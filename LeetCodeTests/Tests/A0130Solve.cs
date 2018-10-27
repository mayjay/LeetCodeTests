using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0130Solve
    {
        //给定一个二维的矩阵，包含 'X' 和 'O'（字母 O）。
        //找到所有被 'X' 围绕的区域，并将这些区域里所有的 'O' 用 'X' 填充。
        //示例:
        //X X X X
        //X O O X
        //X X O X
        //X O X X
        //运行你的函数后，矩阵变为：
        //X X X X
        //X X X X
        //X X X X
        //X O X X
        //解释:
        //被围绕的区间不会存在于边界上，换句话说，任何边界上的 'O' 都不会被填充为 'X'。 任何不在边界上，或不与边界上的 'O' 相连的 'O' 最终都会被填充为 'X'。如果两个元素在水平或垂直方向相邻，则称它们是“相连”的。

        public void Solve(char[,] board)
        {
            //find all boarder 'O' and push to stack
            int row = board.GetLength(0);
            int column = board.GetLength(1);
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if ((i == 0 || i == row - 1 || j == 0 || j == column - 1) && board[i, j] == 'O')
                        stack.Push(i * column + j);
                }
            }
            List<int> boarders = new List<int>();
            while (stack.Count > 0)
            {
                //pop peak and avoid push repeat index
                int index = stack.Pop();
                if (!boarders.Contains(index))
                    boarders.Add(index);
                else continue;
                //add sibling of current element
                int i = index / column;
                int j = index % column;
                //left
                if (j > 0 && board[i, j - 1] == 'O')
                    stack.Push(index - 1);
                //right
                if (j < column - 1 && board[i, j + 1] == 'O')
                    stack.Push(index + 1);
                //up
                if (i > 0 && board[i - 1, j] == 'O')
                    stack.Push(index - column);
                //down
                if (i < row - 1 && board[i + 1, j] == 'O')
                    stack.Push(index + column);
            }
            boarders.Sort();
            int boarderIndex = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (board[i, j] == 'O')
                    {
                        int index = i * column + j;
                        if (boarderIndex < boarders.Count && index == boarders[boarderIndex])
                            boarderIndex++;
                        else
                            board[i, j] = 'X';
                    }
                }
            }
        }

        public void Test()
        {
            char[,] input = {
                                { 'X', 'X', 'X', 'X' }, 
                                { 'X', 'O', 'O', 'X' }, 
                                { 'X', 'X', 'O', 'X' }, 
                                { 'X', 'O', 'X', 'X' }
                            };
            Solve(input);
            int count = 0;
            foreach (char e in input)
            {
                Console.Write(e + " ");
                count++;
                if (count == input.GetLength(1))
                {
                    count = 0;
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}
