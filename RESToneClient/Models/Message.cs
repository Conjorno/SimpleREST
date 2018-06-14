using System;
using System.Collections.Generic;
using System.Text;

namespace RESToneClient.Models
{
    public class Message
    {
        public int id { get; set; }
        public string recipient { get; set; }
        public string content { get; set; }
    }
}
