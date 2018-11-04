using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0148SortList
    {
        //在 O(n log n) 时间复杂度和常数级空间复杂度下，对链表进行排序。
        //示例 1:
        //输入: 4->2->1->3
        //输出: 1->2->3->4
        //示例 2:
        //输入: -1->5->3->4->0
        //输出: -1->0->3->4->5

        public ListNode SortList(ListNode head)
        {
            //if less than 2 elements
            if (head == null || head.next == null)
                return head;
            if (head.next.next == null)
            {
                ListNode next = head.next;
                if (head.val <= next.val)
                    return head;
                else
                {
                    head.next = null;
                    next.next = head;
                    return next;
                }
            }
            ListNode fast = head;
            ListNode slow = head;
            ListNode last = head;
            while (fast != null)
            {
                if (fast.next != null)
                    fast = fast.next.next;
                else
                    break;
                last = slow;
                slow = slow.next;
            }
            //cut tail
            last.next = null;
            ListNode middle = slow;
            ListNode head1 = SortList(head);
            ListNode head2 = SortList(middle);
            return Merge(head1, head2);
        }

        private ListNode Merge(ListNode head1, ListNode head2)
        {
            if (head1 == null) return head2;
            if (head2 == null) return head1;
            ListNode head = null;
            ListNode node = null;
            ListNode node1 = head1;
            ListNode node2 = head2;
            while (node1 != null || node2 != null)
            {
                if (node1 == null || (node1 != null && node2 != null && node1.val > node2.val))
                {
                    if (node == null)
                        node = node2;
                    else
                        node.next = node2;
                    //remove next
                    ListNode tmp = node2;
                    node2 = node2.next;
                    tmp.next = null;
                }
                else if (node2 == null || (node1 != null && node2 != null && node1.val <= node2.val))
                {
                    if (node == null)
                        node = node1;
                    else
                        node.next = node1;
                    //remove next
                    ListNode tmp = node1;
                    node1 = node1.next;
                    tmp.next = null;
                }
                if (head == null)
                    head = node;
                if (node.next != null)
                    node = node.next;
            }
            return head;
        }

        public void Test()
        {
            ListNode node1 = new ListNode(-1);
            ListNode node2 = new ListNode(5);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(0);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            ListNode head = node1;
            ListNode result = SortList(head);
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
