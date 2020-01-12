using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SheduleParser;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SheduleController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            var shedule = await Parser.Parse();
            return shedule;
        }

        [HttpGet("{groupName}")]
        public async Task<string> Get(string groupName)
        {
            var shedule = await Parser.Parse(groupName);
            return shedule;
        }
    }
}
