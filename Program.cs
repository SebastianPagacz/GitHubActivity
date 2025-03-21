using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Security.Cryptography.Xml;
using System.Web;
using Newtonsoft.Json;
using GitHubActivity.Models;

namespace GitHubActivity;

internal class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://api.github.com/users/SebastianPagacz/events/public";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            
            var result = await client.GetAsync(url);
            var json = await result.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<List<Activity>>(json);
            
            foreach (Activity i in deserializedData)
            {
                Console.WriteLine($"{i.Repo.Name} : {i.Type}");
            }
        }
    }
}
