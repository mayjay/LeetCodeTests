using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0083DeleteDuplicates
    {
        //给定一个排序链表，删除所有重复的元素，使得每个元素只出现一次。
        //示例 1:
        //输入: 1->1->2
        //输出: 1->2
        //示例 2:
        //输入: 1->1->2->3->3
        //输出: 1->2->3

        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode node = head;
            ListNode lastNode = null;
            while (node != null)
            {
                if (lastNode != null && node.val == lastNode.val)
                {
                    //remove current node
                    lastNode.next = node.next;
                }
                else
                    lastNode = node;
                node = node.next;
            }
            return head;
        }

        public void Test()
        {
            int[] nums = { 1, 2, 3, 3, 4, 4, 5 };
            ListNode head = ListNode.GenerateList(nums);
            ListNode result = DeleteDuplicates(head);
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
