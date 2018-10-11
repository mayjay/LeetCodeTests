using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0105BuildTree
    {
        //根据一棵树的前序遍历与中序遍历构造二叉树。
        //注意:
        //你可以假设树中没有重复的元素。
        //例如，给出
        //前序遍历 preorder = [3,9,20,15,7]
        //中序遍历 inorder = [9,3,15,20,7]
        //返回如下的二叉树：
        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0) return null;
            return BuildTree(new List<int>(preorder), new List<int>(inorder));
        }

        private TreeNode BuildTree(List<int> preorder, List<int> inorder)
        {
            TreeNode root = new TreeNode(preorder[0]);
            int index = inorder.IndexOf(preorder[0]);
            //left tree
            if (index > 0)
            {
                List<int> leftPreorder = preorder.GetRange(1, index);
                List<int> leftInorder = inorder.GetRange(0, index);
                root.left = BuildTree(leftPreorder, leftInorder);
            }
            //right tree
            if (index < preorder.Count - 1)
            {
                List<int> rightPreorder = preorder.GetRange(index + 1, preorder.Count - 1 - index);
                List<int> rightInorder = inorder.GetRange(index + 1, inorder.Count - 1 - index);
                root.right = BuildTree(rightPreorder, rightInorder);
            }
            return root;
        }

        public void Test()
        {
            int[] preorder = { 3, 9, 20, 15, 7 };
            int[] inorder = { 9, 3, 15, 20, 7 };
            TreeNode result = BuildTree(preorder, inorder);
            if (result == null) return;
            List<int> list = result.PostorderTraversal();
            foreach (int num in list)
                Console.Write(num + " ");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
