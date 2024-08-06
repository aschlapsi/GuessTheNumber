using Microsoft.AspNetCore.Mvc;

namespace GuessTheNumber.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly Random _random;
        private readonly IGameRepository _repository;

        public GamesController(IGameRepository repository, Random? random = null)
        {
            _repository = repository;
            _random = random ?? new Random();
        }

        [HttpPost]
        public GameDTO StartGame(StartGameRequest startGameRequest)
        {
            var game = Game.Start(1, startGameRequest.ToDifficultyLevel(), _random);
            _repository.Create(game);
            return game.ToDTO();
        }
    }
}
