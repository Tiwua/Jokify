namespace Jokify.Core.Models.User
{
	using System.ComponentModel.DataAnnotations;

    using static Jokify.Common.JokeDataEntitiesConstants.Error;
    using static Jokify.Common.JokeDataEntitiesConstants.DisplayConstants;
	public class LoginViewModel
    {
        [Required(ErrorMessage = InvalidUserNameErrorMsg)]
        [Display(Name = UsernameDisplay)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = InvalidPassswordErrorMsg)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
