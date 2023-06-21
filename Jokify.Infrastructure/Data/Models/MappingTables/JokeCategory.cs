namespace Jokify.Infrastructure.Data.Models.MappingTables
{
    using System.ComponentModel.DataAnnotations;
    using static Jokify.Common.DataConstants.Joke;

    public class JokeCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(JokeCategoryMaxValue)]
        public string Name { get; set; } = null!;
    }
}