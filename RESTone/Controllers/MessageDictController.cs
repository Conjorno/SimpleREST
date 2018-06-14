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
    public class MessageDictController : ControllerBase
    {
        static Dictionary<int, Message> _messages = new Dictionary<int, Message>();

        // GET: api/MessageDict
        [HttpGet]
        [Route("GetAllDict")]
        public IEnumerable<Message> Get()
        {
            if(_messages.Count == 0)
            {
                _messages.Add(1, new Message { Id = 1, Recipient = "Joachim", Content = "Witaj stary druchu!" });
                _messages.Add(2, new Message { Id = 2, Recipient = "Oktawian", Content = "Kopę lat mój rogi Joachimie..." });
            }
            return _messages.Values;
        }

        // GET: api/MessageDict/5
        [HttpGet]
        [Route("GetDict/{id}")]
        public Message Get([FromQuery]int id)
        {
            return _messages[id];
        }

        // POST: api/MessageDict
        [HttpPost]
        public void Post([FromBody] Message message)
        {
            message.Id = _messages.Count + 1;
            _messages.TryAdd(_messages.Count + 1, message);
        }

        // PUT: api/MessageDict/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Message message)
        {
            message.Id = id;
            _messages[id] = message;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _messages.Remove(id);
        }

        [HttpGet]
        [Route("getContext")]
        public string GetContext()
        {
            return HttpContext.Request.Path.Value;
        }
    }
}
