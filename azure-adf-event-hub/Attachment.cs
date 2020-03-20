using Newtonsoft.Json;

namespace azure_adf_event_hub
{
    public class Attachment
    {
        [JsonProperty("Path")]
        public string Path { get; set; }
    }
}
