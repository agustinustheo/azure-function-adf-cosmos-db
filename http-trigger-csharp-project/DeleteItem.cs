using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;

namespace HttpTriggerCSharpProject
{
    public static class DeleteItem
    {
        [FunctionName("DeleteItem")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequestMessage req,
            [CosmosDB(
                databaseName: "ToDoList",
                collectionName: "Items",
                ConnectionStringSetting = "CosmosDBConnection"
            )] DocumentClient client)
        {
            // Get request content and parse JSON
            var content = req.Content;
            string jsonContent = content.ReadAsStringAsync().Result;
            ToDoItem newData = JsonConvert.DeserializeObject<ToDoItem>(jsonContent);

            // Get document link
            Uri deletedUri = UriFactory.CreateDocumentUri("ToDoList", "Items", newData.ID);
            if (deletedUri == null)
            {
                return new NotFoundObjectResult($"Data with id {newData.ID}, not found!");
            }

            // Delete document
            await client.DeleteDocumentAsync(deletedUri);
            return new OkObjectResult("Data deleted!");
        }
    }
}
