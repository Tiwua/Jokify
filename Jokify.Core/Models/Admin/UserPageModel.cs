namespace Jokify.Core.Models.Admin
{
    public class UserPageModel
    {
        public bool IsForgotten { get; set; } = false;

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalUsers { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; } = new HashSet<UserViewModel>();
    }
}
