using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0071SimplifyPath
    {
        //给定一个文档 (Unix-style) 的完全路径，请进行路径简化。
        //例如，
        //path = "/home/", => "/home"
        //path = "/a/./b/../../c/", => "/c"
        //边界情况:
        //你是否考虑了 路径 = "/../" 的情况？
        //在这种情况下，你需返回 "/" 。
        //此外，路径中也可能包含多个斜杠 '/' ，如 "/home//foo/" 。
        //在这种情况下，你可忽略多余的斜杠，返回 "/home/foo" 。

        public string SimplifyPath(string path)
        {
            string[] splits = path.Split('/');
            StringBuilder sb = new StringBuilder(splits.Length);
            for (int i = 0; i < splits.Length; i++)
            {
                //ignore "."
                if (splits[i] == ".")
                    splits[i] = "";
                else if (splits[i] == "..")
                {
                    splits[i] = "";
                    int former = i - 1;
                    while (former >= 0)
                    {
                        if (splits[former] == "")
                            former--;
                        else
                        {
                            splits[former] = "";
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < splits.Length; i++)
            {
                if (splits[i] != "")
                {
                    sb.Append('/');
                    sb.Append(splits[i]);
                }
            }
            if (sb.Length == 0)
                sb.Append('/');
            return sb.ToString();
        }

        public void Test()
        {
            string input = "/home//foo/";
            string result = SimplifyPath(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
