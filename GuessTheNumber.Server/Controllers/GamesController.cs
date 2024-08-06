using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuessTheNumber.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateGame()
        {
            return Ok();
        }
    }
}
