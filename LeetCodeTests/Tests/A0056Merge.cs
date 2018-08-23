using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0056Merge
    {
        //给出一个区间的集合，请合并所有重叠的区间。
        //示例 1:
        //输入: [[1,3],[2,6],[8,10],[15,18]]
        //输出: [[1,6],[8,10],[15,18]]
        //解释: 区间 [1,3] 和 [2,6] 重叠, 将它们合并为 [1,6].
        //示例 2:
        //输入: [[1,4],[4,5]]
        //输出: [[1,5]]
        //解释: 区间 [1,4] 和 [4,5] 可被视为重叠区间。

        public IList<Interval> Merge(IList<Interval> intervals)
        {
            //sort
            Comparison<Interval> comparison = new Comparison<Interval>((Interval interval1, Interval interval2) =>
            {
                if (interval1.start < interval2.start) return -1;
                else if (interval1.start > interval2.start) return 1;
                else if (interval1.end < interval2.end) return -1;
                else if (interval1.end > interval2.end) return 1;
                else return 0;
            });
            List<Interval> list = new List<Interval>(intervals);
            list.Sort(comparison);
            IList<Interval> result = new List<Interval>();
            foreach (Interval current in list)
            {
                if (result.Count == 0) 
                    result.Add(current);
                else
                {
                    Interval last = result.Last();
                    if (last.end < current.start)
                        result.Add(current);
                    else
                    {
                        //merge
                        Interval merge = new Interval(Math.Min(last.start, current.start), Math.Max(last.end, current.end));
                        result.Remove(last);
                        result.Add(merge);
                    }
                }
            }
            return result;
        }

        public void Test()
        {
            IList<Interval> input = new List<Interval>();
            input.Add(new Interval(1, 3));
            input.Add(new Interval(2, 6));
            input.Add(new Interval(8, 10));
            input.Add(new Interval(15, 18));
            IList<Interval> result = Merge(input);
            Console.WriteLine("result count " + result.Count());
            foreach (Interval e in result)
                Console.WriteLine(e.start + " " + e.end);
            Console.ReadLine();
        }
    }
}
