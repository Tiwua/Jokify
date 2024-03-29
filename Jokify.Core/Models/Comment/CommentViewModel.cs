﻿namespace Jokify.Core.Models.Comment
{
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommentViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; } = null!;

        public string User { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public bool IsUserOwner { get; set; }
        public bool IsEdited { get; set; }
    }
}
