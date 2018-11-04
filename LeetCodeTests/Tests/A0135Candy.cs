using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0135Candy
    {
        //老师想给孩子们分发糖果，有 N 个孩子站成了一条直线，老师会根据每个孩子的表现，预先给他们评分。
        //你需要按照以下要求，帮助老师给这些孩子分发糖果：
        //每个孩子至少分配到 1 个糖果。
        //相邻的孩子中，评分高的孩子必须获得更多的糖果。
        //那么这样下来，老师至少需要准备多少颗糖果呢？
        //示例 1:
        //输入: [1,0,2]
        //输出: 5
        //解释: 你可以分别给这三个孩子分发 2、1、2 颗糖果。
        //示例 2:
        //输入: [1,2,2]
        //输出: 4
        //解释: 你可以分别给这三个孩子分发 1、2、1 颗糖果。
        //     第三个孩子只得到 1 颗糖果，这已满足上述两个条件。

        public int Candy(int[] ratings)
        {
            if (ratings.Length == 0) return 0;
            int[] candies = new int[ratings.Length];
            candies[0] = 1;
            for (int i = 1; i < candies.Length; i++)
            {
                candies[i] = 1;
                if (ratings[i] > ratings[i - 1])
                    candies[i] = candies[i - 1] + 1;
            }
            for (int i = candies.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                    candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }
            return candies.Sum();
        }

        public int Candy2(int[] ratings)
        {
            int[] candies = new int[ratings.Length];
            int visited = 0;
            while (visited < ratings.Length)
            {
                int minRating = int.MaxValue;
                int minIndex = -1;
                for (int i = 0; i < ratings.Length; i++)
                {
                    if (ratings[i] < minRating && candies[i] == 0)
                    {
                        minRating = ratings[i];
                        minIndex = i;
                    }
                }
                int left = 0, right = 0;
                if (minIndex > 0)
                    left = candies[minIndex - 1];
                if (minIndex < ratings.Length - 1)
                    right = candies[minIndex + 1];
                if (left == 0 && right == 0)
                    candies[minIndex] = 1;
                else if (left == 0)
                    candies[minIndex] = ratings[minIndex] > ratings[minIndex + 1] ? right + 1 : 1;
                else if (right == 0)
                    candies[minIndex] = ratings[minIndex] > ratings[minIndex - 1] ? left + 1 : 1;
                else
                {
                    if (ratings[minIndex] > ratings[minIndex - 1] && ratings[minIndex] > ratings[minIndex + 1])
                        candies[minIndex] = Math.Max(left, right) + 1;
                    else if (ratings[minIndex] > ratings[minIndex - 1])
                        candies[minIndex] = left + 1;
                    else if (ratings[minIndex] > ratings[minIndex + 1])
                        candies[minIndex] = right + 1;
                    else
                        candies[minIndex] = 1;
                }
                visited++;
            }
            return candies.Sum();
        }

        public void Test()
        {
            int[] input = { 1, 3, 2, 2, 1 };
            int result = Candy(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
