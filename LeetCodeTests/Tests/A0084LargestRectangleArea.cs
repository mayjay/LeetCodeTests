using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0084LargestRectangleArea
    {
        //给定 n 个非负整数，用来表示柱状图中各个柱子的高度。每个柱子彼此相邻，且宽度为 1 。
        //求在该柱状图中，能够勾勒出来的矩形的最大面积。
        //以上是柱状图的示例，其中每个柱子的宽度为 1，给定的高度为 [2,1,5,6,2,3]。
        //图中阴影部分为所能勾勒出的最大矩形面积，其面积为 10 个单位。
        //示例:
        //输入: [2,1,5,6,2,3]
        //输出: 10

        public int LargestRectangleArea(int[] heights)
        {
            //遍历数组，每找到一个局部峰值，然后向前遍历所有的值，算出共同的矩形面积，每次对比保留最大值。
            int largestArea = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                if (i < heights.Length - 1 && heights[i] < heights[i + 1]) continue;
                int min = heights[i];
                for (int j = i; j >= 0; j--)
                {
                    min = Math.Min(min, heights[j]);
                    largestArea = Math.Max(largestArea, (i - j + 1) * min);
                }
            }
            return largestArea;
        }

        public void Test()
        {
            int[] input = { 2, 1, 5, 6, 2, 3 };
            int result = LargestRectangleArea(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
