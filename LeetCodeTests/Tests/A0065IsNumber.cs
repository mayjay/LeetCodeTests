using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0065IsNumber
    {
        //验证给定的字符串是否为数字。
        //例如:
        //"0" => true
        //" 0.1 " => true
        //"abc" => false
        //"1 a" => false
        //"2e10" => true
        //说明: 我们有意将问题陈述地比较模糊。在实现代码之前，你应当事先思考所有可能的情况。
        //更新于 2015-02-10:
        //C++函数的形式已经更新了。如果你仍然看见你的函数接收 const char * 类型的参数，请点击重载按钮重置你的代码。

        public bool IsNumber(string s)
        {
            s = s.Trim();
            if (IsFloat(s)) return true;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'e' || s[i] == 'E')
                    return IsFloat(s.Substring(0, i)) && IsInt(s.Substring(i + 1));
            }
            return false;
        }

        private bool IsUnsignedInt(string s)
        {
            if (s.Length == 0) return false;
            for (int i = 0; i < s.Length; i++)
                if (!char.IsDigit(s[i])) return false;
            return true;
        }

        private bool IsInt(string s)
        {
            if (IsUnsignedInt(s)) return true;
            if (s.Length == 0) return false;
            if (s[0] == '+' || s[0] == '-')
                return IsUnsignedInt(s.Substring(1));
            return false;
        }

        private bool IsFloat(string s)
        {
            if (IsInt(s)) return true;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '.')
                {
                    //first or last char can be '.'
                    if (i == 0 || (i == 1 && (s[0] == '+' || s[0] == '-'))) return IsUnsignedInt(s.Substring(i + 1));
                    if (i == s.Length - 1) return IsInt(s.Substring(0, i));
                    return IsInt(s.Substring(0, i)) && IsUnsignedInt(s.Substring(i + 1));
                }
            }
            return false;
        }

        public void Test()
        {
            string input = "+.8";
            bool result = IsNumber(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
