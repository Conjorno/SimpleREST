using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesClient.Models
{
    public class MessageModel
    {
        public int id { get; set; }
        public string recipient { get; set; }
        public string content { get; set; }
    }
}
