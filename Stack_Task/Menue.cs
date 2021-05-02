using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Task
{
    class Menue
    {
        public struct MenueItem
        {
            public string prompt;
            public Action onSelect;
            public bool wait;

            public MenueItem(string prompt, Action onSelect, bool wait)
            {
                this.prompt = prompt;
                this.onSelect = onSelect;
                this.wait = wait;
            }
        }

        private readonly string header, prompt;
        private readonly List<MenueItem> options = new List<MenueItem>();
        private readonly bool clear;

        public Menue(string header, string prompt, bool clear, List<MenueItem> options)
        {
            this.header = header;
            this.prompt = prompt;
            this.clear = clear;
            this.options = options;
        }

        public int Display()
        {
            int value;
            do
            {
                if (clear)
                    Console.Clear();
                Console.WriteLine(header);
                for (int i = 0; i < options.Count; i++)
                    Console.WriteLine($"{i + 1}: {options[i].prompt}");
                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out value) && value > 0 && value <= options.Count)
                {
                    Console.WriteLine();
                    if (options[value - 1].onSelect is Action action)
                        action.Invoke();
                    if (options[value - 1].wait)
                    {
                        Console.WriteLine("[press any key to continue]");
                        Console.ReadKey();
                    }
                }
                else
                {
                    value = -1;
                    Console.WriteLine($"\nyou can only enter numbers between 1 and {options.Count}");
                    Console.WriteLine("[press any key to continue]");
                    Console.ReadKey();
                }
            } while (value == -1);
            return value - 1;
        }
    }
}