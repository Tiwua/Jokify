namespace Jokify.Core.Models.Comment
{
    using Jokify.Core.Models.Joke;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JokeAndCommentViewModel
    {
        public CommentViewModel Comment { get; set; } = null!;

        public JokeDetailsViewModel Joke { get; set; } = null!;
    }
}
