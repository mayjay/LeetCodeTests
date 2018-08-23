using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0042Trap
    {
        //给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。
        //上面是由数组 [0,1,0,2,1,0,1,3,2,1,2,1] 表示的高度图，在这种情况下，可以接 6 个单位的雨水（蓝色部分表示雨水）。 感谢 Marcos 贡献此图。
        //示例:
        //输入: [0,1,0,2,1,0,1,3,2,1,2,1]
        //输出: 6

        public int Trap(int[] height)
        {
            int result = 0;
            //clip both sides
            //start index
            int startIndex = -1;
            for (int i = 0; i < height.Length; i++)
            {
                if (i < height.Length - 1 && height[i] > height[i + 1])
                {
                    startIndex = i;
                    break;
                }
            }
            if (startIndex == -1) return result;
            //end index
            int endIndex = height.Length - 1;
            for (int i = height.Length - 1; i > 0; i--)
            {
                if (height[i] > height[i - 1])
                {
                    endIndex = i;
                    break;
                }
            }
            if (startIndex >= endIndex) return result;
            return TrapRecurse(height, startIndex, endIndex, result);
        }

        private int TrapRecurse(int[] height, int startIndex, int endIndex, int volumn)
        {
            //find max value in array and recurse
            int maxIndex = -1;
            int maxValue = 0;
            for (int i = startIndex + 1; i <= endIndex - 1; i++)
            {
                if (height[i] >= maxValue)
                {
                    maxValue = height[i];
                    maxIndex = i;
                }
            }
            //compare max with start and end
            if (maxIndex != -1 && (height[maxIndex] >= height[startIndex] || height[maxIndex] >= height[endIndex]))
            {
                return volumn + TrapRecurse(height, startIndex, maxIndex, volumn) + TrapRecurse(height, maxIndex, endIndex, volumn);
            }
            else
            {
                return volumn += PoolVolumn(height, startIndex, endIndex);
            }
        }

        private int PoolVolumn(int[] height, int startIndex, int endIndex)
        {
            int volumn = 0;
            //ignore same element at end of list
            while (endIndex - 1 >= 0)
            {
                if (height[endIndex] == height[endIndex - 1]) endIndex--;
                else break;
            }
            //clip peak
            int peak = height[0];
            while (startIndex < endIndex)
            {
                if (height[startIndex] < height[endIndex])
                {
                    if (height[endIndex - 1] < height[startIndex])
                    {
                        peak = height[startIndex];
                        break;
                    }
                    else endIndex--;
                }
                else if (height[startIndex] > height[endIndex])
                {
                    if (height[startIndex + 1] < height[endIndex])
                    {
                        peak = height[endIndex];
                        break;
                    }
                    else startIndex++;
                }
                else
                {
                    peak = height[startIndex];
                    break;
                }
            }
            //calucate volumn
            for (int i = startIndex + 1; i <= endIndex - 1; i++)
            {
                //each column volumn is value of peak - current
                volumn += Math.Abs(peak - height[i]);
            }
            Console.WriteLine("volumn " + volumn);
            return volumn;
        }

        public void Test()
        {
            //int[] input = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int[] input = { 9, 6, 8, 8, 5, 6, 3 };
            int result = Trap(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
