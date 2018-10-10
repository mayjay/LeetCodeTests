using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0098IsValidBST
    {
        //给定一个二叉树，判断其是否是一个有效的二叉搜索树。
        //假设一个二叉搜索树具有如下特征：
        //节点的左子树只包含小于当前节点的数。
        //节点的右子树只包含大于当前节点的数。
        //所有左子树和右子树自身必须也是二叉搜索树。
        //示例 1:
        //输入:
        //    2
        //   / \
        //  1   3
        //输出: true
        //示例 2:
        //输入:
        //    5
        //   / \
        //  1   4
        //     / \
        //    3   6
        //输出: false
        //解释: 输入为: [5,1,4,null,null,3,6]。
        //     根节点的值为 5 ，但是其右子节点值为 4 。

        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, long.MinValue, long.MaxValue);
        }

        private bool IsValidBST(TreeNode root, long min, long max)
        {
            if (root == null)
                return true;
            if (root.val <= min || root.val >= max)
                return false;
            return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
        }
        
        public bool IsValidBST2(TreeNode root)
        {
            if (root == null)
                return true;
            List<int> order = root.InorderTraversal();
            for (int i = 0; i < order.Count; i++)
                if (i > 0 && order[i] <= order[i - 1])
                    return false;
            return true;
        }

        public void Test()
        {
            TreeNode root = new TreeNode(10);
            root.left = new TreeNode(5);
            root.right = new TreeNode(15);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(20);
            TreeNode input = root;
            bool result = IsValidBST(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
