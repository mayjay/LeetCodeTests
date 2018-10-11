using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0108SortedArrayToBST
    {
        //将一个按照升序排列的有序数组，转换为一棵高度平衡二叉搜索树。
        //本题中，一个高度平衡二叉树是指一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1。
        //示例:
        //给定有序数组: [-10,-3,0,5,9],
        //一个可能的答案是：[0,-3,9,-10,null,5]，它可以表示下面这个高度平衡二叉搜索树：
        //      0
        //     / \
        //   -3   9
        //   /   /
        // -10  5

        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null) return null;
            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        private TreeNode SortedArrayToBST(int[] nums, int start, int end)
        {
            if (start > end) return null;
            int mid = (end + start) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            if (mid - start > 0)
                root.left = SortedArrayToBST(nums, start, mid - 1);
            if (end - mid > 0)
                root.right = SortedArrayToBST(nums, mid + 1, end);
            return root;
        }

        public void Test()
        {
            int[] input = { -10, -3, 0, 5, 9 };
            TreeNode result = SortedArrayToBST(input);
            List<int> list = result.PreorderTraversal();
            foreach (int num in list)
                Console.Write(num + " ");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
