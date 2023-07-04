namespace Jokify.Models
{
    using Jokify.Core.Models.Joke;
    using Jokify.Core.Models.Joke.Enums;

    public class AllJokesQueryModel
    {
        public AllJokesQueryModel()
        {
            this.Categories = Enumerable.Empty<string>();
            this.Jokes = Enumerable.Empty<JokeServiceModel>();
        }

        public const int JokesPerPage = 6 ;

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public JokeSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalJokesCount { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<JokeServiceModel> Jokes { get; set; }
    }
}
