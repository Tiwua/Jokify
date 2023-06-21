namespace Jokify.Core.Models.User
{
	using System.ComponentModel.DataAnnotations;

	using static Jokify.Common.DataConstants.DisplayConstants;
	using static Jokify.Common.DataConstants.User;

	public class RegisterViewModel
    {

		[Required]
		[Display(Name = UsernameDisplay)]
		[StringLength(UserNameMaxValue, MinimumLength = UserNameMinValue)]
		public string UserName { get; set; } = null!;

		[Required]
		[EmailAddress]
		[StringLength(EmailMaxValue, MinimumLength = EmailMinValue)]
		public string Email { get; set; } = null!;

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Required]
		[Compare(nameof(Password))]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; } = null!;
	}
}
