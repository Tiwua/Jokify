namespace Jokify.Infrastructure.Data.Models
{
    using Jokify.Infrastructure.Data.Models.JokeEntities;
    using Jokify.Infrastructure.Data.Models.MappingTables;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Jokify.Infrastructure.Common.DataConstants.User;

    public class User : IdentityUser
	{
        public User()
        {
            FavoriteJokes = new HashSet<UserFavoriteJoke>();
            CreatedJokes = new HashSet<UserJoke>();
            CreatedComments = new HashSet<Comment>();
            IsDeleted = false;
        }

        [Required]
        [MaxLength(UserNameMaxValue)]
        public override string UserName 
        { 
            get => base.UserName; 
            set => base.UserName = value;
        }

        [Required]
        [MaxLength(EmailMaxValue)]
        public override string Email 
        { 
            get => base.Email;
            set => base.Email = value; 
        }

        public bool IsDeleted { get; set; }


        public ICollection<Comment> CreatedComments { get; set; }

        public ICollection<UserFavoriteJoke> FavoriteJokes { get; set; }

        public ICollection<UserJoke> CreatedJokes { get; set; }
    }
}
