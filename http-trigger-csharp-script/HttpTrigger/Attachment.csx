#r "Newtonsoft.Json"

using System;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Attachment
{
    [JsonProperty("path")]
    public string Path { get; set; }
}