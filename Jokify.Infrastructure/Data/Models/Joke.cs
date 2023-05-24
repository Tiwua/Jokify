namespace Jokify.Infrastructure.Data.Models
{
    using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

    public class Joke
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Setup { get; set; } = null!;

        [Required]
        public string Punchline { get; set; } = null!;

        public bool Deleted { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int JokeCategoryId { get; set; }
        public JokeCategory Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Type))]
        public int JokeTypeId { get; set; }
        public JokeType Type { get; set; } = null!;


    }
}
