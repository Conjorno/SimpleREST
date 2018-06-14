using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTone.Models;

namespace RESTone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        List<Message> _messages;

        public MessageController()
        {
            _messages = new List<Message>();
            _messages.Add(new Message { Id = 1, Recipient = "Joachim", Content = "Witaj stary druchu!" });
            _messages.Add(new Message { Id = 2, Recipient = "Oktawian", Content = "Kopę lat mój rogi Joachimie..." });
        }

        // GET: api/Message
        [HttpGet(Name = "GetAll")]
        public IEnumerable<Message> Get()
        {
            return _messages;
        }

        // GET: api/Message/5
        [HttpGet("{id}", Name = "GetMessage")]
        public Message Get(int id)
        {
            return _messages.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
