using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.CLI.Days
{
    public class Day3 : Puzzle
    {
        private readonly string input;
        public Day3(string input)
        {
            this.input = input;
        }

        public override string Gold()
        {
            var splitString = this.SplitOnDoOrDont(this.input);
            var enabled = true;
            var sum = 0;

            foreach (var substr in splitString)
            {
                enabled = substr switch
                {
                    "do()" => true,
                    "don't()" => false,
                    _ => enabled
                };

                if (enabled)
                {
                    var instructions = this.GetMultiplyInstructions(substr);
                    foreach (var (n1, n2) in instructions)
                    {
                        sum += n1 * n2;
                    }
                }
            }
            return sum.ToString();
        }

        public override string Silver()
        {
            var instructions = this.GetMultiplyInstructions(this.input);
            var sum = 0;
            foreach (var (n1, n2) in instructions)
            {
                sum += n1 * n2;
            }

            return sum.ToString();
        }

        public List<(int n1, int n2)> GetMultiplyInstructions(string input)
        {
            var results = new List<(int n1, int n2)>();
            var regex = new Regex("mul\\((\\d{1,3}),(\\d{1,3})\\)");
            var matches = regex.Matches(input);
            foreach (Match item in matches)
            {
                var n1 = int.Parse(item.Groups[1].Value);
                var n2 = int.Parse(item.Groups[2].Value);
                results.Add((n1, n2));
            }
            return results;
        }

        public string[] SplitOnDoOrDont(string input)
        {
            return Regex.Split(input, "(do\\(\\)|don't\\(\\))");
        }
    }
}
