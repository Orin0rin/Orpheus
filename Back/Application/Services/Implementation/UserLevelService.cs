using Application.Services.Interfaces;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class UserLevelService:IUserLevelService
    {

        private readonly dbDataContext _context;

        public UserLevelService(dbDataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<UserLevel>> GetAllUserLevelsAsync()
        => await _context.UserLevels.ToListAsync();

        public async Task<UserLevel?> GetUserLevelByUserLevelIdAsync(int UserLevelId)
        => await _context.UserLevels.FirstOrDefaultAsync(ul => ul.ID == UserLevelId);
    }
}
