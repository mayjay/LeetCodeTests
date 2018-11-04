﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0133CloneGraph
    {
        //克隆一张无向图，图中的每个节点包含一个 label （标签）和一个 neighbors （邻接点）列表 。
        //OJ的无向图序列化：
        //节点被唯一标记。
        //我们用 # 作为每个节点的分隔符，用 , 作为节点标签和邻接点的分隔符。
        //例如，序列化无向图 {0,1,2#1,2#2,2}。
        //该图总共有三个节点, 被两个分隔符  # 分为三部分。 
        //第一个节点的标签为 0，存在从节点 0 到节点 1 和节点 2 的两条边。
        //第二个节点的标签为 1，存在从节点 1 到节点 2 的一条边。
        //第三个节点的标签为 2，存在从节点 2 到节点 2 (本身) 的一条边，从而形成自环。
        //我们将图形可视化如下：
        //       1
        //      / \
        //     /   \
        //    0 --- 2
        //         / \
        //         \_/

        private Dictionary<UndirectedGraphNode, UndirectedGraphNode> dict = new Dictionary<UndirectedGraphNode, UndirectedGraphNode>();

        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null) return null;
            UndirectedGraphNode newNode = new UndirectedGraphNode(node.label);
            dict.Add(node, newNode);
            foreach (UndirectedGraphNode neighbor in node.neighbors)
            {
                if (dict.ContainsKey(neighbor))
                    newNode.neighbors.Add(dict[neighbor]);
                else
                    newNode.neighbors.Add(CloneGraph(neighbor));
            }
            return newNode;
        }

        public void Test()
        {
            UndirectedGraphNode node1 = new UndirectedGraphNode(0);
            UndirectedGraphNode node2 = new UndirectedGraphNode(1);
            UndirectedGraphNode node3 = new UndirectedGraphNode(2);
            node1.neighbors.Add(node2);
            node1.neighbors.Add(node3);
            node2.neighbors.Add(node1);
            node2.neighbors.Add(node3);
            node3.neighbors.Add(node1);
            node3.neighbors.Add(node2);
            node3.neighbors.Add(node3);
            UndirectedGraphNode node = node1;
            UndirectedGraphNode copy = CloneGraph(node);
            Console.ReadLine();
        }
    }
}
