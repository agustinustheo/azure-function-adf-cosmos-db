#r "Newtonsoft.Json"
#load "Attachment.csx"

using System;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

public class ToDoItem
{
    public string ID { get; set; }
    public string Description { get; set; }
    public string PIC { get; set; }
    public List<Attachment> Attachments { get; set; }
    public bool IsComplete { get; set; }
}