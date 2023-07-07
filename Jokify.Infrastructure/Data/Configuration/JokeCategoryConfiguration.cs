namespace Jokify.Infrastructure.Data.Configuration
{
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class JokeCategoryConfiguration : IEntityTypeConfiguration<JokeCategory>
	{
		public void Configure(EntityTypeBuilder<JokeCategory> builder)
		{
			builder.HasData(SeedCategories());
		}

		private static HashSet<JokeCategory> SeedCategories()
		{
            var categories = new HashSet<JokeCategory>
			{
				new JokeCategory
				{
					Id = 1,
					Name = "One-Liner"
				},

				new JokeCategory
				{
					Id = 2,
					Name = "Pun"
				},
				new JokeCategory
				{
					Id = 3,
					Name = "Knock-knock"
				},
				new JokeCategory
				{
					Id = 4,
					Name = "Wordplay"
				},
				new JokeCategory
				{
					Id = 5,
					Name = "Riddle"
				},
				new JokeCategory
				{
					Id = 6,
					Name = "Observational"
				},
				new JokeCategory
				{
					Id = 7,
					Name = "Dad joke"
				},
				new JokeCategory
				{
					Id = 8,
					Name = "Dark humor"
				},
			};

			return categories;
		}
	}
}
