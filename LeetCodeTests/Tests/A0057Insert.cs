using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0057Insert
    {
        //给出一个无重叠的 ，按照区间起始端点排序的区间列表。
        //在列表中插入一个新的区间，你需要确保列表中的区间仍然有序且不重叠（如果有必要的话，可以合并区间）。
        //示例 1:
        //输入: intervals = [[1,3],[6,9]], newInterval = [2,5]
        //输出: [[1,5],[6,9]]
        //示例 2:
        //输入: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
        //输出: [[1,2],[3,10],[12,16]]
        //解释: 这是因为新的区间 [4,8] 与 [3,5],[6,7],[8,10] 重叠。

        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            List<Interval> result = new List<Interval>();
            Interval tmp = new Interval(newInterval.start, newInterval.end);
            bool tmpAdded = false;
            foreach (Interval current in intervals)
            {
                if (tmpAdded || newInterval.start > current.end)
                    result.Add(current);
                else if (!tmpAdded && current.start > tmp.end)
                {
                    result.Add(tmp);
                    tmpAdded = true;
                    result.Add(current);
                }
                else
                {
                    int min = Math.Min(current.start, newInterval.start);
                    tmp.start = Math.Min(tmp.start, min);
                    int max = Math.Max(current.end, newInterval.end);
                    tmp.end = Math.Max(tmp.end, max);
                }
            }
            //if tmp not added, add it
            if (!tmpAdded)
                result.Add(tmp);
            return result;
        }

        public void Test()
        {
            IList<Interval> intervals = new List<Interval>();
            //intervals.Add(new Interval(1, 2));
            intervals.Add(new Interval(0, 7));
            intervals.Add(new Interval(8, 8));
            intervals.Add(new Interval(9, 11));
            //intervals.Add(new Interval(12, 16));
            Interval newInterval = new Interval(4, 13);
            IList<Interval> result = Insert(intervals, newInterval);
            Console.WriteLine("result count " + result.Count());
            foreach (Interval e in result)
                Console.WriteLine(e.start + " " + e.end);
            Console.ReadLine();
        }
    }
}
