using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0092ReverseBetween
    {
        //反转从位置 m 到 n 的链表。请使用一趟扫描完成反转。
        //说明:
        //1 ≤ m ≤ n ≤ 链表长度。
        //示例:
        //输入: 1->2->3->4->5->NULL, m = 2, n = 4
        //输出: 1->4->3->2->5->NULL

        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null || m >= n) return head;
            ListNode node = head;
            ListNode next = node.next;
            ListNode beforeFisrtNode = null;
            ListNode firstNode = null;
            ListNode lastNode = null;
            int count = 0;
            while (node != null)
            {
                count++;
                ListNode nextNext = next != null ? next.next: null;
                if (count < m)
                    beforeFisrtNode = node;
                else if (count >= m && count < n)
                {
                    next.next = node;
                    if (count == m)
                        firstNode = node;
                }
                else if (count == n)
                {
                    //before first node point to current node
                    if (beforeFisrtNode != null)
                        beforeFisrtNode.next = node;
                    else
                    {
                        //if before first node is null, means m = 1
                        head.next = node;
                        head = node;
                    }
                    //last node is the next node after ndoe n
                    lastNode = next;
                }
                //step next
                node = next;
                next = nextNext;
            }
            //first ndoe point to last node
            firstNode.next = lastNode;
            return head;
        }

        private ListNode Reverse(ListNode head)
        {
            if (head == null) return head;
            ListNode node = head;
            ListNode next = node.next;
            while (next != null)
            {
                ListNode nextNext = next.next;
                next.next = node;
                if (node == head)
                    node.next = null;
                //step next
                node = next;
                next = nextNext;
            }
            return node;
        }

        public void Test()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            ListNode head = ListNode.GenerateList(nums);
            int m = 1;
            int n = 1;
            ListNode result = ReverseBetween(head, m, n);
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
