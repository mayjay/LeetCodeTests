using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0138CopyRandomList
    {
        //给定一个链表，每个节点包含一个额外增加的随机指针，该指针可以指向链表中的任何节点或空节点。
        //要求返回这个链表的深度拷贝。 

        public RandomListNode CopyRandomList(RandomListNode head)
        {
            RandomListNode node = head;
            List<RandomListNode> list = new List<RandomListNode>();
            while (node != null)
            {
                list.Add(node);
                node = node.next;
            }
            RandomListNode copy = null;
            RandomListNode last = null;
            List<RandomListNode> copyList = new List<RandomListNode>(list.Count);
            foreach (RandomListNode e in list)
            {
                RandomListNode newNode = new RandomListNode(e.label);
                copyList.Add(newNode);
                if (copy == null)
                    copy = newNode;
                else
                    last.next = newNode;
                last = newNode;
            }
            node = copy;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].random != null)
                {
                    int randomIndex = list.IndexOf(list[i].random);
                    node.random = copyList[randomIndex];
                }
                node = node.next;
            }
            return copy;
        }

        public void Test()
        {
            RandomListNode node1 = new RandomListNode(1);
            RandomListNode node2 = new RandomListNode(2);
            RandomListNode node3 = new RandomListNode(3);
            node1.next = node2;
            node1.random = node3;
            node2.next = node3;
            node2.random = null;
            node3.next = null;
            node3.random = node1;
            RandomListNode head = node1;
            RandomListNode copy = CopyRandomList(head);
            RandomListNode node = copy;
            while (node != null)
            {
                Console.Write(node.label + " ");
                if (node.random != null)
                    Console.Write(node.random.label);
                Console.WriteLine();
                node = node.next;
            }
            Console.ReadLine();
        }
    }
}
