﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTone.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Recipient { get; set; }
        public string Content { get; set; }
    }
}
