using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0024SwapPairs
    {
        //给定一个链表，两两交换其中相邻的节点，并返回交换后的链表。
        //示例:
        //给定 1->2->3->4, 你应该返回 2->1->4->3.
        //说明:
        //你的算法只能使用常数的额外空间。
        //你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;
            //record new head
            ListNode headNode = head.next;
            SwapRecurse(null, head);
            return headNode;
        }

        private void SwapRecurse(ListNode pre, ListNode head)
        {
            if (head == null || head.next == null) return;
            ListNode node1 = head;
            ListNode node2 = head.next;
            if (pre != null) pre.next = node2;
            node1.next = node2.next;
            node2.next = node1;
            head = node2;
            if (node1.next != null)
            {
                SwapRecurse(node1, node1.next);
            }
        }

        public void Test()
        {
            int[] input = { 1, 2, 3, 4 };
            ListNode head = ListNode.GenerateList(input);
            ListNode result = SwapPairs(head);
            ListNode output = result;
            while (output != null)
            {
                Console.Write(output.val + " ");
                output = output.next;
            }
            Console.ReadLine();
        }
    }
}
