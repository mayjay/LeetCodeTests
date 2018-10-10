using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0094InorderTraversal
    {
        //给定一个二叉树，返回它的中序 遍历。
        //示例:
        //输入: [1,null,2,3]
        //   1
        //    \
        //     2
        //    /
        //   3
        //输出: [1,3,2]
        //进阶: 递归算法很简单，你可以通过迭代算法完成吗？

        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            InorderTraversal(root, result);
            return result;
        }

        private void InorderTraversal(TreeNode root, List<int> result)
        {
            if (root != null)
            {
                if (root.left != null)
                    InorderTraversal(root.left, result);
                result.Add(root.val);
                if (root.right != null)
                    InorderTraversal(root.right, result);
            }
        }

        public void Test()
        {
            TreeNode root = new TreeNode(1);
            TreeNode node1 = new TreeNode(2);
            root.right = node1;
            TreeNode node2 = new TreeNode(3);
            node1.left = node2;
            IList<int> result = InorderTraversal(root);
            foreach (int e in result)
                Console.Write(e + " ");
            Console.ReadLine();
        }
    }
}
