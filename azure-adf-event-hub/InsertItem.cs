using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace azure_adf_event_hub
{
    public static class InsertItem
    {
        [FunctionName("InsertItem")]
        public static void Run([EventHubTrigger("EventHubName", Connection = "EventHubConnection")] string triggerContent,
            [CosmosDB(
                databaseName: "ToDoList",
                collectionName: "Items",
                ConnectionStringSetting = "CosmosDBConnection"
            )] out ToDoItem newData,
            ILogger log)
        {
            var exceptions = new List<Exception>();
            newData = JsonConvert.DeserializeObject<ToDoItem>(triggerContent);
        }
    }
}
