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

    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<UserViewModel>> AllUsersAsync()
        {
            var users = await repository.AllReadonly<User>()
                .Select(u => new UserViewModel()
            {
                UserId = u.Id,
                Email = u.Email,
                IsDeleted = u.IsDeleted,
                Username = u.UserName
            }).ToListAsync();

            return users;
        }
    }
}
