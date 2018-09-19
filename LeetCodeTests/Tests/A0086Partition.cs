using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0086Partition
    {
        //给定一个链表和一个特定值 x，对链表进行分隔，使得所有小于 x 的节点都在大于或等于 x 的节点之前。
        //你应当保留两个分区中每个节点的初始相对位置。
        //示例:
        //输入: head = 1->4->3->2->5->2, x = 3
        //输出: 1->2->2->4->3->5

        public ListNode Partition(ListNode head, int x)
        {
            ListNode leftHead = null;
            ListNode leftNode = null;
            ListNode rightHead = null;
            ListNode rightNode = null;
            ListNode node = head;
            while (node != null)
            {
                if (node.val < x)
                {
                    if (leftHead == null)
                    {
                        leftHead = new ListNode(node.val);
                        leftNode = leftHead;
                    }
                    else
                    {
                        ListNode newNode = new ListNode(node.val);
                        leftNode.next = newNode;
                        leftNode = newNode;
                    }
                }
                else
                {
                    if (rightHead == null)
                    {
                        rightHead = new ListNode(node.val);
                        rightNode = rightHead;
                    }
                    else
                    {
                        ListNode newNode = new ListNode(node.val);
                        rightNode.next = newNode;
                        rightNode = newNode;
                    }
                }
                node = node.next;
            }
            //combine left and right
            if (leftNode != null)
                leftNode.next = rightHead;
            else
                leftHead = rightHead;
            return leftHead;
        }

        public void Test()
        {
            //int[] nums = { 1, 4, 3, 2, 5, 2 };
            int[] nums = { 1 };
            ListNode head = ListNode.GenerateList(nums);
            int x = 0;
            ListNode result = Partition(head, x);
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
