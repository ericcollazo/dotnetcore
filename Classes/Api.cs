
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class Api
{
    private static readonly HttpClient client = new HttpClient();

    public string[] values { get; }

    private static async Task ProcessRepositories()
    {   
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

        var retVal = await stringTask;
    }
}