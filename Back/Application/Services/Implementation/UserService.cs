using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Azure;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Implementation
{
    public class UserService : IUserService
    {

        private readonly dbDataContext _context;

        public UserService(dbDataContext context)
        {
            _context = context;
        }


        public async Task<IQueryable<User>> GetAllUsersAsync()
        => _context.Users;

        public async Task<User?> GetUserByUserIdAsync(int UserId)
        => await _context.Users.FirstOrDefaultAsync(u => u.ID == UserId);
        public async Task DeleteUserByIdAsync(int UserId)
        {
            try
            {
                var user = await _context.Users.FindAsync(UserId);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task AddUserAsync(UserModel user)
        {
            await _context.Users.AddAsync(new User()
            {
                UserName = user.UserName,
                Password = user.Password,
                LevelID = user.LevelID,
                UserImgAddress = user.UserImgAddress
            });
            await _context.SaveChangesAsync();
        }
        public async Task EditUserByIdAsync(int UserId, UserModel um)
        {
            var user = await _context.Users.FindAsync(UserId);
            user.UserName = um.UserName;
            user.Password = um.Password;
            user.LevelID = um.LevelID;
            user.UserImgAddress = um.UserImgAddress;
            await _context.SaveChangesAsync();
        }

        public async Task<int?> GetUserIdByUsernameAsync(string Username)
        => await _context.Users.Where(u => u.UserName == Username).Select(u => u.ID).FirstOrDefaultAsync();

        public async Task<bool> IsPasswordCorrectByIdAsync(int UserId, string Pw)
        {
            var user = await _context.Users.FindAsync(UserId);
            if (user != null && user.Password == Pw)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> GetLevelByUserIdAsync(int UserId)
        {
            int levelId = await _context.Users.Where(u => u.ID == UserId).Select(u => u.LevelID).FirstOrDefaultAsync();
            string level = await _context.UserLevels.Where(ul => ul.ID == levelId).Select(ul => ul.Level).FirstOrDefaultAsync();
            return level;
        }


    }

}
