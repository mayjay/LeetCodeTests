using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0018FourSum
    {
        //给定一个包含 n 个整数的数组 nums 和一个目标值 target，判断 nums 中是否存在四个元素 a，b，c 和 d ，使得 a + b + c + d 的值与 target 相等？找出所有满足条件且不重复的四元组。
        //注意：
        //答案中不可以包含重复的四元组。
        //示例：
        //给定数组 nums = [1, 0, -1, 0, -2, 2]，和 target = 0。
        //满足要求的四元组集合为：
        //[
        //  [-1,  0, 0, 1],
        //  [-2, -1, 1, 2],
        //  [-2,  0, 0, 2]
        //]

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            if (nums.Length < 4) return new List<List<int>>().ToArray();

            List<List<int>> fourSumList = new List<List<int>>();
            //sort input to save duplication check consumption
            List<int> sortList = new List<int>(nums);
            sortList.Sort();
            nums = sortList.ToArray();
            for (int h = 0; h < nums.Length - 3; h++)
            {
                //if same nums[h], skip
                if (h > 0 && nums[h] == nums[h - 1]) continue;
                for (int i = h + 1; i < nums.Length - 2; i++)
                {
                    //if same nums[i], skip
                    if (i > 0 && i - 1 != h && nums[i] == nums[i - 1]) continue;
                    int j = i + 1;
                    int k = nums.Length - 1;
                    while (j < k)
                    {
                        int sum = nums[h] + nums[i] + nums[j] + nums[k];
                        if (sum == target)
                        {
                            List<int> fourSum = new List<int>();
                            fourSum.Add(nums[h]);
                            fourSum.Add(nums[i]);
                            fourSum.Add(nums[j]);
                            fourSum.Add(nums[k]);
                            //check duplications
                            if (fourSumList.Count() > 0)
                            {
                                bool isDuplicate = false;
                                List<int> last = fourSumList.Last();
                                for (int index = 0; index < last.Count(); index++)
                                {
                                    if (last[index] != fourSum[index]) break;
                                    else if (last[index] == fourSum[index] && index == last.Count() - 1) isDuplicate = true;
                                }
                                if (!isDuplicate) fourSumList.Add(fourSum);
                            }
                            else
                            {
                                fourSumList.Add(fourSum);
                            }
                        }
                        //update j,k
                        if (sum <= target) j++;
                        if (sum >= target) k--;
                    }
                }
            }
            return fourSumList.ToArray();
        }

        public void Test()
        {
            int[] nums = { 1, 0, -1, 0, -2, 2 };
            int target = 0;
            IList<IList<int>> result = FourSum(nums, target);
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
