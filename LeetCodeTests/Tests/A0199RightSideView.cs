using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0199RightSideView
    {
        //给定一棵二叉树，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。
        //示例:
        //输入: [1,2,3,null,5,null,4]
        //输出: [1, 3, 4]
        //解释:
        //   1            <---
        // /   \
        //2     3         <---
        // \     \
        //  5     4       <---

        public IList<int> RightSideView(TreeNode root)
        {
            List<List<int>> result = new List<List<int>>();
            if (root == null) return new List<int>();
            //use key to record level
            Queue<KeyValuePair<int, TreeNode>> queue = new Queue<KeyValuePair<int, TreeNode>>();
            queue.Enqueue(new KeyValuePair<int, TreeNode>(0, root));
            while (queue.Count > 0)
            {
                KeyValuePair<int, TreeNode> node = queue.Dequeue();
                //add node value
                if (result.Count <= node.Key)
                    result.Add(new List<int>());
                result.Last().Add(node.Value.val);
                //add left and right node to queue
                if (node.Value.left != null)
                    queue.Enqueue(new KeyValuePair<int, TreeNode>(node.Key + 1, node.Value.left));
                if (node.Value.right != null)
                    queue.Enqueue(new KeyValuePair<int, TreeNode>(node.Key + 1, node.Value.right));
            }
            List<int> view = new List<int>();
            foreach (List<int> list in result)
                view.Add(list.Last());
            return view;
        }

        public void Test()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.right = new TreeNode(5);
            root.right = new TreeNode(3);
            root.right.right = new TreeNode(4);
            IList<int> result = RightSideView(root);
            foreach (int s in result)
                Console.Write(s + " ");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
