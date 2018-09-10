using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0074SearchMatrix
    {
        //编写一个高效的算法来判断 m x n 矩阵中，是否存在一个目标值。该矩阵具有如下特性：
        //每行中的整数从左到右按升序排列。
        //每行的第一个整数大于前一行的最后一个整数。
        //示例 1:
        //输入:
        //matrix = [
        //  [1,   3,  5,  7],
        //  [10, 11, 16, 20],
        //  [23, 30, 34, 50]
        //]
        //target = 3
        //输出: true
        //示例 2:
        //输入:
        //matrix = [
        //  [1,   3,  5,  7],
        //  [10, 11, 16, 20],
        //  [23, 30, 34, 50]
        //]
        //target = 13
        //输出: false

        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix.Length == 0) return false;
            if (target < matrix[0, 0] || target > matrix[(matrix.Length - 1) / matrix.GetLength(1), (matrix.Length - 1) % matrix.GetLength(1)]) return false;
            int i = 0, j = matrix.Length;
            while (i < j)
            {
                int m = (i + j) / 2;
                int row = m / matrix.GetLength(1);
                int column = m % matrix.GetLength(1);
                if (i == m) 
                    return matrix[row, column] == target;
                if (matrix[row, column] == target)
                    return true;
                else if (matrix[row, column] < target)
                    i = m;
                else
                    j = m;
            }
            return false;
        }

        public void Test()
        {
            //int[,] matrix = { 
            //                { 1,   3,  5,  7 }, 
            //                { 10, 11, 16, 20 }, 
            //                { 23, 30, 34, 50 }
            //               };
            int[,] matrix = { 
                            { 1 }, 
                           };
            int target = 1;
            bool result = SearchMatrix(matrix, target);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
