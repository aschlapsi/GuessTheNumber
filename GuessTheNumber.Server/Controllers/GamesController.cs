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

        [HttpPost("{gameId:int}")]
        public async Task<GuessNumberResult> GuessNumber(int gameId, GuessNumberRequest guessNumberRequest)
        {
            var game = await _repository.Get(gameId);
            return new GuessNumberResult
            {
                Message = GetMessage(game.Guess(guessNumberRequest.Number))
            };
        }

        private string GetMessage(Game.GuessResult guessResult)
        {
            switch (guessResult)
            {
                case Game.GuessResult.TooLow:
                    return "too low";
                case Game.GuessResult.TooHigh:
                    return "too high";
                default:
                    return "correct";
            }
        }
    }
}
