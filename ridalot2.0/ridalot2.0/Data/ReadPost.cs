namespace ridalot2._0.Data
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    public class ReadPost<T>
    {
        public List<T>? posts { get; set; }
        public void LoadJson(string file)
        {
            using (StreamReader r = File.OpenText(file))
            {
                string json = r.ReadToEnd();
                posts = JsonConvert.DeserializeObject<List<T>>(json);
            }
        }
        public List<T> Add(T post)
        {
            if (posts == null)
            {
                posts = new List<T>();
            }
            posts.Add(post);
            return posts;
        }
    }
}
