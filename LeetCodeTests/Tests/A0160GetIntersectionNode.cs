using System;
namespace LeetCodeTests.Tests
{
    public class A0160GetIntersectionNode
    {
        //编写一个程序，找到两个单链表相交的起始节点。
        //例如，下面的两个链表：
        //A:          a1 → a2
        //                   ↘
        //                     c1 → c2 → c3
        //                   ↗            
        //B:     b1 → b2 → b3
        //在节点 c1 开始相交。
        //注意：
        //如果两个链表没有交点，返回 null.
        //在返回结果后，两个链表仍须保持原有的结构。
        //可假定整个链表结构中没有循环。
        //程序尽量满足 O(n) 时间复杂度，且仅用 O(1) 内存。

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            int lengthA = 0;
            ListNode nodeA = headA;
            while (nodeA != null)
            {
                lengthA++;
                nodeA = nodeA.next;
            }
            int lengthB = 0;
            ListNode nodeB = headB;
            while (nodeB != null)
            {
                lengthB++;
                nodeB = nodeB.next;
            }
            int distance = Math.Abs(lengthA - lengthB);
            nodeA = headA;
            nodeB = headB;
            if (lengthA > lengthB)
                for (int i = 0; i < distance; i++)
                    nodeA = nodeA.next;
            else
                for (int i = 0; i < distance; i++)
                    nodeB = nodeB.next;
            while (nodeA != null && nodeB != null)
            {
                if (nodeA == nodeB)
                    return nodeA;
                else
                {
                    nodeA = nodeA.next;
                    nodeB = nodeB.next;
                }
            }
            return null;
        }
    
        public void Test()
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(4);
            ListNode node5 = new ListNode(5);
            ListNode node6 = new ListNode(6);
            ListNode node7 = new ListNode(7);
            ListNode node8 = new ListNode(8);
            node1.next = node2;
            node2.next = node6;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            node7.next = node8;
            ListNode headA = node1;
            ListNode headB = node3;
            ListNode result = GetIntersectionNode(headA, headB);
            Console.WriteLine(result != null ? "" + result.val : "null");
            Console.ReadLine();
        }
    }
}
