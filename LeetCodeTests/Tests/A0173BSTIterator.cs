using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0173BSTIterator
    {
        //实现一个二叉搜索树迭代器。你将使用二叉搜索树的根节点初始化迭代器。
        //调用 next() 将返回二叉搜索树中的下一个最小的数。
        //示例：
        //BSTIterator iterator = new BSTIterator(root);
        //iterator.next();    // 返回 3
        //iterator.next();    // 返回 7
        //iterator.hasNext(); // 返回 true
        //iterator.next();    // 返回 9
        //iterator.hasNext(); // 返回 true
        //iterator.next();    // 返回 15
        //iterator.hasNext(); // 返回 true
        //iterator.next();    // 返回 20
        //iterator.hasNext(); // 返回 false
        //提示：
        //next() 和 hasNext() 操作的时间复杂度是 O(1)，并使用 O(h) 内存，其中 h 是树的高度。
        //你可以假设 next() 调用总是有效的，也就是说，当调用 next() 时，BST 中至少存在一个下一个最小的数。

        private List<int> orders;
        private int index;

        public A0173BSTIterator() { }

        public A0173BSTIterator(TreeNode root)
        {
            this.orders = new List<int>();
            this.index = -1;
            this.InorderTraversal(root);
        }
    
        /** @return the next smallest number */
        public int Next() 
        {
            index++;
            return orders[index];
        }
    
        /** @return whether we have a next smallest number */
        public bool HasNext() 
        {
            return index < orders.Count - 1;
        }

        private void InorderTraversal(TreeNode root)
        {
            if (root == null) return;
            if (root.left != null)
                InorderTraversal(root.left);
            this.orders.Add(root.val);
            if (root.right != null)
                InorderTraversal(root.right);
        }

        public void Test()
        {
            TreeNode root = new TreeNode(10);
            root.left = new TreeNode(5);
            root.right = new TreeNode(15);
            root.right.left = new TreeNode(12);
            root.right.right = new TreeNode(20);
            A0173BSTIterator obj = new A0173BSTIterator(root);
            int param_1 = obj.Next();
            bool param_2 = obj.HasNext();
            Console.WriteLine(param_1 + " " + param_2);
            Console.ReadLine();
        }
    }
}
