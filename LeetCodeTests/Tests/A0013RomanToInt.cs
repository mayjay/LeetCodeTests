using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0013RomanToInt
    {
        //罗马数字包含以下七种字符：I， V， X， L，C，D 和 M。
        //字符          数值
        //I             1
        //V             5
        //X             10
        //L             50
        //C             100
        //D             500
        //M             1000
        //例如， 罗马数字 2 写做 II ，即为两个并列的 1。12 写做 XII ，即为 X + II 。 27 写做  XXVII, 即为 XX + V + II 。
        //通常情况下，罗马数字中小的数字在大的数字的右边。但也存在特例，例如 4 不写做 IIII，而是 IV。数字 1 在数字 5 的左边，所表示的数等于大数 5 减小数 1 得到的数值 4 。同样地，数字 9 表示为 IX。这个特殊的规则只适用于以下六种情况：
        //I 可以放在 V (5) 和 X (10) 的左边，来表示 4 和 9。
        //X 可以放在 L (50) 和 C (100) 的左边，来表示 40 和 90。 
        //C 可以放在 D (500) 和 M (1000) 的左边，来表示 400 和 900。
        //给定一个罗马数字，将其转换成整数。输入确保在 1 到 3999 的范围内。
        //示例 1:
        //输入: "III"
        //输出: 3
        //示例 2:
        //输入: "IV"
        //输出: 4
        //示例 3:
        //输入: "IX"
        //输出: 9
        //示例 4:
        //输入: "LVIII"
        //输出: 58
        //解释: C = 100, L = 50, XXX = 30, III = 3.
        //示例 5:
        //输入: "MCMXCIV"
        //输出: 1994
        //解释: M = 1000, CM = 900, XC = 90, IV = 4.

        static char[] romanChar = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

        public int RomanToInt(string s)
        {
            List<int> numArr = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (IsSpecial(s, i))
                {
                    char[] specialCharArr = new char[] { s[i], s[i + 1] };
                    numArr.Add(CharToInt(specialCharArr));
                    //skip next letter
                    i++;
                }
                else
                {
                    numArr.Add(CharToInt(s[i]));
                }
                
            }
            return numArr.Sum();
        }

        private bool IsSpecial(string s, int index)
        {
            if (index >= s.Length - 1) return false;
            if (s[index] == 'I' && (s[index + 1] == 'V' || s[index + 1] == 'X')) return true;
            if (s[index] == 'X' && (s[index + 1] == 'L' || s[index + 1] == 'C')) return true;
            if (s[index] == 'C' && (s[index + 1] == 'D' || s[index + 1] == 'M')) return true;
            return false;
        }

        private int CharToInt(char c)
        {
            switch (c)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
            }
            return 0;
        }

        private int CharToInt(char[] charArr)
        {
            switch (charArr[0])
            {
                case 'I':
                    switch (charArr[1])
                    {
                        case 'V':
                            return 4;
                        case 'X':
                            return 9;
                    }
                    break;
                case 'X':
                    switch (charArr[1])
                    {
                        case 'L':
                            return 40;
                        case 'C':
                            return 90;

                    }
                    break;
                case 'C':
                    switch (charArr[1])
                    {
                        case 'D':
                            return 400;
                        case 'M':
                            return 900;

                    }
                    break;
            }
            return 0;
        }

        public void Test()
        {
            string input = "MCMXCIV";
            int result = RomanToInt(input);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
