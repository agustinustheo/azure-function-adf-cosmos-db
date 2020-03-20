using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace azure_adf_event_hub
{
    public static class TransferToHub
    {
        [FunctionName("TransferToHub")]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [EventHub("EventHubName", Connection = "EventHubConnection")] IAsyncCollector<string> output,
            ILogger log)
        {
            // Get request content
            string jsonContent = await new StreamReader(req.Body).ReadToEndAsync();

            // Parse JSON and pass document
            await output.AddAsync(jsonContent);
        }
    }
}
