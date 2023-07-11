namespace Jokify.Core.Contracts
{
    public interface ILikeService
    {
        Task<bool> HasLikedJoke(string jokeId, string userId);

        Task LikeJokeAsync(Guid id, string userId);
    }
}
