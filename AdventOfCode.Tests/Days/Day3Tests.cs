using AdventOfCode.CLI;
using AdventOfCode.CLI.Days;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day3Tests
    {
        [Test]
        public void GetMultiplyInstructions_ValidInput_ReturnsCorrectTuples()
        {
            var input = "mul(89,802)!+who()$do()&~]%>?{ >mul(676,57)< <from()!((*&mul(91,478)]mul(105,40)";
            var expected = new List<(int n1, int n2)>
            {
                (89, 802),
                (676, 57),
                (91, 478),
                (105, 40)
            };
            var instance = new Day3(input);

            var result = instance.GetMultiplyInstructions(input);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void SplitOnDoOrDont_ValidInput_ReturnsStringArrayIncludingDosAndDonts()
        {
            var input = "asjdasij342do()234das234ipdon't()2dpoas";
            var instance = new Day3(input);
            var expected = new[]
            {
                "do()",
                "don't()"
            };

            var result = instance.SplitOnDoOrDont(input);

            Assert.IsTrue(expected.All(x => result.Contains(x)));
        }

        [Test]
        public void SplitOnDoOrDont_ValidInput_DoesNotIncludeAnyDosOrDontsInsideSubstrings()
        {
            var input = "asjdasij342do()234ddo*(dodoodo()()Do()do()dont()dont()2dodont()dodasj30asdont()doas2i9don't()dla234ipdon't()2dpoas";
            var instance = new Day3(input);

            var result = instance.SplitOnDoOrDont(input);

            Assert.IsTrue(result.All(x => 
                    (x == "do()" || x == "dont()") || 
                    (!x.Contains("do()") || !x.Contains("dont()"))));
        }
    }
}