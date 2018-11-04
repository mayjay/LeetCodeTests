using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0142DetectCycle
    {
        //给定一个链表，返回链表开始入环的第一个节点。 如果链表无环，则返回 null。
        //说明：不允许修改给定的链表。
        //进阶：
        //你是否可以不用额外空间解决此题？

        public ListNode DetectCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            bool hasCycle = false;
            while (fast != null)
            {
                slow = slow.next;
                if (fast.next != null)
                    fast = fast.next.next;
                else
                    return null;
                if (slow == fast)
                {
                    hasCycle = true;
                    break;
                }
            }
            if (!hasCycle)
                return null;
            ListNode node = head;
            while (node != null)
            {
                if (node == slow)
                    return node;
                node = node.next;
                slow = slow.next;
            }
            return null;
        }

        public void Test()
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node2;
            ListNode head = node1;
            ListNode result = DetectCycle(head);
            Console.WriteLine(result != null ? "" + result.val : "null");
            Console.ReadLine();
        }
    }
}
