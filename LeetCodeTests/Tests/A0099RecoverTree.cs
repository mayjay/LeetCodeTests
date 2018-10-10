using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0099RecoverTree
    {
        //二叉搜索树中的两个节点被错误地交换。
        //请在不改变其结构的情况下，恢复这棵树。
        //示例 1:
        //输入: [1,3,null,null,2]
        //   1
        //  /
        // 3
        //  \
        //   2
        //输出: [3,1,null,null,2]
        //   3
        //  /
        // 1
        //  \
        //   2
        //示例 2:
        //输入: [3,1,4,null,null,2]
        //  3
        // / \
        //1   4
        //   /
        //  2
        //输出: [2,1,4,null,null,3]
        //  2
        // / \
        //1   4
        //   /
        //  3
        //进阶:
        //使用 O(n) 空间复杂度的解法很容易实现。
        //你能想出一个只使用常数空间的解决方案吗？

        public void RecoverTree(TreeNode root)
        {
            if (root == null) return;
            List<TreeNode> order = InorderTraversal(root);
            TreeNode[] mistakes = new TreeNode[2];
            int index = 0;
            for (int i = 0; i < order.Count; i++)
            {
                if (i > 0 && order[i].val <= order[i - 1].val)
                {
                    if (index == 0)
                    {
                        mistakes[0] = order[i - 1];
                        mistakes[1] = order[i];
                        index++;
                    }
                    else
                        mistakes[1] = order[i];
                }
            }
            //swap
            int swap = mistakes[0].val;
            mistakes[0].val = mistakes[1].val;
            mistakes[1].val = swap;
        }

        private List<TreeNode> InorderTraversal(TreeNode root)
        {
            List<TreeNode> order = new List<TreeNode>();
            InorderTraversal(root, order);
            return order;
        }

        private void InorderTraversal(TreeNode root, List<TreeNode> order)
        {
            if (root != null)
            {
                InorderTraversal(root.left, order);
                order.Add(root);
                InorderTraversal(root.right, order);
            }
        }

        public void Test()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(3);
            root.left.right = new TreeNode(2);
            TreeNode input = root;
            List<int> list = root.InorderTraversal();
            foreach (int e in list)
                Console.Write(e + " ");
            Console.WriteLine();
            RecoverTree(input);
            list = root.InorderTraversal();
            foreach (int e in list)
                Console.Write(e + " ");
            Console.ReadLine();
        }
    }
}
