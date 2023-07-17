using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ITokenService
    {
        #region JWT
        Task<string> GenerateJWTAsync(string Username, string UserLevel);
        Task<bool> ValidateJWTAsync(string jwt, string secretKey);
        Task<bool> CallValidateJWTAsync(string jwt);
        #endregion
    }
}
