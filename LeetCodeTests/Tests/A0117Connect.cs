using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0117Connect
    {
        //给定一个二叉树
        //struct TreeLinkNode {
        //  TreeLinkNode *left;
        //  TreeLinkNode *right;
        //  TreeLinkNode *next;
        //}
        //填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。
        //初始状态下，所有 next 指针都被设置为 NULL。
        //说明:
        //你只能使用额外常数空间。
        //使用递归解题也符合要求，本题中递归程序占用的栈空间不算做额外的空间复杂度。
        //示例:
        //给定二叉树，
        //     1
        //   /  \
        //  2    3
        // / \    \
        //4   5    7
        //调用你的函数后，该二叉树变为：
        //     1 -> NULL
        //   /  \
        //  2 -> 3 -> NULL
        // / \    \
        //4-> 5 -> 7 -> NULL

        public void Connect(TreeLinkNode root)
        {
            if (root == null)
                return;
            if (root.left != null)
            {
                if (root.left.next != null) 
                    return;
                if (root.right != null)
                    root.left.next = root.right;
                else 
                {
                    TreeLinkNode node = root.next;
                    while (node != null)
                    {
                        if (node.left != null)
                        {
                            root.left.next = node.left;
                            break;
                        }
                        else if (node.right != null)
                        {
                            root.left.next = node.right;
                            break;
                        }
                        else
                            node = node.next;
                    }
                }
            }
            if (root.right != null)
            {
                if (root.right.next != null)
                    return;
                TreeLinkNode node = root.next;
                while (node != null)
                {
                    if (node.left != null)
                    {
                        root.right.next = node.left;
                        break;
                    }
                    else if (node.right != null)
                    {
                        root.right.next = node.right;
                        break;
                    }
                    else
                        node = node.next;
                }
            }
            //connect next to avoid order problem
            Connect(root.next);
            Connect(root.left);
            Connect(root.right);
        }

        public void Test()
        {
            TreeLinkNode root = new TreeLinkNode(1);
            root.left = new TreeLinkNode(2);
            root.right = new TreeLinkNode(3);
            root.left.left = new TreeLinkNode(4);
            root.left.right = new TreeLinkNode(5);
            root.right.right = new TreeLinkNode(7);
            TreeLinkNode input = root;
            Connect(input);
            Console.ReadLine();
        }
    }
}
