using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.CLI
{
    public class Day1 : Puzzle
    {
        private List<int> list1 = new List<int>();
        private List<int> list2 = new List<int>();
        private Dictionary<int, int> dict = new Dictionary<int, int>();

        public Day1(string input)
        {
            this.Setup(input);
        }

        public override string Silver()
        {
            list1.Sort();
            list2.Sort();

            var result = 0;
            for (var i = 0; i < list1.Count; i++)
            {
                var diff = Math.Abs(list1[i] - list2[i]);
                result += diff;
            }

            return result.ToString();
        }

        public override string Gold()
        {
            foreach (var number in this.list2) {
                if (this.dict.ContainsKey(number))
                {
                    this.dict[number] += 1;
                }
            }

            var result = 0;
            foreach (var key in this.dict.Keys)
            {
                result += this.dict[key] * key;
            }
            return result.ToString();
        }

        private void Setup(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                var numbers = line.Split("   ");
                this.list1.Add(int.Parse(numbers[0]));
                this.dict[int.Parse(numbers[0])] = 0;
                this.list2.Add(int.Parse(numbers[1]));
            }
        }
    }
}
