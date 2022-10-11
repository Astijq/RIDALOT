namespace ridalot2._0.Data
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Collections;

    public class ReadPost<T> : IEnumerable
    {
        public IEnumerable<T>? posts { get; set; } = new List<T>();
        public void LoadJson(string file = "PostInfo.json")
        {
            using (StreamReader r = File.OpenText(file))
            {
                string json = r.ReadToEnd();
                posts = JsonConvert.DeserializeObject<List<T>>(json);
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
