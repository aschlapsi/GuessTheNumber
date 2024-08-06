namespace GuessTheNumber.Server
{
    public interface IGameRepository
    {
        Task Create(Game game);
    }
}
