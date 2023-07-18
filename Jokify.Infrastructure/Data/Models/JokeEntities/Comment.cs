namespace Jokify.Infrastructure.Data.Models.JokeEntities
{
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Jokify.Infrastructure.Common.DataConstants.Comment;

    [Comment("Joke comment")]
    public class Comment
    {
        public Comment()
        {
            Id = Guid.NewGuid();
            IsEdited = false;
            IsDeleted = false;
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


        [Comment("Date of creation")]
        public DateTime CreatedOn { get; set; }


        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }


        [ForeignKey(nameof(Joke))]
        public Guid? JokeId { get; set; }
        public Joke? Joke { get; set; }
    }
}
