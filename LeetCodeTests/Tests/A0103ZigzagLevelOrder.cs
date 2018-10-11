using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0103ZigzagLevelOrder
    {
        //给定一个二叉树，返回其节点值的锯齿形层次遍历。（即先从左往右，再从右往左进行下一层遍历，以此类推，层与层之间交替进行）。
        //例如：
        //给定二叉树 [3,9,20,null,null,15,7],
        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7
        //返回锯齿形层次遍历如下：
        //[
        //  [3],
        //  [20,9],
        //  [15,7]
        //]

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<List<int>> result = new List<List<int>>();
            if (root == null) return result.ToArray();
            //use key to record level
            Queue<KeyValuePair<int, TreeNode>> queue = new Queue<KeyValuePair<int, TreeNode>>();
            queue.Enqueue(new KeyValuePair<int, TreeNode>(0, root));
            while (queue.Count > 0)
            {
                KeyValuePair<int, TreeNode> node = queue.Dequeue();
                //add node value
                if (result.Count <= node.Key)
                {
                    //if even level, revert last list first
                    if (result.Count > 0 && result.Count % 2 == 0)
                        result.Last().Reverse();
                    result.Add(new List<int>());
                }
                result.Last().Add(node.Value.val);
                //add left and right node to queue
                if (node.Value.left != null)
                    queue.Enqueue(new KeyValuePair<int, TreeNode>(node.Key + 1, node.Value.left));
                if (node.Value.right != null)
                    queue.Enqueue(new KeyValuePair<int, TreeNode>(node.Key + 1, node.Value.right));
            }
            //handle last level
            if (result.Count > 0 && result.Count % 2 == 0)
                result.Last().Reverse();
            return result.ToArray();
        }

        public void Test()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            TreeNode input = root;
            IList<IList<int>> result = ZigzagLevelOrder(input);
            foreach (IList<int> list in result)
            {
                foreach (int num in list)
                    Console.Write(num + " ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
