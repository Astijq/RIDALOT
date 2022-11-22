using ridalot2._0.Data.RIDALOT;

namespace ridalot2._0.Pages
{
    public class PageService
    {
        public Lazy<List<Posts>> posts = new Lazy<List<Posts>>();
        public Lazy<List<Images>> img = new Lazy<List<Images>>();
        public string getImages(Posts post)
        {
            List<Images> temp = new List<Images>();

            temp = img.Value.Where(x => x.Posts.Id == post.Id).ToList();

            if (temp.Count > 0)
            {
                return temp.First().ImagePath;
            }
            else
            {
                return "";
            }

        }
    }
}
