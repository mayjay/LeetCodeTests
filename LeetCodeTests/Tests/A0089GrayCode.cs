using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0089GrayCode
    {
        //格雷编码是一个二进制数字系统，在该系统中，两个连续的数值仅有一个位数的差异。
        //给定一个代表编码总位数的非负整数 n，打印其格雷编码序列。格雷编码序列必须以 0 开头。
        //示例 1:
        //输入: 2
        //输出: [0,1,3,2]
        //解释:
        //00 - 0
        //01 - 1
        //11 - 3
        //10 - 2
        //对于给定的 n，其格雷编码序列并不唯一。
        //例如，[0,2,3,1] 也是一个有效的格雷编码序列。
        //00 - 0
        //10 - 2
        //11 - 3
        //01 - 1
        //示例 2:
        //输入: 0
        //输出: [0]
        //解释: 我们定义格雷编码序列必须以 0 开头。
        //     给定编码总位数为 n 的格雷编码序列，其长度为 2n。当 n = 0 时，长度为 20 = 1。
        //     因此，当 n = 0 时，其格雷编码序列为 [0]。

        public IList<int> GrayCode(int n)
        {
            //后面n-1位是把两位格雷码按照从右到左的顺序在每一位格雷码前面加一实现的
            int count = (int)Math.Pow(2, n);
            List<int> result = new List<int>(count);
            if (n == 0)
                result.Add(0);
            else 
            {
                result.Add(0);
                result.Add(1);
                for (int i = 1; i < n; i++)
                {
                    int l = (int)Math.Pow(2, i);
                    int r = (int)Math.Pow(2, i + 1);
                    for (int j = l; j < r; j++)
                    {
                        int num = (int)Math.Pow(2, i) + result[r - 1 - j];
                        result.Add(num);
                    }
                }
            }
            return result.ToArray();
        }


        public void Test()
        {
            int n = 4;
            IList<int> result = GrayCode(n);
            foreach (int e in result)
                Console.Write(e + " ");
            Console.ReadLine();
        }
    }
}
