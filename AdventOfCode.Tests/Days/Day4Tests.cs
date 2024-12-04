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
            var input = @"
                    ...X.......S....
                    ..XMAS.....A....
                    ...A.A.....M....
                    ...S.M.....X....
                    .....X...SAMX...";
            var expected = 5;
            var instance = new Day4(input);

            var result = instance.Silver();

            Assert.IsTrue(expected.ToString() == result.ToString(), $"Expected {expected} but got {result}");
        }
    }
}