using Xunit;


namespace SimpleNumbers
{
    public class SimpleNumbersTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(Numbers.SimpleNumber(7));
        }
    }
}