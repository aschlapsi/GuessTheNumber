using Microsoft.AspNetCore.Mvc;

namespace GuessTheNumber.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpPost]
        public GameDTO StartGame(StartGameRequest startGameRequest)
        {
            var game = Game.Start(1, startGameRequest.ToDifficultyLevel());
            return game.ToDTO();
        }
    }
}
