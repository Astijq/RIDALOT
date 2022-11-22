using ridalot2._0.Data.RIDALOT;

namespace ridalot2._0.Pages
{
    public class PageService
    {
        public List<Posts> posts = new List<Posts>();
        public List<Images> img = new List<Images>();
        public string getImages(Posts post)
        {
            List<Images> temp = new List<Images>();

            temp = img.Where(x => x.Posts.Id == post.Id).ToList();

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
