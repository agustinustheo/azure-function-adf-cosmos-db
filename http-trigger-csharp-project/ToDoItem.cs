using Microsoft.Azure.Documents;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HttpTriggerCSharpProject
{
    public class ToDoItem
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("pic")]
        public string PIC { get; set; }
        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; }
        [JsonProperty("isComplete")]
        public bool IsComplete { get; set; }
        public void GetFromDocument(Document document)
        {
            this.ID = document.GetPropertyValue<string>("id");
            this.Description = document.GetPropertyValue<string>("description");
            this.PIC = document.GetPropertyValue<string>("pic");
            this.Attachments = document.GetPropertyValue<List<Attachment>>("attachments");
            this.IsComplete = document.GetPropertyValue<bool>("isComplete");
        }
    }
}
