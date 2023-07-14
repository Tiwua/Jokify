﻿namespace Jokify.Core.Models.Joke
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

    public class JokeViewModel
    {
        public JokeViewModel()
        {
            Categories = new HashSet<JokeCategoryViewModel>();
        }

        [Required]
        [StringLength(JokeTitleMaxValue, MinimumLength = JokeTitleMinValue)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(JokeSetupMaxValue, MinimumLength = JokeSetupMinValue)]
        public string Setup { get; set; } = null!;

        [Required]
        [StringLength(JokePunchlineMaxValue, MinimumLength = JokePunchlineMinValue)]
        public string Punchline { get; set; } = null!;

        [Range(IntegerIdMinValue, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<JokeCategoryViewModel> Categories { get; set; }
    }
}
