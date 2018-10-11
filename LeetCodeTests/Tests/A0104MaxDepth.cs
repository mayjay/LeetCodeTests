using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0104MaxDepth
    {
        //给定一个二叉树，找出其最大深度。
        //二叉树的深度为根节点到最远叶子节点的最长路径上的节点数。
        //说明: 叶子节点是指没有子节点的节点。
        //示例：
        //给定二叉树 [3,9,20,null,null,15,7]，
        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7
        //返回它的最大深度 3 。

        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }

        public void Test()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            TreeNode input = root;
            int result = MaxDepth(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
