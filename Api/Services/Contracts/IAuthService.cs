using Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Contracts
{
    public interface IAuthService
    {
        Task<bool> ValidateLogin(ApiUser user);
        string GenerateToken(DateTime startDateTime, ApiUser user, DateTime expireDateTime);
    }
}
