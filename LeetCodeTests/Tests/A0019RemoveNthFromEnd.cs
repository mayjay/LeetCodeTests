using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0019RemoveNthFromEnd
    {
        //给定一个链表，删除链表的倒数第 n 个节点，并且返回链表的头结点。
        //示例：
        //给定一个链表: 1->2->3->4->5, 和 n = 2.
        //当删除了倒数第二个节点后，链表变为 1->2->3->5.
        //说明：
        //给定的 n 保证是有效的。
        //进阶：
        //你能尝试使用一趟扫描实现吗？

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (n <= 0) return null;
            List<ListNode> nodeList = new List<ListNode>();
            ListNode node = head;
            do
            {
                nodeList.Add(node);
                node = node.next;
            } while (node != null);

            if (nodeList.Count() < n) return null;
            //delete first node, that is head
            if (nodeList.Count() == n)
            {
                node = head.next;
                head.next = null;
                return node;
            }
            //other conditions
            int offset = nodeList.Count() - n;
            node = nodeList[offset - 1];
            node.next = node.next.next;
            return head;
        }

        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            if (n <= 0) return null;
            ListNode node = head;
            int count = 0;
            do
            {
                count++;
                node = node.next;
            } while (node != null);

            if (count < n) return null;
            //delete first node, that is head
            if (count == n)
            {
                node = head.next;
                head.next = null;
                return node;
            }
            //other conditions
            int offset = count - n;
            node = head;
            for (int i = 0; i < offset - 1; i++)
            {
                node = node.next;
            }
            node.next = node.next.next;
            return head;
        }


        public void Test()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            ListNode head = ListNode.GenerateList(nums);
            int n = 2;
            ListNode result = RemoveNthFromEnd(head, n);
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
