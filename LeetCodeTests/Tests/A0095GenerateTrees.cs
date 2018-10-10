using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0095GenerateTrees
    {
        //给定一个整数 n，生成所有由 1 ... n 为节点所组成的二叉搜索树。
        //示例:
        //输入: 3
        //输出:
        //[
        //  [1,null,3,2],
        //  [3,2,null,1],
        //  [3,1,null,null,2],
        //  [2,1,3],
        //  [1,null,2,null,3]
        //]
        //解释:
        //以上的输出对应以下 5 种不同结构的二叉搜索树：
        //   1         3     3      2      1
        //    \       /     /      / \      \
        //     3     2     1      1   3      2
        //    /     /       \                 \
        //   2     1         2                 3

        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n <= 0) return new List<TreeNode>();
            return GenerateTree(1, n);
        }

        private IList<TreeNode> GenerateTree(int start, int end)
        {
            List<TreeNode> result = new List<TreeNode>();
            if (start > end)
                result.Add(null);
            else
                for (int i = start; i <= end; i++)
                {
                    IList<TreeNode> left = GenerateTree(start, i - 1);
                    IList<TreeNode> right = GenerateTree(i + 1, end);
                    for (int j = 0; j < left.Count; j++)
                        for (int k = 0; k < right.Count; k++)
                        {
                            TreeNode root = new TreeNode(i);
                            root.left = left[j];
                            root.right = right[k];
                            result.Add(root);
                        }
                }
            return result;
        }

        public void Test()
        {
            int input = 0;
            IList<TreeNode> result = GenerateTrees(input);
            foreach (TreeNode e in result)
            {
                List<int> list = e.PreorderTraversal();
                foreach (int num in list)
                    Console.Write(num + " ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
