using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0012IntToRoman
    {
        //罗马数字包含以下七种字符： I， V， X， L，C，D 和 M。
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
        //给定一个整数，将其转为罗马数字。输入确保在 1 到 3999 的范围内。
        //示例 1:
        //输入: 3
        //输出: "III"
        //示例 2:
        //输入: 4
        //输出: "IV"
        //示例 3:
        //输入: 9
        //输出: "IX"
        //示例 4:
        //输入: 58
        //输出: "LVIII"
        //解释: C = 100, L = 50, XXX = 30, III = 3.
        //示例 5:
        //输入: 1994
        //输出: "MCMXCIV"
        //解释: M = 1000, CM = 900, XC = 90, IV = 4.

        static char[] romanChar = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

        public string IntToRoman(int num)
        {
            List<int> numArr = new List<int>();
            while (num > 0)
            {
                int digit = num % 10;
                numArr.Add(digit);
                num /= 10;
            }

            StringBuilder romanStr = new StringBuilder();
            for (int i = numArr.Count() - 1; i >= 0; i--)
            {
                char[] digitConvert = convert(numArr[i], i);
                if (digitConvert != null) romanStr.Append(digitConvert);
            }
            return romanStr.ToString();
        }

        private char[] convert(int digit, int index)
        {
            int indexChar = 2 * index;
            char[] output = null;
            //number too big
            if (index > 3 || (index == 3 && digit > 3)) return output;

            switch (digit)
            {
                case 1:
                    output = new char[] { romanChar[indexChar] };
                    break;
                case 2:
                    output = new char[] { romanChar[indexChar], romanChar[indexChar] };
                    break;
                case 3:
                    output = new char[] { romanChar[indexChar], romanChar[indexChar], romanChar[indexChar] };
                    break;
                case 4:
                    output = new char[] { romanChar[indexChar], romanChar[indexChar + 1] };
                    break;
                case 5:
                    output = new char[] { romanChar[indexChar + 1] };
                    break;
                case 6:
                    output = new char[] { romanChar[indexChar + 1], romanChar[indexChar] };
                    break;
                case 7:
                    output = new char[] { romanChar[indexChar + 1], romanChar[indexChar], romanChar[indexChar] };
                    break;
                case 8:
                    output = new char[] { romanChar[indexChar + 1], romanChar[indexChar], romanChar[indexChar], romanChar[indexChar] };
                    break;
                case 9:
                    output = new char[] { romanChar[indexChar], romanChar[indexChar + 2] };
                    break;
                default:
                    break;
            }
            return output;
        }

        public void Test()
        {
            int input = 1994;
            string result = IntToRoman(input);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
