using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0177SQL
    {
        //编写一个 SQL 查询，获取 Employee 表中第 n 高的薪水（Salary）。
        //+----+--------+
        //| Id | Salary |
        //+----+--------+
        //| 1  | 100    |
        //| 2  | 200    |
        //| 3  | 300    |
        //+----+--------+
        //例如上述 Employee 表，n = 2 时，应返回第二高的薪水 200。如果不存在第 n 高的薪水，那么查询应返回 null。
        //+------------------------+
        //| getNthHighestSalary(2) |
        //+------------------------+
        //| 200                    |
        //+------------------------+

        //CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
        //BEGIN
        //  DECLARE m INT;
        //  SET m = N - 1;
        //  RETURN (
        //      # Write your MySQL query statement below.
        //      select ifnull((select distinct Salary from Employee order by Salary desc limit 1 offset m), null)
        //  );
        //END
    }
}
