namespace Jokify.Core.Services.Admin
{
    using HouseRentingSystem.Infrastructure.Data.Common;
    using Jokify.Core.Contracts.Admin;
    using Jokify.Core.Models.Admin;
    using Jokify.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static Jokify.Core.Common.Constants.Page;
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UserViewModel[]> AllUsersAsync(string userId)
        {
            var users = await repository.AllReadonly<User>()
                .Where(u => u.Id != userId)
                .Select(u => new UserViewModel()
            {
                UserId = u.Id,
                Email = u.Email,
                IsDeleted = u.IsDeleted,
                Username = u.UserName
            }).ToArrayAsync();

            return users;
        }

        public UserPageModel AllUsersPaginated(UserViewModel[] users, int currentPage)
        {                               
            var paginatedUsers = users.Skip((currentPage - 1) * UsersPerPage)
                .Take(UsersPerPage)
                .ToHashSet();

            var result = paginatedUsers.Select(u => new UserPageModel
            {
                CurrentPage = currentPage,
                PageSize = UsersPerPage,
                TotalUsers = users.Length,
                TotalPages = (int)Math.Ceiling((double)users.Length / UsersPerPage),
                Users = paginatedUsers
            }).First();

            return result;
        }
    }
}
