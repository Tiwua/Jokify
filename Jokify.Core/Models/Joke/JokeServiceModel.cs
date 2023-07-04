namespace Jokify.Core.Models.Joke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JokeServiceModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Setup { get; set; } = null!;

        public string Punchline { get; set; } = null!;

        public bool IsPopular { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsEdited { get; set; }
    }
}
