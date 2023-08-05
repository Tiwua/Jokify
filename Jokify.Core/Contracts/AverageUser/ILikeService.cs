namespace Jokify.Core.Contracts
{
    public interface ILikeService
    {
        Task<bool> HasLikedJoke(string title, string userId);

        Task LikeJokeAsync(Guid id, string userId);

        Task DislikeJokeAsync(Guid id, string userId);

        Task<int> GetLikesCount(Guid id);
    }
}
