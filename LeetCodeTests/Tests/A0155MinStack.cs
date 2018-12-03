using System;
namespace LeetCodeTests.Tests
{
    public class A0155MinStack
    {
        //设计一个支持 push，pop，top 操作，并能在常数时间内检索到最小元素的栈。
        //push(x) -- 将元素 x 推入栈中。
        //pop() -- 删除栈顶的元素。
        //top() -- 获取栈顶元素。
        //getMin() -- 检索栈中的最小元素。
        //示例:
        //MinStack minStack = new MinStack();
        //minStack.push(-2);
        //minStack.push(0);
        //minStack.push(-3);
        //minStack.getMin();   --> 返回 -3.
        //minStack.pop();
        //minStack.top();      --> 返回 0.
        //minStack.getMin();   --> 返回 -2.

        /** initialize your data structure here. */
        //public MinStack()
        //{

        //}

        private int[] nums;
        private int capacity;
        private int index;
        private int min;

        public A0155MinStack()
        {
            this.capacity = 2;
            this.nums = new int[this.capacity];
            this.index = -1;
            this.min = int.MaxValue;
        }

        public void Push(int x)
        {
            //check if full
            if (this.index + 1 >= this.capacity)
            {
                this.capacity = this.capacity * 2;
                int[] newNums = new int[this.capacity];
                Array.Copy(this.nums, newNums, this.nums.Length);
                this.nums = newNums;
            }
            this.index++;
            this.nums[index] = x;
            //update min
            if (x < this.min)
                this.min = x;
        }

        public void Pop()
        {
            if (this.index >= 0)
            {
                this.index--;
                //update min
                this.min = int.MaxValue;
                for (int i = 0; i <= this.index; i++)
                    if (this.nums[i] < this.min)
                        this.min = this.nums[i];
            }
        }

        public int Top()
        {
            if (this.index >= 0)
                return this.nums[this.index];
            return -1;
        }

        public int GetMin()
        {
            return this.min;
        }

        public void Test()
        {
            A0155MinStack minStack = new A0155MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            int val1 = minStack.GetMin();
            minStack.Pop();
            int val2 = minStack.Top();
            int val3 = minStack.GetMin();
            Console.Write(val1 + " " + val2 + " " + val3);
            Console.ReadLine();
        }
    }
}
