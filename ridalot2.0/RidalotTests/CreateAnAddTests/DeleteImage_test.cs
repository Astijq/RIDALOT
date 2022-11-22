using Microsoft.AspNetCore.Components.Forms;
using ridalot2._0.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RidalotTests.CreateAnAddTests
{
    public class DeleteImage_test
    {
        [Fact]
        public void TwoPhotos_DeleteOne_OneLeft()
        {
            CreateAnAd ca = new CreateAnAd();
            ca.imgUrls.Add("first");
            ca.imgUrls.Add("second");

            ca.DeletePhoto("second");
            Assert.Single(ca.imgUrls);
        }
    }
}
