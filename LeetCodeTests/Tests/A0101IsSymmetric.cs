using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0101IsSymmetric
    {
        //给定一个二叉树，检查它是否是镜像对称的。
        //例如，二叉树 [1,2,2,3,4,4,3] 是对称的。
        //    1
        //   / \
        //  2   2
        // / \ / \
        //3  4 4  3
        //但是下面这个 [1,2,2,null,3,null,3] 则不是镜像对称的:
        //    1
        //   / \
        //  2   2
        //   \   \
        //   3    3
        //说明:
        //如果你可以运用递归和迭代两种方法解决这个问题，会很加分。

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return IsSymmetric(root.left, root.right);
        }

        private bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
                return true;
            if (left == null && right != null)
                return false;
            if (left != null && right == null)
                return false;
            if (left.val != right.val)
                return false;
            return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
        }

        public void Test()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(3);
            TreeNode input = root;
            bool result = IsSymmetric(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
