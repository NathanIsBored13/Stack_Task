using System;
using System.Collections.Generic;

namespace Stack_Task
{
    class Program
    {
        private static readonly Stack examStack = new Stack();

        static void Main()
        {
            List<Menue.MenueItem> options = new List<Menue.MenueItem>()
            {
                new Menue.MenueItem("Push to the stack", Push, true),
                new Menue.MenueItem("Pop from the stack", Pop, true),
                new Menue.MenueItem("Print stack length", Print, true),
                new Menue.MenueItem("Quit", null, false)
            };

            Menue menue = new Menue("select a action", ">> ", true, options);

            while (menue.Display() != 3) ;
        }

        private static void Push()
        {
            List<Menue.MenueItem> options = new List<Menue.MenueItem>()
            {
                new Menue.MenueItem("Enter new data", Console.Clear, false),
                new Menue.MenueItem("Return to menue", null, false),
            };

            Menue menue = new Menue("Error, exam object could not be created. Select an option", ">> ", false, options);
            bool loop = true;

            do
            {
                Console.Write("Enter the students' name : ");
                string studentName = Console.ReadLine();
                Console.Write("Enter the scores seperated by a space : ");
                string scores = Console.ReadLine();
                if (Exam.MakeExam(studentName, scores) is Exam exam)
                {
                    examStack.Push(exam);
                    Console.WriteLine("exam pushed to stack\n");
                    loop = false;
                }
                else
                {
                    loop = menue.Display() == 0;
                }
            } while (loop);
        }

        private static void Pop()
        {
            if (examStack.Pop() is Exam exam)
                Console.WriteLine($"{exam}\n");
        }

        private static void Print()
        {
            Console.WriteLine($"There are {examStack.Count} items in the stack\n");
        }
    }
}