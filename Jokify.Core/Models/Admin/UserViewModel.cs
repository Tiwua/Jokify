namespace Jokify.Core.Models.Admin
{
    public class UserViewModel
    {
        public string UserId { get; init; } = null!;

        public string Username { get; set; } = null!;

        public string Email { get; init; } = null!;

        public bool IsDeleted { get; set; }

        public bool IsForgotten { get; set; }
    }
}
