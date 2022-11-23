using ridalot2._0.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ridalot2._0.Data.RIDALOT;

namespace RidalotTests.DBServiceTests
{
    public class DBImagesService_tests : DBInMemory
    {
        [Fact]
        public async Task test_AddImageisSuccess()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);
            var img = new Images();
            img.ImagePath = "notNull";
            Assert.True(await service.CreateImageAsync(img));
        }
        [Fact]
        public async Task test_GetImages()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);
            var imgs = new List<Images>();
            imgs = await service.GetImagesAsync();
            Assert.Collection<Images>(imgs,
                img => Assert.Equal("firstPath", img.ImagePath),
                img => Assert.Equal("secondPath", img.ImagePath)
            );
        }
    }
}
