﻿namespace Jokify.Core.Models.Comment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommentViewModel
    {
        public string Content { get; set; } = null!;

        public string Owner { get; set; } = null!;
    }
}