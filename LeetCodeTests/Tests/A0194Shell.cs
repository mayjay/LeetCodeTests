﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0194Shell
    {
        //给定一个文件 file.txt，转置它的内容。
        //你可以假设每行列数相同，并且每个字段由 ' ' 分隔.
        //示例:
        //假设 file.txt 文件内容如下：
        //name age
        //alice 21
        //ryan 30
        //应当输出：
        //name alice ryan
        //age 21 30

        //# Read from the file file.txt and print its transposed content to stdout.
        //awk '{for(i=1;i<=NF;i++) {if(NR==1){res[i]=$i;}else{res[i]=res[i]" "$i} } }END{for(i=1;i<=NF;i++) print res[i]} ' file.txt
    }
}
