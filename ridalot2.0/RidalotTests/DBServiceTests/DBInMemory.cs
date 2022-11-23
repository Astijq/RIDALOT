using Microsoft.EntityFrameworkCore;
using ridalot2._0.Data.RIDALOT;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using ridalot2._0.Data;

namespace RidalotTests.DBServiceTests
{
    public class DBInMemory : IDisposable
    {
        private readonly DbConnection _connection;
        private readonly DbContextOptions<RIDALOTContext> _contextOptions;
        public DBInMemory()
        {
            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
            // at the end of the test (see Dispose below).
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            _contextOptions = new DbContextOptionsBuilder<RIDALOTContext>()
                .UseSqlite(_connection).Options;

            // Create the schema and seed some data
            using var context = new RIDALOTContext(_contextOptions);

            if (context.Database.EnsureCreated())
            {
                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
                viewCommand.CommandText = @"
CREATE VIEW AllResources AS
SELECT Url
FROM Blogs;"
                ;
                viewCommand.ExecuteNonQuery();
            }
            context.AddRange(
                new Posts { Id = 1, Status = Status.Waiting, User = "user1", Worker = "worker1" },
                new Posts { Id = 2, Status = Status.InProgress, User = "user2", Worker = "worker2" },
                new Images { Id = 1, ImagePath = "firstPath"},
                new Images { Id = 2, ImagePath = "secondPath"},
                new Workers { Email = "worker1"},
                new Workers { Email = "worker2"}
                );
            context.SaveChanges();
        }

        public RIDALOTContext CreateContext() => new RIDALOTContext(_contextOptions);

        public void Dispose() => _connection.Dispose();

    }
}

