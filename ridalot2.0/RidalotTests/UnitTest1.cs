using ridalot2._0.Data;
using ridalot2._0.Pages;

namespace RidalotTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestPay()
        {

            double test = Payment.CalculatePay(10.1f, 2);
            var expected = 9.5f;
            Assert.Equal(expected, test);
        }
        [Fact]
        public void TestRegex()
        {
            var test = Constants.addressMatch("Didlaukio g. 47");
            Assert.True(test);
        }
        [Fact]
        public void TestDeletePhoto()
        {
            CreateAnAd ca = new CreateAnAd();
            ca.imgUrls.Add("first");
            ca.imgUrls.Add("second");

            ca.DeletePhoto("second");
            Assert.Single(ca.imgUrls);
        }
    }
}