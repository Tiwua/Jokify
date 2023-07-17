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
            Comments = new HashSet<CommentViewModel>();
            CurrentPage = 1;
            PageSize = 3;
            HasUserCommented = false;
        }

        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Setup { get; set; } = null!;

        public string Punchline { get; set; } = null!;

        public string OwnerName { get; set; } = null!;

        public string CurrUser { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public bool IsEdited { get; set; }

        public bool HasUserCommented { get; set; }

        public bool HasLiked { get; set; }

        public bool HasCreatedComment { get; set; }

        [Display(Name = "Likes")]
        public int LikesCount { get; set; }

        [StringLength(CommentContentMaxValue, MinimumLength = CommentContentMinValue)]
        public string CommentContent { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalComments { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
