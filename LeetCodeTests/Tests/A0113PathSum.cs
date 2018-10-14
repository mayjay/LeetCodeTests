using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0113PathSum
    {
        //给定一个二叉树和一个目标和，找到所有从根节点到叶子节点路径总和等于给定目标和的路径。
        //说明: 叶子节点是指没有子节点的节点。
        //示例:
        //给定如下二叉树，以及目标和 sum = 22，
        //              5
        //             / \
        //            4   8
        //           /   / \
        //          11  13  4
        //         /  \    / \
        //        7    2  5   1
        //返回:

        //[
        //   [5,4,11,2],
        //   [5,8,4,5]
        //]

        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            List<List<int>> result = new List<List<int>>();
            PathSum(root, sum, result, new List<int>());
            return result.ToArray();
        }

        public void PathSum(TreeNode root, int sum, List<List<int>> result, List<int> candidate)
        {
            if (root == null) return;
            if (root.val == sum && root.left == null && root.right == null)
            {
                //find one
                candidate.Add(root.val);
                result.Add(candidate);
            }
            else
            {
                candidate.Add(root.val);
                PathSum(root.left, sum - root.val, result, new List<int>(candidate));
                PathSum(root.right, sum - root.val, result, new List<int>(candidate));
            }
        }

        public void Test()
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(4);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(11);
            root.right.left = new TreeNode(13);
            root.right.right = new TreeNode(4);
            root.left.left.left = new TreeNode(7);
            root.left.left.right = new TreeNode(2);
            root.right.right.left = new TreeNode(5);
            root.right.right.right = new TreeNode(1);
            int sum = 22;
            IList<IList<int>> result = PathSum(root, sum);
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
