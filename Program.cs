using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace WebAPIClient
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

            // Make the web request, and deserialize the response into a list 
            // of respositories.
            var serializer = new DataContractJsonSerializer(typeof(List<repo>));
            var streamTask = client.GetStreamAsync(
                "https://api.github.com/orgs/dotnet/repos");
            var repositories = serializer.ReadObject(await streamTask) 
                as List<repo>;

            // Dump the names of the repositories.
            foreach (var repo in repositories)
                Console.WriteLine(repo.name);
        }
    }
}
