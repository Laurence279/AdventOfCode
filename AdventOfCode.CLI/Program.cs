namespace AdventOfCode.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No day provided");
                return;
            }

            int.TryParse(args[0], out var day);
            PrintIntro(day);
            var result = GetResult(day);
            PrintResult(result);
        }

        private static void PrintResult(string result)
        {
            Console.WriteLine("Result is: {0}", result);
        }

        private static string GetResult(int day)
        {
            var day2 = new Day2();
            return day2.Result;
        }

        private static void PrintIntro(int day)
        {
            PrintTree(10);
            PrintTitle(day);
        }

        private static void PrintTitle(int day)
        {
            Console.WriteLine("Day selected: {0}", day);
        }

        private static void PrintTree(int count = 1)
        {
            string[] tokens = new string[9];
            tokens[0] = @"           ";
            tokens[1] = @"     *     ";
            tokens[2] = @"    /.\    ";
            tokens[3] = @"   /..'\   ";
            tokens[4] = @"   /'.'\   ";
            tokens[5] = @"  /.''.'\  ";
            tokens[6] = @"  /.'.'.\  ";
            tokens[7] = @" /'.''.'.\ ";
            tokens[8] = @" ^^^[_]^^^ ";

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(tokens[i]);
                }

                Console.WriteLine();
            }
        }
    }
}
