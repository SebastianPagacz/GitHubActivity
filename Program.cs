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
        //string user = "SebastianPagacz";
        string url = "https://localhost:7168/weatherforecast";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            
            var result = await client.GetAsync(url);
            var json = await result.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<List<Activity>>(json);
            
        }
    }
}
