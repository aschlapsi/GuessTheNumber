using Microsoft.AspNetCore.Mvc;

namespace GuessTheNumber.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpPost]
        public GameDTO CreateGame(StartGameRequest startGameRequest)
        {
            var rangeMax = startGameRequest.DifficultyLevel == "Hard"
                ? 100
                : startGameRequest.DifficultyLevel == "Medium" ? 50 : 20;
 
            return new GameDTO
            {
                Id = 1,
                RangeMin = 1,
                RangeMax = rangeMax,
            };
        }
    }
}
