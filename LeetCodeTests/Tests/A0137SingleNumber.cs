using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0137SingleNumber
    {
        //给定一个非空整数数组，除了某个元素只出现一次以外，其余每个元素均出现了三次。找出那个只出现了一次的元素。
        //说明：
        //你的算法应该具有线性时间复杂度。 你可以不使用额外空间来实现吗？
        //示例 1:
        //输入: [2,2,3,2]
        //输出: 3
        //示例 2:
        //输入: [0,1,0,1,0,1,99]
        //输出: 99

        public int SingleNumber(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!dict.ContainsKey(num))
                    dict.Add(num, 1);
                else
                    dict[num]++;
            }
            foreach (KeyValuePair<int, int> pair in dict)
            {
                if (pair.Value == 1)
                    return pair.Key;
            }
            return 0;
        }

        public void Test()
        {
            int[] input = { 2, 2, 3, 2 };
            int result = SingleNumber(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
