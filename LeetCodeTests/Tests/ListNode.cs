using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x) { val = x; }

        public static ListNode GenerateList(int[] input)
        {
            ListNode head = null;
            ListNode nextNode = null;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                ListNode node = new ListNode(input[i]);
                if (i == input.Length - 1) node.next = null;
                else node.next = nextNode;
                nextNode = node;
                if (i == 0) head = node;
            }
            return head;
        }
    }
}
