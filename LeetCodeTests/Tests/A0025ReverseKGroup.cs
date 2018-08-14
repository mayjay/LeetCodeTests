using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0025ReverseKGroup
    {
        //给出一个链表，每 k 个节点一组进行翻转，并返回翻转后的链表。
        //k 是一个正整数，它的值小于或等于链表的长度。如果节点总数不是 k 的整数倍，那么将最后剩余节点保持原有顺序。
        //示例 :
        //给定这个链表：1->2->3->4->5
        //当 k = 2 时，应当返回: 2->1->4->3->5
        //当 k = 3 时，应当返回: 3->2->1->4->5
        //说明 :
        //你的算法只能使用常数的额外空间。
        //你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            //record new head
            ListNode headNode = head;
            for (int i = 0; i < k - 1; i++)
            {
                if (headNode == null || headNode.next == null) return head;
                headNode = headNode.next;
            }
            if (head != null) ReverseRecurse(null, head, k);
            return headNode;
        }

        private void ReverseRecurse(ListNode pre, ListNode head, int k)
        {
            //check if can reverse
            ListNode node = head;
            List<ListNode> nodeList = new List<ListNode>(k);
            nodeList.Add(head);
            for (int i = 0; i < k - 1; i++)
            {
                if (node == null || node.next == null) return;
                node = node.next;
                if (node != null) nodeList.Add(node);
            }
            //reverse node list
            nodeList[0].next = nodeList[nodeList.Count - 1].next;
            for (int i = nodeList.Count - 1; i > 0; i--)
            {
                if (i == nodeList.Count - 1 && pre != null) pre.next = nodeList[i];
                nodeList[i].next = nodeList[i - 1];
            }
            if (nodeList[0].next != null)
            {
                ReverseRecurse(nodeList[0], nodeList[0].next, k);
            }
        }

        public void Test()
        {
            int[] input = { 1, 2, 3, 4, 5 };
            ListNode head = ListNode.GenerateList(input);
            int k = 3;
            ListNode result = ReverseKGroup(head, k);
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
