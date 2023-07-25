namespace Jokify.Core.Models.Admin
{
    public class UserPageModel
    {
        public UserPageModel()
        {
            CurrentPage = 1;
            PageSize = 2;
            this.Users = new HashSet<UserViewModel>();
        }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalUsers { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
