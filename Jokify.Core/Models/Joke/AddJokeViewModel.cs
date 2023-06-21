namespace Jokify.Core.Models.Joke
{
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using static Jokify.Infrastructure.Common.DataConstants.Joke;

    public class AddJokeViewModel
    {
        public AddJokeViewModel()
        {
            Categories = new HashSet<JokeCategoryViewModel>();
        }

        [Required]
        [StringLength(JokeTitleMaxValue)]
        public string Title { get; set; } = null!;

        public string Setup { get; set; } = null!;

        public string Punchline { get; set; } = null!;

        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<JokeCategoryViewModel> Categories { get; set; }
    }
}
