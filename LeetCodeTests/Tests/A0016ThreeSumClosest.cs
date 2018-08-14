using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0016ThreeSumClosest
    {
        //给定一个包括 n 个整数的数组 nums 和 一个目标值 target。找出 nums 中的三个整数，使得它们的和与 target 最接近。返回这三个数的和。假定每组输入只存在唯一答案。
        //例如，给定数组 nums = [-1，2，1，-4], 和 target = 1.
        //与 target 最接近的三个数的和为 2. (-1 + 2 + 1 = 2).

        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums.Length < 3) return 0;
            //sort array
            List<int> sortList = new List<int>(nums);
            sortList.Sort();
            nums = sortList.ToArray();

            int result = 0;
            int minAbs = int.MaxValue;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                //if same nums[i], skip
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    int abs = Math.Abs(sum - target);
                    if (abs < minAbs)
                    {
                        minAbs = abs;
                        result = sum;
                    }
                    //update j,k
                    if (sum <= target) j++;
                    if (sum >= target) k--;
                }
            }
            return result;
        }

        public void Test()
        {
            int[] nums = { -1, 2, 1, -4 };
            int target = 1;
            int result = ThreeSumClosest(nums, target);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
