namespace Jokify.Infrastructure.Data.Models.JokeEntities
{
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Like
    {
        public Like()
        {
            UsersFavoriteJokes = new HashSet<UserFavoriteJoke>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Foreign Key referencing Joke")]
        [ForeignKey(nameof(Joke))]
        public Guid JokeId { get; set; }

        [Comment("Joke to be liked")]
        public Joke Joke { get; set; } = null!;

        [Required]
        [Comment("Foreign Key referencing the User")]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [Comment("The User liking a joke")]
        public User User { get; set; } = null!;

        public ICollection<UserFavoriteJoke> UsersFavoriteJokes { get; set; }
    }
}
