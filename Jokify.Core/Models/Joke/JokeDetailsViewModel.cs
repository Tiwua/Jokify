namespace Jokify.Core.Models.Joke
{
    using Jokify.Core.Models.Comment;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Jokify.Infrastructure.Common.DataConstants.Comment;

    public class JokeDetailsViewModel
    {
        public JokeDetailsViewModel()
        {
            this.Comments = new HashSet<CommentViewModel>();
        }

        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Setup { get; set; } = null!;

        public string Punchline { get; set; } = null!;

        public string OwnerName { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public bool IsEdited { get; set; }

        public bool IsPopular { get; set; }

        [Display(Name = "Likes")]
        public int LikesCount { get; set; }

        [StringLength(CommentContentMaxValue, MinimumLength = CommentContentMinValue)]
        public string? CommentContent { get; set; }

        public ICollection<CommentViewModel>  Comments { get; set; }
    }
}
