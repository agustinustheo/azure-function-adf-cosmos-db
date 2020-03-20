using Newtonsoft.Json;

namespace azure_event_hub
{
    public class Attachment
    {
        [JsonProperty("Path")]
        public string Path { get; set; }
    }
}
