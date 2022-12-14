using System.Net.Http;
using System.Threading.Tasks;

namespace ridalot2._0.Pages.PageSupport
{
    public class CustomerMail
    {

        string custEmail = "astijusmc@gmail.com";
        string ownerEmail = "ridalot.info@gmail.com";
        string postCreatedSubject = "Post Created Successfully";
        string postCreatedText = "Your post has been added, wait for someone to contact you about the pickup";
        string? API
        {
            get
            {
                var builder = new ConfigurationBuilder().AddUserSecrets<CustomerMail>();
                var configuration = builder.Build();
                // Access the secrets using the configuration object
                return configuration["sgAPI"];
            }
        }
        public async void sendMail()
        {

            // Create an instance of the HttpClient class
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7027/");

            var requestUrl = $"api/ApprovedPost?custEmail={custEmail}&ownerEmail={ownerEmail}" +
                $"&subject={postCreatedSubject}&text={postCreatedText}&key={API}";

            // Make a GET request to the Web API's endpoint
            var response = await client.GetAsync(requestUrl);

            // Read the response as a string
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
        }
    }

}
