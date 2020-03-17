using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpTriggerCSharpProject
{
    public static class UpdateItem
    {
        [FunctionName("UpdateItem")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequestMessage Req,
            [CosmosDB(
                databaseName: "ToDoList",
                collectionName: "Items",
                ConnectionStringSetting = "CosmosDBConnection"
            )] DocumentClient Client)
        {
            // Get request content and parse JSON
            var Content = Req.Content;
            string JsonContent = Content.ReadAsStringAsync().Result;
            ToDoItem NewData = JsonConvert.DeserializeObject<ToDoItem>(JsonContent);

            // Get document link
            Uri DataUri = UriFactory.CreateDocumentUri("ToDoList", "Items", NewData.ID);
            if (DataUri == null)
            {
                return new NotFoundObjectResult($"Data with id {NewData.ID}, not found!");
            }

            // Delete document
            await Client.DeleteDocumentAsync(DataUri);
            // Create document
            await Client.CreateDocumentAsync("dbs/ToDoList/colls/Items", NewData);
            
            // Get new data from document
            //Document DocumentToBeUpdated =  client.ReadDocumentAsync(DataUri).Result.Resource;
            //ToDoItem TempData = new ToDoItem();
            //NewData.GetFromDocument(DocumentToBeUpdated);


            return new OkObjectResult("Data updated!");
        }
    }
}
