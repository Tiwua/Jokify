﻿namespace Jokify.Core.Models.Comment
{
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommentViewModel
    {
        public string Content { get; set; } = null!;

        public string User { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

    }
}
