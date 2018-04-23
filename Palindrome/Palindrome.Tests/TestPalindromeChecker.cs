using Xunit;

namespace Palindrome.Tests
{
    public class TestPalindromeChecker
    {
        [Fact]
        public void TestBasicPalindrome()
        {
            string p_basic = "racecar";

            bool checker = PalindromeChecker.Instance.CheckPalindrome(p_basic);

            Assert.True(checker);
        }

        [Fact]
        public void TestCapitalPalindrome()
        {
            string p_capital = "Racecar";

            bool checker = PalindromeChecker.Instance.CheckPalindrome(p_capital);

            Assert.True(checker);
        }

        [Fact]
        public void TestNumberPalindrome()
        {
            int p_number = 12321;

            bool checker = PalindromeChecker.Instance.CheckPalindrome(p_number);

            Assert.True(checker);
        }

        [Fact]
        public void TestComplexPalindrome()
        {
            string p_complex = "Cat, tac.";

            bool checker = PalindromeChecker.Instance.CheckPalindrome(p_complex);

            Assert.True(checker);
        }


        [Fact]
        public void IsNotPalindrome()
        {
            string p_false = "Ventriloquism";

            bool checker = PalindromeChecker.Instance.CheckPalindrome(p_false);

            Assert.False(checker);
        }
    }
}
