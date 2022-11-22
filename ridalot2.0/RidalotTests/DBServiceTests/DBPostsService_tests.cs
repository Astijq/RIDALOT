using ridalot2._0.Data.RIDALOT;
using ridalot2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace RidalotTests.DBServiceTests
{
    public class DBPostsService_tests : DBInMemory
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
                post => Assert.Equal(Status.Waiting, post.Status));
        }

        [Fact]
        public async Task test_AddPost()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);

            var post = new Posts();

            //Assert.True(await service.CreatePostAsync(post));
        }
        [Fact]
        public async Task test_DeletePostIsSuccess()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);

            Assert.True(await service.DeletePostAsync(context.Posts.First()));

        }
        [Fact]
        public async Task test_DeletePostIsFail()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);
            //create a post with id that doesn't exist
            var post = new Posts();
            post.Id = 5;

            Assert.False(await service.DeletePostAsync(post));
        }
        [Fact]
        public async Task test_UpdatePostIsSuccess()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);

            var post = new Posts();
            post.Id = 1;
            post.Status = Status.Finished;
            //test if operation is success
            Assert.True(await service.UpdatePostAsync(post));
            //test if status changed correctly
            var posts = new List<Posts>();
            posts = await service.GetAllPostsAsync();
            Assert.Equal(Status.Finished, posts[0].Status);
        }
        [Fact]
        public async Task test_UpdatePostIsFail()
        {
            using var context = CreateContext();
            DBService service = new DBService(context);
            //create a post with id that doesn't exist
            var post = new Posts();
            post.Id = 5;

            Assert.False(await service.UpdatePostAsync(post));

        }

    }
}
