using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        #region User
        Task<IQueryable<User>> GetAllUsersAsync();
        Task<User> GetUserByUserIdAsync(int UserId);
        Task<int?> GetUserIdByUsernameAsync(string Username);
        Task<bool> IsPasswordCorrectByIdAsync(int UserId, string Pw);
        Task DeleteUserByIdAsync(int UserId);
        Task AddUserAsync(UserModel user);
        Task EditUserByIdAsync(int UserId, UserModel um);
        Task<string> GetLevelByUserIdAsync(int UserId);

        #endregion

    }
}
