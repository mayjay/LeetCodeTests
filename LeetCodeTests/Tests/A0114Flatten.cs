using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0114Flatten
    {
        //给定一个二叉树，原地将它展开为链表。
        //例如，给定二叉树
        //    1
        //   / \
        //  2   5
        // / \   \
        //3   4   6
        //将其展开为：
        //1
        // \
        //  2
        //   \
        //    3
        //     \
        //      4
        //       \
        //        5
        //         \
        //          6

        public void Flatten(TreeNode root)
        {
            if (root == null) return;
            List<TreeNode> list = Traversal(root);
            TreeNode node = null;
            foreach (TreeNode e in list)
            {
                if (node == null) 
                    node = e;
                else
                {
                    node.left = null;
                    node.right = e;
                    node = node.right;
                }
            }
        }

        private List<TreeNode> Traversal(TreeNode root)
        {
            List<TreeNode> list = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                list.Add(node);
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
            }
            return list;
        }

        public void Test()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(5);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.right.right = new TreeNode(6);
            TreeNode input = root;
            Flatten(input);
            if (input == null) return;
            List<int> list = input.PostorderTraversal();
            foreach (int num in list)
                Console.Write(num + " ");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
