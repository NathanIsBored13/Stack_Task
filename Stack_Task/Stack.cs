using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Task
{
    class Stack
    {
        public int Count { get => headPointer; }

        private readonly Exam[] stack;
        private int headPointer = 0;

        public Stack()
        {
            stack = new Exam[100];
        }

        public Exam Pop()
        {
            if (headPointer > 0)
                return stack[--headPointer];
            else
                Console.WriteLine("ERROR! stack is empty\n");
                return null;
        }

        public bool Push(Exam value)
        {
            if (headPointer < 100)
                stack[headPointer++] = value;
            else
                Console.WriteLine("ERROR! stack is full\n");
            return headPointer <= 100;
        }
    }
}
