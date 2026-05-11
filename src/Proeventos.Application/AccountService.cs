using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proeventos.Application.Interfaces;
using Proeventos.Domain;
using Proeventos.DTO;
using Proeventos.Persistence.Interfaces;

namespace Proeventos.Application
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserPersistence _userPersistence;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IUserPersistence userPersistence, IMapper mapper)
        {
            this._signInManager = signInManager;
            this._mapper = mapper;
            this._userPersistence = userPersistence;
            this._userManager = userManager;
            
        }

        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto model, string password)
        {
          try
          {
               var user = await _userManager.Users.SingleOrDefaultAsync(user => user.UserName == model.UserName.ToLower());
               var isLocked = user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.Now;

                //verifica se usuario está habilitado
               if (isLocked)
               {
                   return null;
               }
               return await _signInManager.CheckPasswordSignInAsync(user,password,false);
          }
          catch (Exception ex)
          {
            throw new Exception($"Erro ao tentar logar: {ex.Message}");
          }
        }

        public async Task<UserUpdateDto> CreateAccountAsync(UserDto model)
        {
           try
           {
                var userDomain = _mapper.Map<User>(model); //mapeia de Dto para Dominio
                var result = await _userManager.CreateAsync(userDomain, model.Password);

                if (result.Succeeded)
                {
                    var userDto = _mapper.Map<UserUpdateDto>(userDomain); //mapeia de Dominio para Dto
                    return userDto;
                }
                return null;
           }
           catch (Exception ex)
           {
            throw new Exception($"Erro tentar criar usuario: {ex.Message}");
           } 
        }

        public async Task<UserUpdateDto> GetUserByUserNameAsync(string userName)
        {
           try
           {
                var user = await _userPersistence.GetUserByUserNameAsync(userName);
                if (user != null)
                {
                    // var userUpdateDto = _mapper.Map<UserUpdateDto>(user); //Mapeia do retorno Domain para Dto

                    // return userUpdateDto;
                    return _mapper.Map<UserUpdateDto>(user); //Mapeia do retorno Domain para Dto
                }
                return null;
           }
           catch (Exception ex)
           {
            throw new Exception($"Erro ao tentar obter usuario: {ex.Message}");
           }
        }

        public async Task<UserUpdateDto> UpdateaAccount(UserUpdateDto model)
        {
           try
           {
                var user = await _userPersistence.GetUserByUserNameAsync(model.UserName);
                if (user != null)
                {
                    _mapper.Map(model, user); //Mapeia de Dominio para Dto

                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var result = await _userManager.ResetPasswordAsync(user, token, model.Password);

                    _userPersistence.Update<User>(user);

                    if (await _userPersistence.SaveChangesAsync())
                    {
                        var userResult = await _userPersistence.GetUserByUserNameAsync(user.UserName);
                        return _mapper.Map<UserUpdateDto>(userResult);
                    }
                    // return null;
                }
                return null;
           }
           catch (Exception ex)
           {
            throw new Exception($"Erro ao tentar atualizar dados do usuario: {ex.Message}");
           } 
        }

        public async Task<bool> UserExists(string userName)
        {
           try
           {
                var user = await _userManager.Users.AnyAsync(user => user.UserName == userName);
                return user;
           }
           catch (Exception ex)
           {
            throw new Exception($"Erro ao tentar recuperar usuario: {ex.Message}");
           } 
        }
    }
}