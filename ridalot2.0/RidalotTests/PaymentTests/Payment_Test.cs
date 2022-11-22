using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ridalot2._0.Data;

namespace RidalotTests.PaymentTests
{
	public class Payment_Test
	{
        [Fact]
        public void NegativeFloorNormalPay()
        {
            double test = Payment.CalculatePay(10.1f, -2);
            var expected = 9.5f;
            Assert.Equal(expected, test);
        }
        [Theory]
        [InlineData(10.1f, 2, 9.5)]
        [InlineData(5.7f, 5, 13.4)]
        [InlineData(0f, 0, 5)]
        public void CalculatePayCorrect(float distance, int floor, double expected)
        {
            double test = Payment.CalculatePay(distance, floor);
            Assert.Equal(expected, test);
        }
    }
}
