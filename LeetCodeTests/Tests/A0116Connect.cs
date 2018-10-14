﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0116Connect
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
        //你可以假设它是一个完美二叉树（即所有叶子节点都在同一层，每个父节点都有两个子节点）。
        //示例:
        //给定完美二叉树，
        //     1
        //   /  \
        //  2    3
        // / \  / \
        //4  5  6  7
        //调用你的函数后，该完美二叉树变为：
        //     1 -> NULL
        //   /  \
        //  2 -> 3 -> NULL
        // / \  / \
        //4->5->6->7 -> NULL

        public void Connect(TreeLinkNode root)
        {
            if (root == null)
                return;
            if (root.left != null)
                root.left.next = root.right;
            if (root.right != null && root.next != null)
                root.right.next = root.next.left;
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
            root.right.left = new TreeLinkNode(6);
            root.right.right = new TreeLinkNode(7);
            TreeLinkNode input = root;
            Connect(input);
            Console.ReadLine();
        }
    }
}
