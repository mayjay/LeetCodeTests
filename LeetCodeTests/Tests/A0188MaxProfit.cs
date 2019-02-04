using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0188MaxProfit
    {
        //给定一个数组，它的第 i 个元素是一支给定的股票在第 i 天的价格。
        //设计一个算法来计算你所能获取的最大利润。你最多可以完成 k 笔交易。
        //注意: 你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。
        //示例 1:
        //输入: [2,4,1], k = 2
        //输出: 2
        //解释: 在第 1 天 (股票价格 = 2) 的时候买入，在第 2 天 (股票价格 = 4) 的时候卖出，这笔交易所能获得利润 = 4-2 = 2 。
        //示例 2:
        //输入: [3,2,6,5,0,3], k = 2
        //输出: 7
        //解释: 在第 2 天 (股票价格 = 2) 的时候买入，在第 3 天 (股票价格 = 6) 的时候卖出, 这笔交易所能获得利润 = 6-2 = 4 。
        //     随后，在第 5 天 (股票价格 = 0) 的时候买入，在第 6 天 (股票价格 = 3) 的时候卖出, 这笔交易所能获得利润 = 3-0 = 3 。

        public int MaxProfit(int k, int[] prices)
        {
            if (prices == null || prices.Length < 2) return 0;
            int n = prices.Length;
            if (k >= n / 2) return Greed(prices);
            int[,] last = new int[n, k + 1];
            int[,] total = new int[n, k + 1];
            for(int t = 1; t <= k; t++) {
                for(int d = 1; d < n; d ++) {
                    last[d, t] = Math.Max(last[d-1, t] + prices[d] - prices[d-1], total[d-1, t-1] + Math.Max(0, prices[d] - prices[d-1]));
                    total[d, t] = Math.Max(total[d-1, t], last[d, t]);
                }
            }
            return total[n-1, k];
        }

        private int Greed(int[] prices)
        {
            int max = 0;
            for(int i = 1; i < prices.Length; i++)
                max += Math.Max(0, prices[i] - prices[i-1]);
            return max;
        }

        public void Test()
        {
            int k = 2;
            int[] prices = { 2, 4, 1 };
            int result = MaxProfit(k, prices);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
