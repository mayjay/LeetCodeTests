using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Tests
{
    class A0146LRUCache
    {
        //运用你所掌握的数据结构，设计和实现一个  LRU (最近最少使用) 缓存机制。它应该支持以下操作： 获取数据 get 和 写入数据 put 。
        //获取数据 get(key) - 如果密钥 (key) 存在于缓存中，则获取密钥的值（总是正数），否则返回 -1。
        //写入数据 put(key, value) - 如果密钥不存在，则写入其数据值。当缓存容量达到上限时，它应该在写入新数据之前删除最近最少使用的数据值，从而为新的数据值留出空间。
        //进阶:
        //你是否可以在 O(1) 时间复杂度内完成这两种操作？
        //示例:
        //LRUCache cache = new LRUCache( 2 /* 缓存容量 */ );
        //cache.put(1, 1);
        //cache.put(2, 2);
        //cache.get(1);       // 返回  1
        //cache.put(3, 3);    // 该操作会使得密钥 2 作废
        //cache.get(2);       // 返回 -1 (未找到)
        //cache.put(4, 4);    // 该操作会使得密钥 1 作废
        //cache.get(1);       // 返回 -1 (未找到)
        //cache.get(3);       // 返回  3
        //cache.get(4);       // 返回  4

        public class LRUCache
        {
            private Dictionary<int, int> cache;
            private int capacity;
            private List<int> visit;

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                this.cache = new Dictionary<int, int>(capacity);
                this.visit = new List<int>(capacity);
            }

            public int Get(int key)
            {
                if (this.cache.ContainsKey(key))
                {
                    UpdateVisit(key);
                    return this.cache[key];
                }
                else
                    return -1;
            }

            public void Put(int key, int value)
            {
                int deleteKey = UpdateVisit(key);
                if (deleteKey != -1)
                    this.cache.Remove(deleteKey);
                if (this.cache.ContainsKey(key))
                    this.cache[key] = value;
                else
                    this.cache.Add(key, value);
            }

            private int UpdateVisit(int key)
            {
                int ret = -1;
                if (visit.Contains(key))
                {
                    //remove and insert to end
                    visit.Remove(key);
                    visit.Add(key);
                }
                else
                {
                    if (visit.Count >= capacity)
                    {
                        ret = visit.First();
                        visit.RemoveAt(0);
                    }
                    visit.Add(key);
                }
                return ret;
            }
        }

        public void Test()
        {
            LRUCache cache = new LRUCache(2 /* 缓存容量 */ );
            cache.Put(1, 1);
            cache.Put(2, 2);
            Console.WriteLine(cache.Get(1));       // 返回  1
            cache.Put(3, 3);    // 该操作会使得密钥 2 作废
            Console.WriteLine(cache.Get(2));       // 返回 -1 (未找到)
            cache.Put(4, 4);    // 该操作会使得密钥 1 作废
            Console.WriteLine(cache.Get(1));       // 返回 -1 (未找到)
            Console.WriteLine(cache.Get(3));       // 返回  3
            Console.WriteLine(cache.Get(4));       // 返回  4
            Console.ReadLine();
        }

    }
}
