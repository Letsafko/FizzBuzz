using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Peer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeerController : ControllerBase
    {
        private readonly ILogger<PeerController> _logger;
        public PeerController(ILogger<PeerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/test")]
        public async Task<ActionResult<string>> FizzBuzz([FromServices] IFizzBuzz fizzBuzz)
        {
            var result = await fizzBuzz.CalculateResultAsync();
            return $"Result: {result}";
        }

        [HttpGet]
        public  ActionResult<string> FizzBuzz()
        {
            var rand = new Random().Next(2);
            if (rand == 0)
            {
                return $"{new Random().Next(100)}:{new Random().Next(100)}";
            }
            return $"{new Random().Next(100)}:{new Random().Next(100)}:{new Random().Next(100)}";
        }
    }
}
