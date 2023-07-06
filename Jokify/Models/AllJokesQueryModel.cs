namespace Jokify.Models
{
    using Jokify.Core.Models.Joke;
    using Jokify.Core.Models.Joke.Enums;

    public class AllJokesQueryModel
    {
        public AllJokesQueryModel()
        {
            this.JokesPerPage = 6;
            this.CurrentPage = 1;

            this.Categories = Enumerable.Empty<string>();
            this.Jokes = Enumerable.Empty<JokeServiceModel>();
        }

        public int JokesPerPage { get; set; }

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public JokeSorting Sorting { get; set; }

        public int CurrentPage { get; set; }

        public int TotalJokesCount { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<JokeServiceModel> Jokes { get; set; }
    }
}
