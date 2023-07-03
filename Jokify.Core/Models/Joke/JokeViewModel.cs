namespace Jokify.Core.Models.Joke
{
    using Jokify.Core.Models.Comment;
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using System.Collections.Generic;

    public class JokeViewModel
    {
        public JokeViewModel()
        {
            //this.Comments = new HashSet<CommentViewModel>();
        }

        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Setup { get; set; } = null!;

        public string Punchline { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Owner { get; set; } = null!;

        //public IEnumerable<CommentViewModel> Comments { get; set; }

        public int LikesCount { get; set; }

    }
}
