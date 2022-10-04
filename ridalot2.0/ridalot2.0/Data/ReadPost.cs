using Newtonsoft.Json;

namespace ridalot2._0.Data
{
    public class ReadPost
    {
        List<Post>? posts { get; set; }
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("PostInfo.json"))
            {
                string json = r.ReadToEnd();
                posts = JsonConvert.DeserializeObject<List<Post>>(json);
            }
        }
    }
}
