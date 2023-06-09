namespace Jokify.Infrastructure.Data.Models.Joke
{
    using static Jokify.Common.JokeDataModelConstants.Joke;
    using System.ComponentModel.DataAnnotations;

    public class JokeCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(JokeCategoryMaxValue)]
        public string Name { get; set; } = null!;
    }
}