using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0110IsBalanced
    {
        //给定一个二叉树，判断它是否是高度平衡的二叉树。
        //本题中，一棵高度平衡二叉树定义为：
        //一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过1。
        //示例 1:
        //给定二叉树 [3,9,20,null,null,15,7]
        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7
        //返回 true 。
        //示例 2:
        //给定二叉树 [1,2,2,3,3,null,null,4,4]

        //       1
        //      / \
        //     2   2
        //    / \
        //   3   3
        //  / \
        // 4   4
        //返回 false 。

        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            return Math.Abs(MaxDepth(root.left) - MaxDepth(root.right)) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
        }
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
            bool result = IsBalanced(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
