namespace Jokify.Infrastructure.Data.Models.JokeEntities
{
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Jokify.Infrastructure.Common.DataConstants.Joke;

    [Comment("Joke for the WebApp")]
    public class Joke
    {
        public Joke()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            IsEdited = false;
            IsPopular = false;
            this.FavoriteJokes = new HashSet<UserFavoriteJoke>();
            this.JokeComments = new HashSet<JokeComment>();
        }

        [Key]
        [Comment("Primary Key")]
        public Guid Id { get; set; }


        [Required]
        [MaxLength(JokeTitleMaxValue)]
        [Comment("Title of the joke")]
        public string Title { get; set; } = null!;


        [Required]
        [MaxLength(JokeSetupMaxValue)]
        [Comment("Introduction part of the joke")]
        public string Setup { get; set; } = null!;


        [Required]
        [MaxLength(JokePunchlineMaxValue)]
        [Comment("Funniest part of the joke")]
        public string Punchline { get; set; } = null!;



        [Comment("Delete flag that shows if the joke has been deleted")]
        public bool IsDeleted { get; set; }


        [Comment("Edit flag that shows if the joke has been edited")]
        public bool IsEdited { get; set; }


        [Comment("Popular flag that shows if the joke is popular")]
        public bool IsPopular { get; set; }


        [Required]
        [Comment("Foreign Key referencing JokeCategory")]
        [ForeignKey(nameof(Category))]

        public int JokeCategoryId { get; set; }
        [Comment("Category of the joke")]
        public JokeCategory Category { get; set; } = null!;


        [Required]
        [Comment("Foreign Key referencing User")]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [Comment("Creator of the joke")]
        public User User { get; set; } = null!;

        //Collections
        public IEnumerable<UserFavoriteJoke> FavoriteJokes { get; set; }
        public IEnumerable<JokeComment> JokeComments { get; set; }
    }
}
