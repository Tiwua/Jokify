﻿namespace Jokify.Infrastructure.Data.Models.JokeEntities
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
            IsPopular = false;
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


        [Comment("Popular flag that shows if the comment is popular")]
        public bool IsPopular { get; set; }

        [Comment("Date of creation")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Joke))]
        public Guid JokeId { get; set; }
        public Joke Joke { get; set; } = null!;
    }
}
