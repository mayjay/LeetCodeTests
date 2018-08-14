using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LeetCodeTests.Tests
{
    class A0002AddTwoNumbers
    {
        //给定两个非空链表来表示两个非负整数。位数按照逆序方式存储，它们的每个节点只存储单个数字。将两数相加返回一个新的链表。
        //你可以假设除了数字 0 之外，这两个数字都不会以零开头。
        //示例：
        //输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
        //输出：7 -> 0 -> 8
        //原因：342 + 465 = 807

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            int carryBit = 0;
            ListNode add1 = l1;
            ListNode add2 = l2;
            ListNode sum = result;
            while (true)
            {
                int sumVal = ((add1 != null) ? add1.val : 0) + ((add2 != null) ? add2.val : 0) + carryBit;
                //calculate val and carryBit
                sum.val = sumVal % 10;
                carryBit = sumVal / 10;
                //if carryBit not 0, should still add next node
                if ((add1 != null && add1.next != null) || (add2 != null && add2.next != null) || carryBit != 0)
                {
                    add1 = add1 != null ? add1.next : null;
                    add2 = add2 != null ? add2.next : null;
                    ListNode next = new ListNode(0);
                    sum.next = next;
                    sum = next;
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        private ListNode Convert(int input)
        {
            ListNode result = new ListNode(0);
            ListNode current = result;
            int bit = 0;
            while (true)
            {
                current.val = (input / (int)Math.Pow(10, bit)) % 10;
                bit += 1;
                if (input / (int)Math.Pow(10, bit) > 0)
                {
                    ListNode next = new ListNode(0);
                    current.next = next;
                    current = next;
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        public void Test()
        {
            int add1 = 342;
            int add2 = 465;
            ListNode result = AddTwoNumbers(Convert(add1), Convert(add2));
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
