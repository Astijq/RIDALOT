using Newtonsoft.Json;
  public class ReadPost
    {
        List<Post>? posts { get; set; }
        public void LoadJson()
        {
            using (StreamReader r = File.OpenText("PostInfo.json"))
            {
                string json = r.ReadToEnd();
                posts = JsonConvert.DeserializeObject<List<Post>>(json);
            }
        }
        public List<Post> Add(Post post)
        {
            if(posts == null)
                posts = new List<Post>();

            posts.Add(post);
            return posts;
        }
    }

