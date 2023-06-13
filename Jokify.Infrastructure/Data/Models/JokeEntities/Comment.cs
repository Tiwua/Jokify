namespace Jokify.Infrastructure.Data.Models.JokeEntities
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Jokify.Common.JokeDataEntitiesConstants.Comment;

    [Comment("Joke comment")]
    public class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid();
            this.IsPopular = false;
            this.IsEdited = false;
            this.IsDeleted = false;
            this.JokeComments = new List<JokeComment>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(CommentContentMaxValue)]
        public string Content { get; set; } = null!;


        [Comment("Delete flag that shows if the comment has been deleted")]
        public bool IsDeleted { get; set; }


        [Comment("Edit flag that shows if the comment has been edited")]
        public bool IsEdited { get; set; }


        [Comment("Popular flag that shows if the comment is popular")]
        public bool IsPopular { get; set; }

        public ICollection<JokeComment> JokeComments { get; set; }
    }
}
