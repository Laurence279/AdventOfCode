using AdventOfCode.CLI;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day2Tests
    {
        [Test]
        public void UsingDampener_ValidSequence_ReturnsTrue()
        {
            var input = new List<int> { 1, 3, 5, 1, 7, 10 };
            var result = Day2.IsSafe(input, true);
            Assert.IsTrue(result, $"Test failed for input: {string.Join(", ", input)}. Expected True, got {result}.");
        }

        [Test]
        public void UsingDampener_ValidSequenceWhenFirstNumRemoved_ReturnsTrue()
        {
            var input = new List<int> { 91, 87, 86, 83, 81, 80, 79, 78 };
            var result = Day2.IsSafe(input, true);
            Assert.IsTrue(result, $"Test failed for input: {string.Join(", ", input)}. Expected True, got {result}.");
        }

        [Test]
        public void UsingDampener_InvalidSequence_ReturnsFalse()
        {
            var input = new List<int> { 1, 3, 10, 2, 5, 1 };
            var result = Day2.IsSafe(input, true);
            Assert.IsFalse(result, $"Test failed for input: {string.Join(", ", input)}. Expected False, got {result}.");
        }
    }
}