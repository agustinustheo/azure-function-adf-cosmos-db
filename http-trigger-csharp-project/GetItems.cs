using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HttpTriggerCSharpProject
{
    public static class GetItems
    {
        [FunctionName("GetItems")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "ToDoList",
                collectionName: "Items",
                ConnectionStringSetting = "CosmosDBConnection",
                SqlQuery = "SELECT * FROM Items"
            )] IEnumerable<ToDoItem> toDoItems,
            ILogger log)
        {
            // Return request items
            return new OkObjectResult(toDoItems);
        }
    }
}
