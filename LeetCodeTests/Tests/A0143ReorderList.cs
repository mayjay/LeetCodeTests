using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0143ReorderList
    {
        //给定一个单链表 L：L0→L1→…→Ln-1→Ln ，
        //将其重新排列后变为： L0→Ln→L1→Ln-1→L2→Ln-2→…
        //你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。
        //示例 1:
        //给定链表 1->2->3->4, 重新排列为 1->4->2->3.
        //示例 2:
        //给定链表 1->2->3->4->5, 重新排列为 1->5->2->4->3.

        public void ReorderList(ListNode head)
        {
            ListNode node = head;
            List<ListNode> list = new List<ListNode>();
            while (node != null)
            {
                list.Add(node);
                node = node.next;
            }
            int i = 0, j = list.Count - 1;
            while (i < j - 1)
            {
                ListNode tmp = list[i].next;
                list[i].next = list[j];
                list[j].next = tmp;
                //clear next of last node
                list[j - 1].next = null;
                i++;
                j--;
            }
        }

        public void Test()
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            ListNode head = node1;
            ReorderList(head);
            ListNode node = head;
            while (node != null)
            {
                Console.Write(node.val + " ");
                node = node.next;
            }
            Console.ReadLine();
        }

    }
}
