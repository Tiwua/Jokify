namespace Jokify.Core.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommentService
    {
        public Task AddCommentToJokeAsync(string title, string commentContent, string userId);

        public Task<bool> HasUserCommentedAsync(string title, string userId);
    }
}
