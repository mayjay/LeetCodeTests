using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0100IsSameTree
    {
        //给定两个二叉树，编写一个函数来检验它们是否相同。
        //如果两个树在结构上相同，并且节点具有相同的值，则认为它们是相同的。
        //示例 1:
        //输入:       1         1
        //          / \       / \
        //         2   3     2   3
        //        [1,2,3],   [1,2,3]
        //输出: true
        //示例 2:
        //输入:      1          1
        //          /           \
        //         2             2
        //        [1,2],     [1,null,2]
        //输出: false
        //示例 3:
        //输入:       1         1
        //          / \       / \
        //         2   1     1   2
        //        [1,2,1],   [1,1,2]
        //输出: false

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if ((p == null && q != null) || (p != null && q == null))
                return false;
            if (p == null && q == null)
                return true;
            if (p.val != q.val)
                return false;
            if (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right))
                return true;
            return false;
        }

        public void Test()
        {
            TreeNode p = new TreeNode(1);
            p.left = new TreeNode(2);
            TreeNode q = new TreeNode(1);
            q.right = new TreeNode(2);
            bool result = IsSameTree(p, q);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
