using AdventOfCode.CLI;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day2Tests
    {
        [Test]
        public void IsSafe_DampenerWithValidSequence_ReturnsTrue()
        {
            var input = new List<int> { 1, 3, 5, 1, 7, 10 };
            var result = Day2.IsSafe(input, true);
            Assert.IsTrue(result, $"Test failed for input: {string.Join(", ", input)}. Expected True, got {result}.");
        }

        [Test]
        public void IsSafe_DampenerWithValidSequenceWhenFirstNumRemoved_ReturnsTrue()
        {
            var input = new List<int> { 91, 87, 86, 83, 81, 80, 79, 78 };
            var result = Day2.IsSafe(input, true);
            Assert.IsTrue(result, $"Test failed for input: {string.Join(", ", input)}. Expected True, got {result}.");
        }

        [Test]
        public void IsSafe_DampenerWithInvalidSequence_ReturnsFalse()
        {
            var input = new List<int> { 1, 3, 10, 2, 5, 1 };
            var result = Day2.IsSafe(input, true);
            Assert.IsFalse(result, $"Test failed for input: {string.Join(", ", input)}. Expected False, got {result}.");
        }
    }
}