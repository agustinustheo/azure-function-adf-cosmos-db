#r "Newtonsoft.Json"

using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;

public class OutputBase
{
    public string Content { get; set; }
    public OutputBase(string Content){
        this.Content = Content;
    }
    public HttpResponseMessage Success(){
        string jsonToReturn = "{\"Content\": "+this.Content+", \"Status\":\"Success\", \"Code\":200}";
        return new HttpResponseMessage(HttpStatusCode.OK) {
            Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
        };
    }
    public HttpResponseMessage Failed(){
        string jsonToReturn = "{\"Status\":\"Failed\", \"Code\":400}";
        return new HttpResponseMessage(HttpStatusCode.OK) {
            Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
        };
    }
}
