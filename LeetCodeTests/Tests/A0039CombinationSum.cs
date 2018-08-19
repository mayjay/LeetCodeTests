using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0039CombinationSum
    {
        //给定一个无重复元素的数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
        //candidates 中的数字可以无限制重复被选取。
        //说明：
        //所有数字（包括 target）都是正整数。
        //解集不能包含重复的组合。 
        //示例 1:
        //输入: candidates = [2,3,6,7], target = 7,
        //所求解集为:
        //[
        //  [7],
        //  [2,2,3]
        //]
        //示例 2:
        //输入: candidates = [2,3,5], target = 8,
        //所求解集为:
        //[
        //  [2,2,2,2],
        //  [2,3,3],
        //  [3,5]
        //]

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<List<int>> combinations = new List<List<int>>();
            Array.Sort(candidates);
            if (candidates.Length == 0 || candidates[0] > target) return combinations.ToArray();
            List<int> tmp = new List<int>();
            DFS(candidates, 0, target, tmp, combinations);
            return combinations.ToArray();
        }

        private void DFS(int[] candidates, int index, int target, List<int> tmp, List<List<int>> combinations)
        {
            if (target == 0)
            {
                //copy instead of reference
                combinations.Add(new List<int>(tmp));
            }
            else if (target > 0)
            {
                for (int i = index; i < candidates.Length; i++)
                {
                    tmp.Add(candidates[i]);
                    DFS(candidates, i, target - candidates[i], tmp, combinations);
                    tmp.RemoveAt(tmp.Count - 1);
                }
            }
        }

        public void Test()
        {
            int[] candidates = { 2, 3, 6, 7 };
            int target = 7;
            IList<IList<int>> result = CombinationSum(candidates, target);
            Console.WriteLine("result count " + result.Count());
            foreach (IList<int> e in result)
            {
                foreach (int num in e) Console.Write(num + " ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
