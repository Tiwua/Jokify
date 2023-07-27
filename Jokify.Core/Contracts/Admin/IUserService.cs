namespace Jokify.Core.Contracts.Admin
{
    using Jokify.Core.Models.Admin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
	using System.Security.Claims;
	using System.Text;
    using System.Threading.Tasks;
    
    public interface IUserService
    {
        Task<UserViewModel[]> AllUsersAsync(string userId);

        UserPageModel AllUsersPaginated(UserViewModel[] users, int page);

		Task DeleteUserAsync(string id);

		Task<bool> ForgetUserAsync(string id);
		
	}
}
