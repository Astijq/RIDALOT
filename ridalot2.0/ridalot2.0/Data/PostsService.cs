using ridalot2._0.Data.RIDALOT;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            GetPostAsync(string strCurrentUser)
        {
            // Get Weather Forecasts  
            return await _context.Posts
                 // Only get entries for the current logged in user
                 .Where(x => x.User == strCurrentUser)
                 // Use AsNoTracking to disable EF change tracking
                 // Use ToListAsync to avoid blocking a thread
                 .AsNoTracking().ToListAsync();
        }
        public Task<Posts>
            CreatePostAsync(Posts post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return Task.FromResult(post);
        }

    }
}
