namespace Jokify.Infrastructure.Data.Models.JokeEntities
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class JokeComment
    {
        // Composite primary key
        [Required]
        [Comment("Primary key refering comment of the joke")]
        [ForeignKey(nameof(Comment))]
        public Guid CommentId { get; set; }

        [Required]
        [Comment("Primary key refering the joke")]
        [ForeignKey(nameof(Joke))]
        public Guid JokeId { get; set; }


        // Navigation properties
        [Comment("Navigation User property")]
        public Comment Comment { get; set; } = null!;

        [Comment("Navigation Joke property")]
        public Joke Joke { get; set; } = null!;
    }
}
