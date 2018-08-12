using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0006Convert
    {
        //将字符串 "PAYPALISHIRING" 以Z字形排列成给定的行数：
        //P   A   H   N
        //A P L S I I G
        //Y   I   R
        //之后从左往右，逐行读取字符："PAHNAPLSIIGYIR"
        //实现一个将字符串进行指定行数变换的函数:
        //string convert(string s, int numRows);
        //示例 1:
        //输入: s = "PAYPALISHIRING", numRows = 3
        //输出: "PAHNAPLSIIGYIR"
        //示例 2:
        //输入: s = "PAYPALISHIRING", numRows = 4
        //输出: "PINALSIGYAHRPI"
        //解释:
        //P     I    N
        //A   L S  I G
        //Y A   H R
        //P     I

        public string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;

            int numPerBlock = numRows + numRows - 2;
            int numBlock = (int)Math.Ceiling(s.Length / (double)numPerBlock);
            char[,] matrics = new char[numRows, numBlock * (numRows - 1)];
            for (int i = 0; i < numBlock; i++)
            {
                for(int j = 0; j < numPerBlock; j++)
                {
                    //if exceed length of s, break loop
                    if (numPerBlock * i + j > s.Length - 1) break;

                    if (j < numRows)
                    {
                        matrics[j, i * (numRows - 1)] = s[numPerBlock * i + j];
                    }
                    else
                    {
                        matrics[numRows - 1 - (j - numRows + 1), i * (numRows - 1) + (j - numRows + 1)] = s[numPerBlock * i + j];
                    }
                }
            }
            char[] charArr = new char[s.Length];
            int index = 0;
            foreach(char ch in matrics)
            {
                if(ch != '\0')
                {
                    charArr[index] = ch;
                    index++;
                }
            }
            //OutputMatrics(matrics, numBlock * (numRows - 1));
            return new string(charArr);
        }

        private void OutputMatrics(char[,] matrics, int columns)
        {
            int index = 0;
            foreach (char ch in matrics)
            {
                Console.Write(ch + "");
                index++;
                if (index >= columns)
                {
                    index = 0;
                    Console.WriteLine();
                }
            }
        }

        public void Test()
        {
            string input = "PAYPALISHIRING";
            int numRows = 3;
            string result = Convert(input, numRows);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
