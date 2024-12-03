using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.CLI.Days
{
    public class Day3 : Puzzle
    {
        public override string Gold()
        {
            return string.Empty;
        }

        public override string Silver()
        {
            var text = File.ReadAllText("./Days/day3.txt");
            var regex = new Regex("mul\\((\\d{1,3}),(\\d{1,3})\\)");
            var result = regex.Matches(text);
            var sum = 0;
            foreach (Match item in result)
            {
                var n1 = int.Parse(item.Groups[1].Value);
                var n2 = int.Parse(item.Groups[2].Value);
                sum += n1 * n2;
            }

            return sum.ToString();
        }
    }
}
