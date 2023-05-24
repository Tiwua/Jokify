namespace Jokify.Infrastructure.Data
{
	using Jokify.Common;
	using System.ComponentModel.DataAnnotations;

	public class JokeType
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(JokeDataModelConstants.JokeTypeMaxValue)]
        public string Name { get; set; } = null!;

    }
}