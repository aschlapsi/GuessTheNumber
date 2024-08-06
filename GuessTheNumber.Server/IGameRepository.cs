namespace GuessTheNumber.Server
{
    public interface IGameRepository
    {
        int NextId();
        Task Create(Game game);
        Task<Game> Get(int id);
    }
}
