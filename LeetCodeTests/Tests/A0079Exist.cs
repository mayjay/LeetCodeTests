using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0079Exist
    {
        //给定一个二维网格和一个单词，找出该单词是否存在于网格中。
        //单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。
        //示例:
        //board =
        //[
        //  ['A','B','C','E'],
        //  ['S','F','C','S'],
        //  ['A','D','E','E']
        //]
        //给定 word = "ABCCED", 返回 true.
        //给定 word = "SEE", 返回 true.
        //给定 word = "ABCB", 返回 false.

        public bool Exist(char[,] board, string word)
        {
            if (word.Length == 0) return false;
            for (int i = 0; i < board.Length; i++)
                if (DFS(board, word, i, new List<int>(word.Length)))
                    return true;
            return false;
        }

        private bool DFS(char[,] board, string word, int index, List<int> indexes)
        {
            int rowCount = board.GetLength(0);
            int columCount = board.GetLength(1);
            int i = index / columCount;
            int j = index % columCount;
            if (board[i, j] != word[indexes.Count]) return false;
            if (indexes.Contains(index)) return false;
            //equal char and duplicate, add index to indexes
            indexes.Add(index);

            //if match all
            if (indexes.Count == word.Length) return true;
            //up
            if (i > 0 && DFS(board, word, (i - 1) * columCount + j, new List<int>(indexes)))
                return true;
            //right
            if (j < columCount - 1 && DFS(board, word, i * columCount + j + 1, new List<int>(indexes)))
                return true;
            //down
            if (i < rowCount - 1 && DFS(board, word, (i + 1) * columCount + j, new List<int>(indexes)))
                return true;
            //left
            if (j > 0 && DFS(board, word, i * columCount + j - 1, new List<int>(indexes)))
                return true;
            return false;
        }

        public void Test()
        {
            char[,] board = { 
                            { 'A','B' }, 
                            { 'C','D' }, 
                           };
            string word = "ABCD";
            bool result = Exist(board, word);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
