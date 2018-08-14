using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0021MergeTwoLists
    {
        //将两个有序链表合并为一个新的有序链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 
        //示例：
        //输入：1->2->4, 1->3->4
        //输出：1->1->2->3->4->4

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode node1 = l1, node2 = l2;
            ListNode newList = null, nextNode = null;
            bool start = false;
            while (node1 != null || node2 != null)
            {
                ListNode newNode;
                if (node1 == null)
                {
                    newNode = new ListNode(node2.val);
                    node2 = node2.next;
                }
                else if (node2 == null)
                {
                    newNode = new ListNode(node1.val);
                    node1 = node1.next;
                }
                else if (node1.val <= node2.val)
                {
                    newNode = new ListNode(node1.val);
                    node1 = node1.next;
                }
                else
                {
                    newNode = new ListNode(node2.val);
                    node2 = node2.next;
                }
                //update new list
                if (!start)
                {
                    start = true;
                    newList = newNode;
                    nextNode = newList;
                }
                else
                {
                    nextNode.next = newNode;
                    nextNode = nextNode.next;
                }
            }
            return newList;
        }

        public void Test()
        {
            int[] nums1 = { 1, 2, 4 };
            int[] nums2 = { 1, 3, 4 };
            ListNode l1 = ListNode.GenerateList(nums1);
            ListNode l2 = ListNode.GenerateList(nums2);
            ListNode result = MergeTwoLists(l1, l2);
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
