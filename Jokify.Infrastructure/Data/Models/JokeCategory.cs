namespace Jokify.Infrastructure.Data.Models
{
	using Jokify.Common;
	using System.ComponentModel.DataAnnotations;

    public class JokeCategory
    {
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(JokeDataModelConstants.JokeCategoryMaxValue)]
		public string Name { get; set; } = null!;
	}
}
