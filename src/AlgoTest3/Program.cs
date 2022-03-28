using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgoTest3
{
    internal class Program
    {

        // 스택 LIFO (후입선출 : Last in First out)

        // 큐 FIFO (선입선출 : First in First out)

        static void Main(string[] args)
        {

            Stack<int> stack = new Stack<int>();

            stack.Push(11);
            stack.Push(12);
            stack.Push(13);
            stack.Push(14);

            if(stack.Count > 0)
            {
                int data = stack.Pop();
                int data2 = stack.Peek();
            }

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(901);
            queue.Enqueue(902);
            queue.Enqueue(903);
            queue.Enqueue(904);

            int data3 = queue.Dequeue();
            int data4 = queue.Peek();    

            LinkedList<int> list = new LinkedList<int>();

            list.AddLast(1011);
            list.AddLast(1012);
            list.AddLast(1013);
            list.AddLast(1014);

            int value1 = list.First.Value;
            list.RemoveFirst();

            int value2 = list.First.Value;
            list.RemoveLast();




        }
    }
}
