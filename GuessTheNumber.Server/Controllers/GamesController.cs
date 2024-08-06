using Microsoft.AspNetCore.Mvc;

namespace GuessTheNumber.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpPost]
        public GameDTO CreateGame()
        {
            return new GameDTO
            {
                Id = 1,
                RangeMin = 1,
                RangeMax = 20,
            };
        }
    }
}
