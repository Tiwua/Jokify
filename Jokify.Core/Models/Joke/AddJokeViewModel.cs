namespace Jokify.Core.Models.Joke
{
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddJokeViewModel
    {
        public AddJokeViewModel()
        {
            this.Categories = new HashSet<JokeCategoryViewModel>();
        }

        public string Setup { get; set; } = null!;

        public string Punchline { get; set; } = null!;

        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<JokeCategoryViewModel> Categories { get; set; }
    }
}
