#r "Newtonsoft.Json"

#load "ToDoItem.csx"
#load "OutputBase.csx"

using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

public static async Task<HttpResponseMessage> Run(HttpRequest req, ILogger log, IAsyncCollector<ToDoItem> outputDocument)
{
    // Get request content
    string jsonContent = await new StreamReader(req.Body).ReadToEndAsync();
    OutputBase output = new OutputBase(jsonContent);

    // Parse JSON and create document
    ToDoItem data = JsonConvert.DeserializeObject<ToDoItem>(jsonContent);
    await outputDocument.AddAsync(data);
    
    if (data.ID !=" " ){
        return output.Success();
    }
    return output.Failed();
}
