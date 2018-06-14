using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RESTone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        // GET: api/Hello
        [HttpGet]
        public string Get()
        {
            return "WITAJ ŚWIECIE";
        }

        // GET: api/Hello/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "Witaj, echo: " + id;
        }
    }
}
