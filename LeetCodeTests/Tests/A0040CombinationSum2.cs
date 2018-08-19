using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0040CombinationSum2
    {
        //给定一个数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
        //candidates 中的每个数字在每个组合中只能使用一次。
        //说明：
        //所有数字（包括目标数）都是正整数。
        //解集不能包含重复的组合。 
        //示例 1:
        //输入: candidates = [10,1,2,7,6,1,5], target = 8,
        //所求解集为:
        //[
        //  [1, 7],
        //  [1, 2, 5],
        //  [2, 6],
        //  [1, 1, 6]
        //]
        //示例 2:
        //输入: candidates = [2,5,2,1,2], target = 5,
        //所求解集为:
        //[
        //  [1,2,2],
        //  [5]
        //]

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
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
                    //avoid repeat combination
                    if (i > index && candidates[i - 1] == candidates[i]) continue;
                    tmp.Add(candidates[i]);
                    //index use (i + 1) for unreapted candidate element
                    DFS(candidates, i + 1, target - candidates[i], tmp, combinations);
                    tmp.RemoveAt(tmp.Count - 1);
                }
            }
        }

        public void Test()
        {
            int[] candidates = { 10, 1, 2, 7, 6, 1, 5 };
            int target = 8;
            IList<IList<int>> result = CombinationSum2(candidates, target);
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
