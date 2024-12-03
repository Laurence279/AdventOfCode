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
            var days = new Dictionary<int, Type>()
            {
                { 1, typeof(Day1) },
                { 2, typeof(Day2) },
                { 3, typeof(Day3) }
            };

            foreach (var day in days)
            {
                var dayInstance = Activator.CreateInstance(day.Value, this.GetInput(day.Key)) as Puzzle;
                if (dayInstance != null)
                {
                    this.registry.Add(day.Key, dayInstance);
                }
            }
        }

        private string GetInput(int day)
        {
            var path = $"./Days/day{day}.txt";
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else
            {
                throw new FileNotFoundException($"{path} does not exist.");
            }
        }

        public Puzzle GetDay(int day)
        {
            if (this.registry.ContainsKey(day))
            {
                return this.registry[day];
            }
            else
            {
                throw new KeyNotFoundException($"Day {day} does not exist.");
            }
        }
    }
}
