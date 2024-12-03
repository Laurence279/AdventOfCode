using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.CLI
{
    public class Day2
    {
        private List<List<int>> listNums = new List<List<int>>();

        public Day2()
        {
            this.Result = this.Solve();
        }

        public string Result { get; set; }

        public static bool IsSafe(List<int> list, bool useDampener = false)
        {
            var safe = true;
            var ascending = list[0] < list[1];
            var stack = new Stack<int>();

            static bool nextNumberInSequenceValid(bool ascending, int current, int incoming)
            {
                var followsTrend = ascending ? current < incoming : current > incoming;
                var withinDiffThreshold = int.Abs(incoming - current) > 0 && int.Abs(incoming - current) < 4;
                return followsTrend && withinDiffThreshold;
            }

            foreach (var num in list)
            {
                if (!safe) break;
                if (stack.Count == 0)
                {
                    stack.Push(num);
                    continue;
                }
                var valid = nextNumberInSequenceValid(ascending, stack.Peek(), num);

                if (!valid)
                {
                    safe = false;
                }
                else
                {
                    stack.Push(num);
                }
            }

            if (!safe && useDampener)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    var slicedList = list.Where((_, index) => index != i).ToList();
                    if (IsSafe(slicedList))
                    {
                        return true;
                    }
                }
            }
            return safe;
        }

        private string Solve()
        {
            var silver = this.Silver();
            var gold = this.Gold();
            return string.Format("Silver: {0}, Gold: {1}", silver, gold);
        }

        private string Silver()
        {
            this.PopulateLists();

            var safeListCount = 0;
            foreach (var list in listNums)
            {
                var safe = IsSafe(list);
                Console.WriteLine($"{string.Join(",", list)} - {safe}");
                if (safe)
                {
                    safeListCount++;
                }
            }

            return safeListCount.ToString();
        }

/*        private static bool IsSafe(string input, bool dampener)
        {
            if (IsSafe(input))
            {
                return true;
            }
            // Remove each level in turn until we get safe or run out
            if (dampener)
            {
                var numbers = input.Split(" ").Select(int.Parse).ToArray();
                for (var i = 0; i < input.Length; i++)
                {
                    var newInput = string.Join(" ", numbers.Where((_, j) => j != i).ToArray());
                    if (IsSafe(newInput))
                    {
                        return true;
                    }
                }
            }

            return false;
        }*/

        private string Gold()
        {
            this.PopulateLists();

            var safeListCount = 0;
            foreach (var list in listNums)
            {
                var safe = IsSafe(list, true);
                Console.WriteLine($"{string.Join(",", list)} - {safe}");
                if (safe)
                {
                    safeListCount++;
                }
            }

            return safeListCount.ToString();
        }

        private void PopulateLists()
        {
            this.listNums = new();
            var text = File.ReadAllLines("./Days/day2.txt");

            foreach (var line in text)
            {
                var numbers = line.Split(" ").Select(int.Parse).ToList();
                this.listNums.Add(numbers);
            }
        }
    }
}
