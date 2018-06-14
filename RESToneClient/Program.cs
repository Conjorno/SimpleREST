using RESToneClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace RESToneClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ProcessRepositories().Wait();
            Console.ReadKey();
        }

        private static async Task ProcessRepositories()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Message>));

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("http://localhost:51985/api/MessageDict/GetAllDict");
            var repositories = serializer.ReadObject(await streamTask) as List<Message>;

            foreach (var repo in repositories)
                Console.WriteLine(repo.content);
        }
    }
}
