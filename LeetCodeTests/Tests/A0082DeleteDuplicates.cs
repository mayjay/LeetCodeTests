using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0082DeleteDuplicates
    {
        //给定一个排序链表，删除所有含有重复数字的节点，只保留原始链表中 没有重复出现 的数字。
        //示例 1:
        //输入: 1->2->3->3->4->4->5
        //输出: 1->2->5
        //示例 2:
        //输入: 1->1->1->2->3
        //输出: 2->3

        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode node = head;
            ListNode lastLeftNode = head;
            ListNode lastNode = null;
            bool deleteLastNode = false;
            while (node != null)
            {
                if (lastNode != null && node.val == lastNode.val)
                {
                    //remove current node
                    lastNode.next = node.next;
                    deleteLastNode = true;
                }
                else
                {
                    if (deleteLastNode)
                    {
                        //delete head
                        if (lastNode == head)
                            head = head.next;
                        else
                            lastLeftNode.next = node;
                        //reset
                        deleteLastNode = false;
                    }
                    if (lastLeftNode.next == lastNode)
                        lastLeftNode = lastNode;
                    lastNode = node;
                }
                node = node.next;
            }
            //check last
            if (deleteLastNode)
            {
                //delete head
                if (lastNode == head)
                    head = head.next;
                else
                    lastLeftNode.next = node;
            }
            return head;
        }

        public void Test()
        {
            int[] nums = { 1, 2, 2 };
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
