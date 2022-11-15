using ridalot2._0.Data;

namespace RidalotTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestPay()
        {
            Payment p = new Payment();
            var test = p.CalculatePay(10.1f, 2);
            var expected = 9.5f;
            Assert.Equal(expected, test);
        }
    }
}