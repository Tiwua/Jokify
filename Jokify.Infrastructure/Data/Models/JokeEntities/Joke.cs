namespace Jokify.Infrastructure.Data.Models.Joke
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //Comment, Like, Dislike, Rating
    public class Joke
    {
        public Joke()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Setup { get; set; } = null!;

        [Required]
        public string Punchline { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public bool IsPopular { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int JokeCategoryId { get; set; }
        public JokeCategory Category { get; set; } = null!;

    }
}
