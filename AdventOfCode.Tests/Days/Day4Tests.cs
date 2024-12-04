using AdventOfCode.CLI;
using AdventOfCode.CLI.Days;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day4Tests
    {
        [Test]
        public void SolveSilver_ValidInput_ReturnsCorrectNumber()
        {
            var input = @"...X....S..S..S.
                          ..XMAS...A.A.A..
                          ...A.A....MMM...
                          ...S.M.....X....
                          .....X...SAMX...";
            var expected = 7;
            var instance = new Day4(input);

            var result = instance.Silver();

            Assert.IsTrue(expected.ToString() == result.ToString(), $"Expected {expected} but got {result}");
        }

        [Test]
        public void SolveGold_ValidInput_ReturnsCorrectNumber()
        {
            var input = @"...X....S..S..S.
                          ......S.S.S.M...
                          ...A...A...A....
                          ...S..M.M.M.S...
                          .....X..........";
            var expected = 1;
            var instance = new Day4(input);

            var result = instance.Gold();

            Assert.IsTrue(expected.ToString() == result.ToString(), $"Expected {expected} but got {result}");
        }
    }
}