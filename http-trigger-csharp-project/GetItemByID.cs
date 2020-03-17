using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpTriggerCSharpProject
{
    public static class GetItemByID
    {
        [FunctionName("GetItemByID")]
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
            Uri DataUri = UriFactory.CreateDocumentUri("ToDoList", "Items", NewData.ID);;

            // Get new data from document
            Document DocumentToBeUpdated = Client.ReadDocumentAsync(DataUri).Result.Resource;
            ToDoItem TempData = new ToDoItem();
            TempData.GetFromDocument(DocumentToBeUpdated);

            // Return retrieved document
            return new OkObjectResult(TempData);
        }
    }
}
