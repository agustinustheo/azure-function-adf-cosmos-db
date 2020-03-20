using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace HttpTriggerCSharpProject
{
    public static class InsertItem
    {
        [FunctionName("InsertItem")]
        public static HttpResponseMessage Run(
            [EventHubTrigger("entytysh", Connection = "ifenhab")] string eventSingular,
            [CosmosDB(
                databaseName: "ToDoList",
                collectionName: "Items",
                ConnectionStringSetting = "CosmosDBConnection"
            )] out ToDoItem newData,
            ILogger log)
        {
            // Get request content
            var content = req.Content;
            string jsonContent = content.ReadAsStringAsync().Result;

            // Parse JSON and create document
            newData = JsonConvert.DeserializeObject<ToDoItem>(jsonContent);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
