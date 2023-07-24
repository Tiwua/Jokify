namespace Jokify.Core.Contracts.Admin
{
    using Jokify.Core.Models.Admin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> AllUsersAsync();
    }
}
