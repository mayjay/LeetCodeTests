using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0141HasCycle
    {
        //给定一个链表，判断链表中是否有环。
        //进阶：
        //你能否不使用额外空间解决此题？
        
        public bool HasCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast != null)
            {
                slow = slow.next;
                if (fast.next != null)
                    fast = fast.next.next;
                else
                    return false;
                if (slow == fast)
                    return true;
            }
            return false;
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
            bool result = HasCycle(head);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
