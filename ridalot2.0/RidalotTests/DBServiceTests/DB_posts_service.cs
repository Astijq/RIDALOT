using ridalot2._0.Data.RIDALOT;
using ridalot2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RidalotTests.DBServiceTests
{
    public class DB_posts_service : DBInMemory
    {
        [Fact]
        public async Task test_GetAllPosts()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);
            var posts = new List<Posts>();
            posts = await service.GetAllPostsAsync();

            Assert.Collection(posts,
                post => Assert.Equal("user1", post.User),
                post => Assert.Equal("user2", post.User)
                );
        }

        [Fact]
        public async Task test_GetMyPosts()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);
            var posts = new List<Posts>();
            posts = await service.GetMyPostsAsync("user1");

            Assert.Collection(posts,
                post => Assert.Equal("user1", post.User));
        }

        [Fact]
        public async Task test_GetMyTasks()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);
            var posts = new List<Posts>();
            posts = await service.GetMyTasksAsync("worker2");

            Assert.Collection(posts,
                post => Assert.Equal("worker2", post.Worker));
        }
        [Fact]
        public async Task test_GetFeedPosts()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);
            var posts = new List<Posts>();
            posts = await service.GetFeedPostsAsync();

            Assert.Collection(posts,
                post => Assert.Equal(0, post.Status));
        }

        [Fact]
        public async Task test_AddPost()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);

            var post = new Posts();

            Assert.True(await service.CreatePostAsync(post))
        }
    }
}
