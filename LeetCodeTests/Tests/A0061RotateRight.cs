using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0061RotateRight
    {
        //给定一个链表，旋转链表，将链表每个节点向右移动 k 个位置，其中 k 是非负数。
        //示例 1:
        //输入: 1->2->3->4->5->NULL, k = 2
        //输出: 4->5->1->2->3->NULL
        //解释:
        //向右旋转 1 步: 5->1->2->3->4->NULL
        //向右旋转 2 步: 4->5->1->2->3->NULL
        //示例 2:
        //输入: 0->1->2->NULL, k = 4
        //输出: 2->0->1->NULL
        //解释:
        //向右旋转 1 步: 2->0->1->NULL
        //向右旋转 2 步: 1->2->0->NULL
        //向右旋转 3 步: 0->1->2->NULL
        //向右旋转 4 步: 2->0->1->NULL

        public ListNode RotateRight(ListNode head, int k)
        {
            int length = 0;
            ListNode node = head;
            while (node != null)
            {
                length++;
                node = node.next;
            }
            if (length == 0) return head;
            k = k % length;
            if (k == 0) return head;
            ListNode result = head;
            node = head;
            ListNode tail = null;
            for (int i = 0; i < length; i++)
            {
                if (i == length - k - 1)
                {
                    tail = node;
                    result = tail.next;
                }
                else if (i == length - 1)
                    node.next = head;
                node = node.next;
            }
            //set tail.next out of cycle
            tail.next = null;
            return result;
        }

        public void Test()
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);
            ListNode head = node1;
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            int k = 2;
            ListNode result = RotateRight(head, k);
            ListNode node = result;
            while (node != null)
            {
                Console.Write(node.val + " ");
                node = node.next;
            }
            Console.ReadLine();
        }
    }
}
