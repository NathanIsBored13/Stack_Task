using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Task
{
    class Exam
    {
        //public readonly get methods
        public string Name { get => name; }
        public int Score1 { get => score1; }
        public int Score2 { get => score2; }

        //exam values
        private readonly string name;
        private readonly int score1, score2;

        public Exam(string name, int score1, int score2)
        {
            //saves passed data in internal variables
            this.name = name;
            this.score1 = Clamp(score1);
            this.score2 = Clamp(score2);
        }

        //returns the object as a string
        public override string ToString() => $"the student {name} scored {score1} on test 1 and {score2} on test 2";

        public static Exam MakeExam(string name, string scores)
        {
            string[] user_inputs = scores.Split(' ');

            if (user_inputs.Length != 2)
            {
                Console.WriteLine("\nValues must be seperated by a space\n");
                return null;
            }

            if (!int.TryParse(user_inputs[0], out int score1) || !int.TryParse(user_inputs[1], out int score2))
            {
                Console.WriteLine("\nValues must be intigers\n");
                return null;
            }

            if (!InRange(score1) || !InRange(score2))
            {
                Console.WriteLine("\nScore values must be between 0 and 100\n");
                return null;
            }

            return new Exam(name, score1, score2);
        }

        //method clamps values to between 0 and 100
        private static int Clamp(int value) => Math.Clamp(value, 0, 100);

        private static bool InRange(int value) => value >= 0 && value <= 100;
    }
}
