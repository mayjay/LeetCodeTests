using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0023MergeKLists
    {
        //合并 k 个排序链表，返回合并后的排序链表。请分析和描述算法的复杂度。
        //示例:
        //输入:
        //[
        //  1->4->5,
        //  1->3->4,
        //  2->6
        //]
        //输出: 1->1->2->3->4->4->5->6

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0) return null;
            List<ListNode> container = new List<ListNode>(lists);
            List<ListNode> mergedList = new List<ListNode>();
            while (container.Count > 1)
            {
                for (int i = 0; i < container.Count; i += 2)
                {
                    ListNode mergedNode;
                    if (i == container.Count - 1) mergedNode = container[i];
                    else mergedNode = MergeTwoLists(container[i], container[i + 1]);
                    mergedList.Add(mergedNode);
                    //last loop
                    if (i >= container.Count - 2)
                    {
                        //update
                        container = mergedList;
                        mergedList = new List<ListNode>();
                        break;
                    }
                }
            }
            return container[0];
        }

        private ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            return new A0021MergeTwoLists().MergeTwoLists(l1, l2);
        }

        public void Test()
        {
            int[] nums1 = { 1, 4, 5 };
            int[] nums2 = { 1, 3, 4 };
            int[] nums3 = { 2, 6 };
            ListNode l1 = ListNode.GenerateList(nums1);
            ListNode l2 = ListNode.GenerateList(nums2);
            ListNode l3 = ListNode.GenerateList(nums3);
            ListNode[] input = { l1, l2, l3 };
            ListNode result = MergeKLists(input);
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
