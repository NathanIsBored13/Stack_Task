using System;

namespace Stack_Task
{
    class Exam
    {
        //public readonly get methods
        public string Name { get; }
        public int Score1 { get; }
        public int Score2 { get; }

        public Exam(string name, int score1, int score2)
        {
            //saves passed data in internal variables
            Name = name;
            Score1 = Clamp(score1);
            Score2 = Clamp(score2);
        }

        //returns the object as a string
        public override string ToString() => $"the student {Name} scored {Score1} on test 1 and {Score2} on test 2";

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
