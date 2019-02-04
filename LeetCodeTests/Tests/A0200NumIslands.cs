using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0200NumIslands
    {
        //给定一个由 '1'（陆地）和 '0'（水）组成的的二维网格，计算岛屿的数量。一个岛被水包围，并且它是通过水平方向或垂直方向上相邻的陆地连接而成的。你可以假设网格的四个边均被水包围。
        //示例 1:
        //输入:
        //11110
        //11010
        //11000
        //00000
        //输出: 1
        //示例 2:
        //输入:
        //11000
        //11000
        //00100
        //00011
        //输出: 3

        public int NumIslands(char[,] grid)
        {
            int islandsCount = 0;
            while (true)
            {
                bool findLand = false;
                for (int i = 0; i < grid.Length; i++)
                {
                    int row = i / grid.GetLength(1);
                    int column = i % grid.GetLength(1);
                    if (grid[row, column] == '1')
                    {
                        findLand = true;
                        MarkSameIsland(grid, row, column);
                        break;
                    }
                }
                if (findLand)
                    islandsCount++;
                else
                    break;
            }
            return islandsCount;
        }

        private void MarkSameIsland(char[,] grid, int i, int j)
        {
            grid[i, j] = '0';
            if (i > 0 && grid[i - 1, j] == '1')
                MarkSameIsland(grid, i - 1, j);
            if (i < grid.GetLength(0) - 1 && grid[i + 1, j] == '1')
                MarkSameIsland(grid, i + 1, j);
            if (j > 0 && grid[i, j - 1] == '1')
                MarkSameIsland(grid, i, j - 1);
            if (j < grid.GetLength(1) - 1 && grid[i, j + 1] == '1')
                MarkSameIsland(grid, i, j + 1);
        }

        public void Test()
        {
            char[,] input = { 
                            { '1', '1', '0', '0', '0' }, 
                            { '1', '1', '0', '0', '0' }, 
                            { '0', '0', '1', '0', '0' }, 
                            { '0', '0', '0', '1', '1' }
                            };
            int result = NumIslands(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
