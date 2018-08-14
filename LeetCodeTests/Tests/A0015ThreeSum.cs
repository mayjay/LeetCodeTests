using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0015ThreeSum
    {
        //给定一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？找出所有满足条件且不重复的三元组。
        //注意：答案中不可以包含重复的三元组。
        //例如, 给定数组 nums = [-1, 0, 1, 2, -1, -4]，
        //满足要求的三元组集合为：
        //[
        //  [-1, 0, 1],
        //  [-1, -1, 2]
        //]

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3) return new List<List<int>>().ToArray();

            List<List<int>> threeSumList = new List<List<int>>();
            //sort input to save duplication check consumption
            List<int> sortList = new List<int>(nums);
            sortList.Sort();
            nums = sortList.ToArray();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                //if same nums[i], skip
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0)
                    {
                        List<int> threeSum = new List<int>();
                        threeSum.Add(nums[i]);
                        threeSum.Add(nums[j]);
                        threeSum.Add(nums[k]);
                        //check duplications
                        if (threeSumList.Count() > 0)
                        {
                            bool isDuplicate = false;
                            List<int> last = threeSumList.Last();
                            for (int index = 0; index < last.Count(); index++)
                            {
                                if (last[index] != threeSum[index]) break;
                                else if (last[index] == threeSum[index] && index == last.Count() - 1) isDuplicate = true;
                            }
                            if (!isDuplicate) threeSumList.Add(threeSum);
                        }
                        else
                        {
                            threeSumList.Add(threeSum);
                        }
                    }
                    //update j,k
                    if (sum <= 0) j++;
                    if (sum >= 0) k--;
                }
            }
            return threeSumList.ToArray();
        }

        public void Test()
        {
            int[] input = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> result = ThreeSum(input);
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
