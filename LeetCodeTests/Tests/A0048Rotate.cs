﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0048Rotate
    {
        //给定一个 n × n 的二维矩阵表示一个图像。
        //将图像顺时针旋转 90 度。
        //说明：
        //你必须在原地旋转图像，这意味着你需要直接修改输入的二维矩阵。请不要使用另一个矩阵来旋转图像。
        //示例 1:
        //给定 matrix = 
        //[
        //  [1,2,3],
        //  [4,5,6],
        //  [7,8,9]
        //],
        //原地旋转输入矩阵，使其变为:
        //[
        //  [7,4,1],
        //  [8,5,2],
        //  [9,6,3]
        //]
        //示例 2:
        //给定 matrix =
        //[
        //  [ 5, 1, 9,11],
        //  [ 2, 4, 8,10],
        //  [13, 3, 6, 7],
        //  [15,14,12,16]
        //], 
        //原地旋转输入矩阵，使其变为:
        //[
        //  [15,13, 2, 5],
        //  [14, 3, 4, 1],
        //  [12, 6, 8, 9],
        //  [16, 7,10,11]
        //]

        public void Rotate(int[,] matrix)
        {
            int column = matrix.GetUpperBound(0) + 1;
            //transpose matrix
            for (int i = 0; i < column; i++)
            {
                for (int j = i; j < column; j++)
                {
                    if (i != j)
                    {
                        int tmp = matrix[i, j];
                        matrix[i, j] = matrix[j, i];
                        matrix[j, i] = tmp;
                    }
                }
            }
            //flip matrix
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < column / 2; j++)
                {
                    int tmp = matrix[i, j];
                    matrix[i, j] = matrix[i, column - 1 - j];
                    matrix[i, column - 1 - j] = tmp;
                }
            }
        }

        public void Test()
        {
            int[,] input = { 
                            { 1, 2, 3 }, 
                            { 4, 5, 6 }, 
                            { 7, 8, 9 }
                           };
            Rotate(input);
            int count = 0;
            int column = input.GetUpperBound(0) + 1;
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