using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0068FullJustify
    {
        //给定一个单词数组和一个长度 maxWidth，重新排版单词，使其成为每行恰好有 maxWidth 个字符，且左右两端对齐的文本。
        //你应该使用“贪心算法”来放置给定的单词；也就是说，尽可能多地往每行中放置单词。必要时可用空格 ' ' 填充，使得每行恰好有 maxWidth 个字符。
        //要求尽可能均匀分配单词间的空格数量。如果某一行单词间的空格不能均匀分配，则左侧放置的空格数要多于右侧的空格数。
        //文本的最后一行应为左对齐，且单词之间不插入额外的空格。
        //说明:
        //单词是指由非空格字符组成的字符序列。
        //每个单词的长度大于 0，小于等于 maxWidth。
        //输入单词数组 words 至少包含一个单词。
        //示例:
        //输入:
        //words = ["This", "is", "an", "example", "of", "text", "justification."]
        //maxWidth = 16
        //输出:
        //[
        //   "This    is    an",
        //   "example  of text",
        //   "justification.  "
        //]
        //示例 2:
        //输入:
        //words = ["What","must","be","acknowledgment","shall","be"]
        //maxWidth = 16
        //输出:
        //[
        //  "What   must   be",
        //  "acknowledgment  ",
        //  "shall be        "
        //]
        //解释: 注意最后一行的格式应为 "shall be    " 而不是 "shall     be",
        //     因为最后一行应为左对齐，而不是左右两端对齐。       
        //     第二行同样为左对齐，这是因为这行只包含一个单词。
        //示例 3:
        //输入:
        //words = ["Science","is","what","we","understand","well","enough","to","explain",
        //         "to","a","computer.","Art","is","everything","else","we","do"]
        //maxWidth = 20
        //输出:
        //[
        //  "Science  is  what we",
        //  "understand      well",
        //  "enough to explain to",
        //  "a  computer.  Art is",
        //  "everything  else  we",
        //  "do                  "
        //]

        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            List<List<string>> rows = new List<List<string>>();
            List<string> currentRow = new List<string>();
            int currentWidth = 0;
            foreach (string word in words)
            {
                int newWidth = currentRow.Count == 0 ? word.Length : currentWidth + 1 + word.Length;
                if (newWidth > maxWidth)
                {
                    //add current row to rows
                    rows.Add(currentRow);
                    currentRow = new List<string>();
                    currentWidth = word.Length;
                }
                else
                    currentWidth = newWidth;
                currentRow.Add(word);
            }
            //add last row
            rows.Add(currentRow);
            //handle each row
            List<string> result = new List<string>(rows.Count);
            for (int index = 0; index < rows.Count; index++)
            {
                List<string> row = rows[index];
                StringBuilder sb = new StringBuilder(maxWidth);
                //calculate space count
                int[] spaces = null;
                int spaceLength = maxWidth;
                foreach (string word in row)
                    spaceLength -= word.Length;
                if (index == rows.Count - 1)
                {
                    //last row
                    spaces = new int[row.Count];
                    int lastSpaceCount = spaceLength - (row.Count - 1);
                    for (int i = 0; i < spaces.Length; i++)
                    {
                        if (i < spaces.Length - 1) spaces[i] = 1;
                        else spaces[i] = lastSpaceCount;
                    }
                }
                else if (row.Count == 1)
                    spaces = new int[1] { maxWidth - row[0].Length };
                else
                {
                    spaces = new int[row.Count - 1];
                    int minSpaceCount = spaceLength / spaces.Length;
                    int remain = spaceLength - minSpaceCount * spaces.Length;
                    for (int i = 0; i < spaces.Length; i++)
                    {
                        if (i < remain) spaces[i] = minSpaceCount + 1;
                        else spaces[i] = minSpaceCount;
                    }
                }
                //fill row
                for (int i = 0; i < row.Count; i++)
                {
                    sb.Append(row[i]);
                    //append spaces
                    if (i < spaces.Length)
                        for (int j = 0; j < spaces[i]; j++)
                            sb.Append(' ');
                }
                result.Add(sb.ToString());
            }
            return result.ToArray();
        }

        public void Test()
        {
            string[] words = { "Listen", "to", "many,", "speak", "to", "a", "few." };
            int maxWidth = 6;
            IList<string> result = FullJustify(words, maxWidth);
            foreach (string str in result)
                Console.WriteLine(str + " " + str.Length);
            Console.ReadLine();
        }
    }
}
