using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0054SpiralOrder
    {
        //给定一个包含 m x n 个元素的矩阵（m 行, n 列），请按照顺时针螺旋顺序，返回矩阵中的所有元素。
        //示例 1:
        //输入:
        //[
        // [ 1, 2, 3 ],
        // [ 4, 5, 6 ],
        // [ 7, 8, 9 ]
        //]
        //输出: [1,2,3,6,9,8,7,4,5]
        //示例 2:
        //输入:
        //[
        //  [1, 2, 3, 4],
        //  [5, 6, 7, 8],
        //  [9,10,11,12]
        //]
        //输出: [1,2,3,4,8,12,11,10,9,5,6,7]

        public enum Direction
        {
            Right,
            Down,
            Left,
            Up
        }

        public IList<int> SpiralOrder(int[,] matrix)
        {
            List<int> result = new List<int>();
            int line = matrix.GetUpperBound(0) + 1;
            int column = matrix.GetUpperBound(1) + 1;
            Direction direction = Direction.Right;
            int i = 0, j = 0;
            for (int index = 0; index < matrix.Length; index++)
            {
                result.Add(matrix[i, j]);
                switch (direction)
                {
                    case Direction.Right:
                        if (j == column - 1 - i)
                        {
                            direction = Direction.Down;
                            i++;
                        }
                        else j++;
                        break;
                    case Direction.Down:
                        if (i == j + line - column)
                        {
                            direction = Direction.Left;
                            j--;
                        }
                        else i++;
                        break;
                    case Direction.Left:
                        if (j == line - 1 - i)
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
            return result.ToArray();
        }

        public void Test()
        {
            int[,] input = { 
                            { 01, 02, 03, 04, 05 }, 
                            { 06, 07, 08, 09, 10 }, 
                            { 11, 12, 13, 14, 15 },
                            { 16, 17, 18, 19, 20 },
                            { 21, 22, 23, 24, 25 },
                            { 26, 27, 28, 29, 30 }
                           };
            IList<int> result = SpiralOrder(input);
            foreach (int e in result) Console.Write(e + " ");
            Console.ReadLine();
        }
    }
}
