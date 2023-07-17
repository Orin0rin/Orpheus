using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    public class UserController : BaseController
    {

        #region Constructor
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        #endregion


        [HttpGet("getAll/{jwt}")]
        public async Task<IActionResult> Get(string jwt)
        {
            var secure = await _tokenService.CallValidateJWTAsync(jwt);

                  var list1 = await _userService.GetAllUsersAsync();

                  var list2 = list1
                    .Select(rec => new
                    {
                        rec.ID,
                        rec.UserName,
                        rec.Password,
                        rec.LevelID,
                        UserLevel = rec.UserLevel.Level,
                        rec.UserImgAddress
                    })
                    .ToList();
            if (secure)
            {
                return Ok(new
                {
                    list = list2
                });
            }
            else
                return Ok("Access Denied!");
        }


        [HttpGet("{username}")]
        
        public async Task<int?> GetByUserName(string username)
        {
            return await _userService.GetUserIdByUsernameAsync(username);
        }

        [HttpGet("check-password/{userName}/{userId}/{password}")]
        public async Task<IActionResult> CheckPasswordAsync(string username, int userId, string password)
        {
            bool isPasswordCorrect = await _userService.IsPasswordCorrectByIdAsync(userId, password);
            string userLevel = await _userService.GetLevelByUserIdAsync(userId);
            string jwt = await _tokenService.GenerateJWTAsync(username, userLevel);
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(1)
            });
            var result = new
            {
                IsPasswordCorrect = isPasswordCorrect,
                UserLevel = userLevel,
                JWT = jwt
            };

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel um)
        {
            await _userService.AddUserAsync(um);
            return Ok("User added successfully.");
        }


        [HttpPut("{id}/{jwt}")]
        public async Task Put(int id, [FromBody] UserModel um, string jwt)
        {
            await _tokenService.CallValidateJWTAsync(jwt);
            await _userService.EditUserByIdAsync(id, um);
        }


        [HttpDelete("{id}/{jwt}")]
        public async Task Delete(int id, string jwt)
        {
            await _tokenService.CallValidateJWTAsync(jwt);
            await _userService.DeleteUserByIdAsync(id);
        }
    }
}
