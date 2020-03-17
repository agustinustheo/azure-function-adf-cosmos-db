using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTriggerCSharpProject
{
    public class Attachment
    {
        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
