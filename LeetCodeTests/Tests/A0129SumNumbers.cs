using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0129SumNumbers
    {
        //给定一个二叉树，它的每个结点都存放一个 0-9 的数字，每条从根到叶子节点的路径都代表一个数字。

        //例如，从根到叶子节点路径 1->2->3 代表数字 123。

        //计算从根到叶子节点生成的所有数字之和。

        //说明: 叶子节点是指没有子节点的节点。

        //示例 1:

        //输入: [1,2,3]
        //    1
        //   / \
        //  2   3
        //输出: 25
        //解释:
        //从根到叶子节点路径 1->2 代表数字 12.
        //从根到叶子节点路径 1->3 代表数字 13.
        //因此，数字总和 = 12 + 13 = 25.
        //示例 2:

        //输入: [4,9,0,5,1]
        //    4
        //   / \
        //  9   0
        // / \
        //5   1
        //输出: 1026
        //解释:
        //从根到叶子节点路径 4->9->5 代表数字 495.
        //从根到叶子节点路径 4->9->1 代表数字 491.
        //从根到叶子节点路径 4->0 代表数字 40.
        //因此，数字总和 = 495 + 491 + 40 = 1026.

        public int SumNumbers(TreeNode root)
        {
            List<List<int>> paths = new List<List<int>>();
            FindAllPaths(root, new List<int>(), paths);
            int result = 0;
            foreach (List<int> path in paths)
            {
                int pathNum = 0;
                for (int i = 0; i < path.Count; i++)
                {
                    pathNum += path[i] * (int)Math.Pow(10, path.Count - 1 - i);
                }
                result += pathNum;
            }
            return result;
        }

        private void FindAllPaths(TreeNode node, List<int> candidate, List<List<int>> paths)
        {
            if (node == null) return;
            if (node.left == null && node.right == null)
            {
                candidate.Add(node.val);
                paths.Add(candidate);
                return;
            }
            if (node.left != null)
            {
                List<int> leftCandidate = new List<int>(candidate);
                leftCandidate.Add(node.val);
                FindAllPaths(node.left, leftCandidate, paths);
            }
            if (node.right != null)
            {
                List<int> rightCandidate = new List<int>(candidate);
                rightCandidate.Add(node.val);
                FindAllPaths(node.right, rightCandidate, paths);
            }
        }

        public void Test()
        {
            TreeNode root = new TreeNode(4);
            root.left = new TreeNode(9);
            root.right = new TreeNode(0);
            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(1);
            TreeNode input = root;
            int result = SumNumbers(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
