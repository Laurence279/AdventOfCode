namespace AdventOfCode.CLI.Days
{
    public class DayRegistry
    {
        public Dictionary<int, Puzzle> registry;

        public DayRegistry()
        {
            this.registry = new Dictionary<int, Puzzle>();
            this.Setup();
        }

        private void Setup()
        {
            this.registry.Add(1, new Day1());
            this.registry.Add(2, new Day2());
            this.registry.Add(3, new Day3());
        }

        public Puzzle GetDay(int day)
        {
            return this.registry[day];
        }
    }
}
