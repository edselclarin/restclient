using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace restclient
{
    class Program
    {
        static void Main(string[] args)
        {
            // NOTE: ProcessRepositories() returns immediately and will cause
            // Main(...) to exit also.  Append .Wait() so that 
            // ProcessRepositories() blocks until complete.
            ProcessRepositories().Wait();
        }

        private static async Task ProcessRepositories()
        {
            var client = new HttpClient();

            // Reset headers.
            client.DefaultRequestHeaders.Accept.Clear();

            // Configure to accept JSON response.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(
                    "application/vnd.github.v3+json"));

            // Add the User Agent.
            client.DefaultRequestHeaders.Add(
                "User-Agent", ".NET Foundation Repository Reporter");

            // Make the web request.
            var stringTask = client.GetStringAsync(
                "https://api.github.com/orgs/dotnet/repos");

            // Dump HTTP response.
            var msg = await stringTask;
            Console.Write(msg);
        }
    }
}
