using ridalot2._0.Data.RIDALOT;
using ridalot2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RidalotTests.DBServiceTests
{
    public class DBWorkerService_tests : DBInMemory
    {
        [Fact]
        public async Task test_AddWorkerIsSuccess()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);
            var worker = new Workers();
            worker.Email = "notNull";
            Assert.True(await service.CreateWorkerAsync(worker));
        }
        [Fact]
        public async Task test_GetWorkers()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);
            var workers = new List<Workers>();
            workers = await service.GetAllWorkersAsync();
            Assert.Collection<Workers>(workers,
                worker => Assert.Equal("worker1", worker.Email),
                worker => Assert.Equal("worker2", worker.Email)
            );
        }
    }
}
