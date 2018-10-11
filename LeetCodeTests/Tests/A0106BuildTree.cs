using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0106BuildTree
    {
        //根据一棵树的中序遍历与后序遍历构造二叉树。
        //注意:
        //你可以假设树中没有重复的元素。
        //例如，给出
        //中序遍历 inorder = [9,3,15,20,7]
        //后序遍历 postorder = [9,15,7,20,3]
        //返回如下的二叉树：
        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder == null || inorder.Length == 0) return null;
            return BuildTree(new List<int>(inorder), new List<int>(postorder));
        }

        private TreeNode BuildTree(List<int> inorder, List<int> postorder)
        {
            TreeNode root = new TreeNode(postorder.Last());
            int index = inorder.IndexOf(postorder.Last());
            //left tree
            if (index > 0)
            {
                List<int> leftInorder = inorder.GetRange(0, index);
                List<int> leftPostorder = postorder.GetRange(0, index);
                root.left = BuildTree(leftInorder, leftPostorder);
            }
            //right tree
            if (index < inorder.Count - 1)
            {
                List<int> rightInorder = inorder.GetRange(index + 1, inorder.Count - 1 - index);
                List<int> rightPostorder = postorder.GetRange(index, postorder.Count - 1 - index);
                root.right = BuildTree(rightInorder, rightPostorder);
            }
            return root;
        }

        public void Test()
        {
            int[] inorder = { 9, 3, 15, 20, 7 };
            int[] postorder = { 9, 15, 7, 20, 3 };
            TreeNode result = BuildTree(inorder, postorder);
            List<int> list = result.PreorderTraversal();
            foreach (int num in list)
                Console.Write(num + " ");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
