using Microsoft.Azure.Documents;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace azure_adf_event_hub
{
    public class ToDoItem
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("PIC")]
        public string PIC { get; set; }
        [JsonProperty("Attachments")]
        public List<Attachment> Attachments { get; set; }
        [JsonProperty("IsComplete")]
        public int IsComplete { get; set; }
        public void GetFromDocument(Document document)
        {
            this.ID = document.GetPropertyValue<string>("id");
            this.Description = document.GetPropertyValue<string>("description");
            this.PIC = document.GetPropertyValue<string>("pic");
            this.Attachments = document.GetPropertyValue<List<Attachment>>("attachments");
            this.IsComplete = document.GetPropertyValue<int>("isComplete");
        }
    }
}
