using ridalot2._0.Data.RIDALOT;
using Microsoft.EntityFrameworkCore;

namespace ridalot2._0.Data
{
    public class PostsService
    {
        private readonly RIDALOTContext _context;
        public PostsService(RIDALOTContext context)
        {
            _context = context;
        }
        public async Task<List<Posts>>
            GetAllPostsAsync()
        {
            return await _context.Posts
                 .AsNoTracking().ToListAsync();
        }
        public async Task<List<Posts>>
            GetMyPostsAsync(string strCurrentUser)
        {
            return await _context.Posts
                 .Where(x => x.User == strCurrentUser)
                 .AsNoTracking().ToListAsync();
        }
        public async Task<List<Posts>>
            GetMyTasksAsync(string strCurrentUser)
        {
            return await _context.Posts
                 .Where(x => x.Worker == strCurrentUser)
                 .AsNoTracking().ToListAsync();
        }
        public Task<Posts>
            CreatePostAsync(Posts post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return Task.FromResult(post);
        }

        public Task<bool>
           DeletePostAsync(Posts post)
        {
            var ExistingPost =
                _context.Posts
                .Where(x => x.Id == post.Id)
                .FirstOrDefault();
            if (ExistingPost != null)
            {
                _context.Posts.Remove(ExistingPost);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<bool>
            UpdatePostAsync(Posts post)
        {
            var ExistingPost =
                _context.Posts
                .Where(x => x.Id == post.Id)
                .FirstOrDefault();
            if (ExistingPost != null)
            {
                ExistingPost.Status =
                    post.Status;
                ExistingPost.Worker =
                    post.Worker;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

    }
}
