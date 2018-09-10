using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0073SetZeroes
    {
        //给定一个 m x n 的矩阵，如果一个元素为 0，则将其所在行和列的所有元素都设为 0。请使用原地算法。
        //示例 1:
        //输入: 
        //[
        //  [1,1,1],
        //  [1,0,1],
        //  [1,1,1]
        //]
        //输出: 
        //[
        //  [1,0,1],
        //  [0,0,0],
        //  [1,0,1]
        //]
        //示例 2:

        //输入: 
        //[
        //  [0,1,2,0],
        //  [3,4,5,2],
        //  [1,3,1,5]
        //]
        //输出: 
        //[
        //  [0,0,0,0],
        //  [0,4,5,0],
        //  [0,3,1,0]
        //]
        //进阶:
        //一个直接的解决方案是使用  O(mn) 的额外空间，但这并不是一个好的解决方案。
        //一个简单的改进方案是使用 O(m + n) 的额外空间，但这仍然不是最好的解决方案。
        //你能想出一个常数空间的解决方案吗？

        public void SetZeroes(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            int[] rows = new int[row];
            int[] columns = new int[column];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] == 0)
                    {
                        rows[i] = 1;
                        columns[j] = 1;
                    }
            for (int i = 0; i < rows.Length; i++)
                if (rows[i] == 1)
                    for (int j = 0; j < column; j++)
                        matrix[i, j] = 0;
            for (int i = 0; i < columns.Length; i++)
                if (columns[i] == 1)
                    for (int j = 0; j < row; j++)
                        matrix[j, i] = 0;
        }

        public void Test()
        {
            int[,] input = { 
                            { 0,1,2,0 }, 
                            { 3,4,5,2 }, 
                            { 1,3,1,5 }
                           };
            SetZeroes(input);
            int count = 0;
            int column = input.GetLength(1);
            foreach (int e in input)
            {
                Console.Write(e + " ");
                count++;
                if (count == column)
                {
                    count = 0;
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}
