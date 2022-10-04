using Newtonsoft.Json;

namespace ridalot2._0.Data
{
    public class ReadPost
    {
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("PostInfo.json"))
            {
                string json = r.ReadToEnd();
                List<Post> items = JsonConvert.DeserializeObject<List<Post>>(PostInfo.json);
            }
        }
    }
}
