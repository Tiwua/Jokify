namespace Jokify.Core.Models.User
{
	using System.ComponentModel.DataAnnotations;

	public class RegisterViewModel
    {
        public string Password { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
