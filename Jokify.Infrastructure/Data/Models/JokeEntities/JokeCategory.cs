namespace Jokify.Infrastructure.Data.Models.JokeEntities
{
    using System.ComponentModel.DataAnnotations;
    using static Jokify.Infrastructure.Common.DataConstants.Joke;

    public class JokeCategory
    {
        public JokeCategory()
        {
            Jokes = new HashSet<Joke>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(JokeCategoryMaxValue)]
        public string Name { get; set; } = null!;

        public ICollection<Joke> Jokes { get; set; }
    }
}