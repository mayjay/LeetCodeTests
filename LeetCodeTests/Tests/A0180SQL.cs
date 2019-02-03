using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0180SQL
    {
        //编写一个 SQL 查询，查找所有至少连续出现三次的数字。
        //+----+-----+
        //| Id | Num |
        //+----+-----+
        //| 1  |  1  |
        //| 2  |  1  |
        //| 3  |  1  |
        //| 4  |  2  |
        //| 5  |  1  |
        //| 6  |  2  |
        //| 7  |  2  |
        //+----+-----+
        //例如，给定上面的 Logs 表， 1 是唯一连续出现至少三次的数字。
        //+-----------------+
        //| ConsecutiveNums |
        //+-----------------+
        //| 1               |
        //+-----------------+

        //# Write your MySQL query statement below
        //SELECT t1.Num as ConsecutiveNums
        //FROM logs AS t1, logs AS t2, logs AS t3
        //WHERE t1.Id = t2.Id-1 and t2.Id = t3.Id-1 and t1.Num = t2.Num and t2.Num = t3.Num
        //GROUP BY t1.Num
    }
}
