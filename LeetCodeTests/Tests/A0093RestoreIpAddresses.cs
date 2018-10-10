using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0093RestoreIpAddresses
    {
        //给定一个只包含数字的字符串，复原它并返回所有可能的 IP 地址格式。
        //示例:
        //输入: "25525511135"
        //输出: ["255.255.11.135", "255.255.111.35"]

        public IList<string> RestoreIpAddresses(string s)
        {
            List<string> result = new List<string>();
            RestoreIpAddresses(s, 0, 0, new List<string>(4), result);
            return result;
        }

        private void RestoreIpAddresses(string s, int index, int count, List<string> candidate, List<string> result)
        {
            if (count >= 4)
            {
                StringBuilder sb = new StringBuilder(12);
                foreach (string str in candidate)
                    if (sb.Length == 0)
                        sb.Append(str);
                    else
                        sb.Append(".").Append(str);
                result.Add(sb.ToString());
                return;
            }
            for (int i = 1; i <= 3; i++)
            {
                int lengthLeft = s.Length - index - i;
                //check length left if valid
                if (lengthLeft >= (4 - 1 - count) && lengthLeft <= 3 * (4 - 1 - count))
                {
                    string ip = s.Substring(index, i);
                    int num = int.Parse(ip);
                    //also skip pattern like 01, 001, but 0 is valid
                    if (num >= 0 && num <= 255 && (ip[0] != '0' || ip == "0"))
                    {
                        //DFS
                        candidate.Add(ip);
                        RestoreIpAddresses(s, index + i, count + 1, candidate, result);
                        candidate.RemoveAt(candidate.Count - 1);
                    }
                }
            }
        }

        public void Test()
        {
            string input = "010010";
            IList<string> result = RestoreIpAddresses(input);
            foreach (string e in result)
                Console.WriteLine(e);
            Console.ReadLine();
        }
    }
}
