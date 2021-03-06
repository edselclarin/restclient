﻿using System;
using System.Collections.Generic; // List
using System.Net.Http; // HttpClient
using System.Net.Http.Headers; // MediaTypeWithQualityHeaderValue
using System.Runtime.Serialization.Json; // DataContractJsonSerializer
using System.Threading.Tasks; // Task

namespace WebAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // NOTE: ProcessRepositories().Result will block until complete.
            var repositories = ProcessRepositories().Result;

            // Dump the info for each repository.
            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.Name);
                Console.WriteLine(repo.Description);
                Console.WriteLine(repo.GitHubHomeUrl);
                Console.WriteLine(repo.Homepage);
                Console.WriteLine(repo.Watchers);
                Console.WriteLine(repo.LastPush);
                Console.WriteLine();
            }
        }

        private static async Task<List<Repository>> ProcessRepositories()
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
            var serializer = new DataContractJsonSerializer(
                typeof(List<Repository>));
            var streamTask = client.GetStreamAsync(
                "https://api.github.com/orgs/dotnet/repos");
            var repositories = serializer.ReadObject(await streamTask) 
                as List<Repository>;

            return repositories;
        }
    }
}
