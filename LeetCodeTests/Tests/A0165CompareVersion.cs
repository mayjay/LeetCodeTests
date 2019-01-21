using System;
namespace LeetCodeTests.Tests
{
    public class A0165CompareVersion
    {
        //比较两个版本号 version1 和 version2。
        //如果 version1 > version2 返回 1，如果 version1<version2 返回 -1， 除此之外返回 0。
        //你可以假设版本字符串非空，并且只包含数字和.字符。
        // . 字符不代表小数点，而是用于分隔数字序列。
        //例如，2.5 不是“两个半”，也不是“差一半到三”，而是第二版中的第五个小版本。
        //示例 1:
        //输入: version1 = "0.1", version2 = "1.1"
        //输出: -1
        //示例 2:
        //输入: version1 = "1.0.1", version2 = "1"
        //输出: 1
        //示例 3:
        //输入: version1 = "7.5.2.4", version2 = "7.5.3"
        //输出: -1

        public int CompareVersion(string version1, string version2)
        {
            string[] v1 = version1.Split('.');
            string[] v2 = version2.Split('.');
            int minCount = Math.Min(v1.Length, v2.Length);
            for (int i = 0; i < minCount; i++)
            {
                int num1 = int.Parse(v1[i]);
                int num2 = int.Parse(v2[i]);
                if (num1 > num2)
                    return 1;
                else if (num1 < num2)
                    return -1;
            }
            if (v1.Length == v2.Length)
                return 0;
            else if (v1.Length > v2.Length)
            {
                for (int i = v2.Length; i < v1.Length; i++)
                {
                    int num = int.Parse(v1[i]);
                    if (num > 0)
                        return 1;
                }
                return 0;
            }
            else 
            {
                for (int i = v1.Length; i < v2.Length; i++)
                {
                    int num = int.Parse(v2[i]);
                    if (num > 0)
                        return -1;
                }
                return 0;
            }
        }

        public void Test()
        {
            string version1 = "1.0";
            string version2 = "1";
            int result = CompareVersion(version1, version2);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
