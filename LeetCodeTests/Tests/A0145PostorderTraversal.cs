using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0145PostorderTraversal
    {
        //给定一个二叉树，返回它的 后序 遍历。
        //示例:
        //输入: [1,null,2,3]  
        //   1
        //    \
        //     2
        //    /
        //   3 
        //输出: [3,2,1]
        //进阶: 递归算法很简单，你可以通过迭代算法完成吗？

        public IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();
            if (root == null) return result;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode last = root;
            while (stack.Count > 0)
            {
                TreeNode node = stack.Peek();
                if ((node.left == null && node.right == null) || (node.right == null && node.left == last) || (node.right == last))
                {
                    //visit
                    result.Add(node.val);
                    last = node;
                    stack.Pop();
                }
                else
                {
                    if (node.right != null)
                        stack.Push(node.right);
                    if (node.left != null)
                        stack.Push(node.left);
                }
            }
            return result;
        }

        public void Test()
        {
            TreeNode root = new TreeNode(1);
            TreeNode node1 = new TreeNode(2);
            root.right = node1;
            TreeNode node2 = new TreeNode(3);
            node1.left = node2;
            IList<int> result = PostorderTraversal(root);
            foreach (int e in result)
                Console.Write(e + " ");
            Console.ReadLine();
        }
    }
}
