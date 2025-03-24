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
        string user = "SebastianPagacz";
        string url = $"https://api.github.com/users/{user}/events/public";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            
            var result = await client.GetAsync(url);
            var json = await result.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<List<Activity>>(json);

            var groupByActivity = from activity in deserializedData group activity by activity.Type into newGroup select newGroup;

            foreach (var i in groupByActivity)
            {
                Console.WriteLine($"{i.Key}");
                foreach (var j in i)
                {
                    Console.WriteLine($"{j.Actor.Login} : {j.CreatedAt} : {j.Repo.Name} : {j.Type}");
                }
            }

            int countPushes = deserializedData.Count(p => p.Type == "PushEvent");
            int countCreates = deserializedData.Count(p => p.Type == "CreateEvent");
            int countReleases = deserializedData.Count(p => p.Type == "ReleaseEvent");
            Console.WriteLine($"{user} pushed {countPushes} commits");
            Console.WriteLine($"{user} created {countCreates}");
            Console.WriteLine($"{user} realeased {countReleases} project");
        }
    }
}
