using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0176SQL
    {
        //编写一个 SQL 查询，获取 Employee 表中第二高的薪水（Salary） 。
        //+----+--------+
        //| Id | Salary |
        //+----+--------+
        //| 1  | 100    |
        //| 2  | 200    |
        //| 3  | 300    |
        //+----+--------+
        //例如上述 Employee 表，SQL查询应该返回 200 作为第二高的薪水。如果不存在第二高的薪水，那么查询应返回 null。
        //+---------------------+
        //| SecondHighestSalary |
        //+---------------------+
        //| 200                 |
        //+---------------------+

        //# Write your MySQL query statement below
        //select ifnull((select distinct Salary from Employee order by Salary desc limit 1 offset 1), null) as SecondHighestSalary;    
    }
}
