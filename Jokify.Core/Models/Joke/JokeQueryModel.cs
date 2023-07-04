namespace Jokify.Core.Models.Joke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JokeQueryModel
    {
        public JokeQueryModel()
        {
            this.Jokes = new HashSet<JokeServiceModel>();
        }

        public int JokesCount { get; set; }

        public IEnumerable<JokeServiceModel> Jokes { get; set; }
    }
}
