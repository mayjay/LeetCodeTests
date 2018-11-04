using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0149MaxPoints
    {
        //给定一个二维平面，平面上有 n 个点，求最多有多少个点在同一条直线上。
        //示例 1:
        //输入: [[1,1],[2,2],[3,3]]
        //输出: 3
        //解释:
        //^
        //|
        //|        o
        //|     o
        //|  o  
        //+------------->
        //0  1  2  3  4
        //示例 2:
        //输入: [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
        //输出: 4
        //解释:
        //^
        //|
        //|  o
        //|     o        o
        //|        o
        //|  o        o
        //+------------------->
        //0  1  2  3  4  5  6

        public int MaxPoints(Point[] points)
        {
            if (points.Length <= 2)
                return points.Length;
		    int[] count = new int[points.Length];
		    for (int i = 0; i < points.Length; i++)
            {
			    count[i] = 1;
			    int size = 1;
			    int same = 0;
                Dictionary<int[], int> hashMap = new Dictionary<int[],int>();
			    for (int j = 0; j < points.Length; j++) 
                {
                    if (i == j) continue;
                    if(points[i].x != points[j].x) 
                    {
						int dy = points[i].y - points[j].y;
						int dx = points[i].x - points[j].x; 
						int gcd = GenerateGCD(dy, dx);
						if(gcd != 0) 
                        {
							dy = dy / gcd;
							dx = dx / gcd;
						}
						int[] nums = new int[2];
						nums[0] = dy;
						nums[1] = dx;
						bool flag = false;
                        int[] key = null;
                        foreach (int[] array in hashMap.Keys)
                        {
							if(nums[0] == array[0] && nums[1] == array[1]) 
                            {
								flag = true;
                                key = array;
                                break;
							}

                        }
                        if (key != null)
                            hashMap[key] += 1;
						if(!flag)
							hashMap.Add(nums, 1);
					}
                    else 
                    {
						if(points[i].y == points[j].y)
							same++;
						size++;
					}
			    }
                foreach (int[] array in hashMap.Keys)
				    if(hashMap[array] + 1 > count[i])
					    count[i] = hashMap[array] + 1;
			    count[i] += same;
			    count[i] = Math.Max(count[i], size);
		    }
		    int maxIndex = 0;
		    for (int i = 1; i < count.Length; i++)
			    if(count[i] > count[maxIndex])
				    maxIndex = i;
		    return count[maxIndex];
        }

        // 欧几里得算法：计算最大公约数
        private int GenerateGCD(int x, int y)
        {
            if (y == 0)
                return x;
            return GenerateGCD(y, x % y);
        }

        public void Test()
        {
            Point[] input = new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3) };
            int result = MaxPoints(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
