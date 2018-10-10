using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        public List<int> PreorderTraversal()
        {
            List<int> result = new List<int>();
            PreorderTraversal(result);
            return result;
        }

        private void PreorderTraversal(List<int> result)
        {
            result.Add(this.val);
            if (this.left != null)
                this.left.PreorderTraversal(result);
            if (this.right != null)
                this.right.PreorderTraversal(result);
        }

        public List<int> InorderTraversal()
        {
            List<int> result = new List<int>();
            InorderTraversal(result);
            return result;
        }

        private void InorderTraversal(List<int> result)
        {
            if (this.left != null)
                this.left.InorderTraversal(result);
            result.Add(this.val);
            if (this.right != null)
                this.right.InorderTraversal(result);
        }

        public List<int> PostorderTraversal()
        {
            List<int> result = new List<int>();
            PostorderTraversal(result);
            return result;
        }

        public void PostorderTraversal(List<int> result)
        {
            if (this.left != null)
                this.left.PostorderTraversal(result);
            if (this.right != null)
                this.right.PostorderTraversal(result);
            result.Add(this.val);
        }
    }
}
