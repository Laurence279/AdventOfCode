using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.CLI
{
    public abstract class Puzzle
    {
        public string Solve()
        {
            var silver = this.Silver();
            var gold = this.Gold();
            return string.Format("Silver: {0}, Gold: {1}", silver, gold);
        }

        public abstract string Silver();

        public abstract string Gold();
    }
}
