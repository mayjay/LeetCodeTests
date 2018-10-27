using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0124MaxPathSum
    {
        //给定一个非空二叉树，返回其最大路径和。
        //本题中，路径被定义为一条从树中任意节点出发，达到任意节点的序列。该路径至少包含一个节点，且不一定经过根节点。
        //示例 1:
        //输入: [1,2,3]
        //       1
        //      / \
        //     2   3
        //输出: 6
        //示例 2:
        //输入: [-10,9,20,null,null,15,7]
        //   -10
        //   / \
        //  9  20
        //    /  \
        //   15   7
        //输出: 42

        public int maxPathSum = int.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            if (root == null) return 0;
            MaxSum(root);
            return this.maxPathSum;
        }

        private int MaxSum(TreeNode root)
        {
            if (root == null)
                return 0;
            int value = root.val;
            int maxLeft = MaxSum(root.left);
            int maxRight = MaxSum(root.right);
            if (maxLeft > 0)
                value += maxLeft;
            if (maxRight > 0)
                value += maxRight;
            this.maxPathSum = Math.Max(this.maxPathSum, value);
            return Math.Max(root.val, Math.Max(root.val + maxLeft, root.val + maxRight));
        }

        public void Test()
        {
            TreeNode root = new TreeNode(-10);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            TreeNode input = root;
            int result = MaxPathSum(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
