using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0059GenerateMatrix
    {
        //给定一个正整数 n，生成一个包含 1 到 n^2 所有元素，且元素按顺时针顺序螺旋排列的正方形矩阵。
        //示例:
        //输入: 3
        //输出:
        //[
        // [ 1, 2, 3 ],
        // [ 8, 9, 4 ],
        // [ 7, 6, 5 ]
        //]

        public enum Direction
        {
            Right,
            Down,
            Left,
            Up
        }

        public int[,] GenerateMatrix(int n)
        {
            int[,] result = new int[n, n];
            Direction direction = Direction.Right;
            int i = 0, j = 0;
            for (int num = 1; num <= n * n; num++)
            {
                result[i, j] = num;
                switch (direction)
                {
                    case Direction.Right:
                        if (j == n - 1 - i)
                        {
                            direction = Direction.Down;
                            i++;
                        }
                        else j++;
                        break;
                    case Direction.Down:
                        if (i == j + n - n)
                        {
                            direction = Direction.Left;
                            j--;
                        }
                        else i++;
                        break;
                    case Direction.Left:
                        if (j == n - 1 - i)
                        {
                            direction = Direction.Up;
                            i--;
                        }
                        else j--;
                        break;
                    case Direction.Up:
                        if (i == j + 1)
                        {
                            direction = Direction.Right;
                            //finish one cycle
                            j++;
                        }
                        else i--;
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public void Test()
        {
            int input = 5;
            int[,] result = GenerateMatrix(input);
            int count = 0;
            foreach (int e in result)
            {
                Console.Write(e + " ");
                count++;
                if (count >= result.GetLength(0))
                {
                    Console.WriteLine();
                    count = 0;
                }
            }
            Console.ReadLine();
        }
    }
}
