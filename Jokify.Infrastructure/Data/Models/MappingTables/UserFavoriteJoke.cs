namespace Jokify.Infrastructure.Data.Models.MappingTables
{
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserFavoriteJoke
    {
        // Composite primary key
        [Required]
        [Comment("Primary key refering user's liked joke")]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [Required]
        [Comment("Primary key refering the joke")]
        [ForeignKey(nameof(Joke))]
        public Guid JokeId { get; set; }


        // Navigation properties
        [Comment("Navigation User property")]
        public User User { get; set; } = null!;

        [Comment("Navigation Joke property")]
        public Joke Joke { get; set; } = null!;
    }
}
