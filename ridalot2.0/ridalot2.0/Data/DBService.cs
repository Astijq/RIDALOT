using ridalot2._0.Data.RIDALOT;
using Microsoft.EntityFrameworkCore;

namespace ridalot2._0.Data
{
    public class DBService
    {
        private Lazy<RIDALOTContext> _context;
        public RIDALOTContext context { get {return _context.Value;} }

        public DBService(RIDALOTContext context)
        {
            _context = new Lazy<RIDALOTContext>(() => context);
        }

        public async Task<List<Posts>> GetAllPostsAsync()
        {
            return await _context.Value.Posts
                 .AsNoTracking().ToListAsync();
        }
        public async Task<List<Posts>> GetMyPostsAsync(string strCurrentUser)
        {
            return await _context.Value.Posts
                 .Where(x => x.User == strCurrentUser)
                 .AsNoTracking().ToListAsync();
        }
        public async Task<List<Posts>> GetMyTasksAsync(string strCurrentUser)
        {
            return await _context.Value.Posts
                 .Where(x => x.Worker == strCurrentUser)
                 .AsNoTracking().ToListAsync();
        }
        public async Task<List<Posts>> GetFeedPostsAsync()
        {
            return await _context.Value.Posts
                 .Where(x => x.Status == Status.Waiting)
                 .AsNoTracking().ToListAsync();
        }
        public Task<bool> CreatePostAsync(Posts post)
        {
            _context.Value.Posts.Add(post);
            _context.Value.SaveChanges();
            return Task.FromResult(true);
        }
        public Task<bool> UpdatePostAsync(Posts post)
        {
            var ExistingPost =
                _context.Value.Posts
                .Where(x => x.Id == post.Id)
                .FirstOrDefault();
            if (ExistingPost != null)
            {
                ExistingPost.Status = post.Status;
                ExistingPost.Worker = post.Worker;
                _context.Value.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
        public Task<bool> DeletePostAsync(Posts post)
        {
            var ExistingPost =
                _context.Value.Posts
                .Where(x => x.Id == post.Id)
                .FirstOrDefault();
            if (ExistingPost != null)
            {
                _context.Value.Posts.Remove(ExistingPost);
                _context.Value.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
        public Task<bool> CreateImageAsync(Images img)
        {
            _context.Value.Images.Add(img);
            _context.Value.SaveChanges();
            return Task.FromResult(true);
        }
        public async Task<List<Images>> GetImagesAsync()
        {
            return await _context.Value.Images.Include(p => p.Posts)
                 .AsNoTracking().ToListAsync();
        }
        public Task<bool> CreateWorkerAsync(Workers worker)
        {
            _context.Value.Workers.Add(worker);
            _context.Value.SaveChanges();
            return Task.FromResult(true);
        }
        public async Task<List<Workers>> GetAllWorkersAsync()
        {
            return await _context.Value.Workers
                 .AsNoTracking().ToListAsync();
        }
        public bool CheckIfWorker(string email)
        {
            var result = _context.Value.Workers.Where(x => x.Email == email).ToList();
            if (result.Count == 0)
            {
                return false;
            }
            return true;

        }
    }
}
