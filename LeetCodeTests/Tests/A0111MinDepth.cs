using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0111MinDepth
    {
        //给定一个二叉树，找出其最小深度。

        //最小深度是从根节点到最近叶子节点的最短路径上的节点数量。

        //说明: 叶子节点是指没有子节点的节点。

        //示例:

        //给定二叉树 [3,9,20,null,null,15,7],

        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7
        //返回它的最小深度  2.

        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null)
                return 1 + MinDepth(root.right);
            if (root.right == null)
                return 1 + MinDepth(root.left);
            return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
        }

        public void Test()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            TreeNode input = root;
            int result = MinDepth(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
