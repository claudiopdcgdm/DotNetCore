using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Proeventos.DTO;

namespace Proeventos.Application.Interfaces
{
    public interface IAccountService
    {
        Task<bool> UserExists(string username);
        Task<UserUpdateDto> GetUserByUserNameAsync(string userName);

        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto model, string password);

        Task<UserDto> CreateAccountAsync(UserDto model);
        Task<UserUpdateDto> UpdateaAccount(UserUpdateDto model);
    }
}