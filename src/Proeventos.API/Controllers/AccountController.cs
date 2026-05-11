using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proeventos.Application.Interfaces;
using Proeventos.DTO;
using Proeventos.API.Extensions;
namespace Proeventos.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        
        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            this._tokenService = tokenService;
            this._accountService = accountService;
            
        }
        
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto model)
        {
            try
            {
                var user = await _accountService.UserExists(model.UserName);
                
                // verifica se usuario Não existe
                if (!user)
                {
                    var userCreated = await _accountService.CreateAccountAsync(model);
                    return userCreated != null ? Created("", userCreated) : BadRequest("Erro na Criação de Usuário");
                }
                return BadRequest("Usuário Jah existe!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Usuario.{ex.Message}");                
            }
        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(UserLoginDto model)
        {
            try
            {
                var userUpdateDto = await _accountService.GetUserByUserNameAsync(model.UserName);
                
                // verifica se usuario existe
                if (userUpdateDto != null)
                {
                    var userSignIn = await _accountService.CheckUserPasswordAsync(userUpdateDto, model.Password);
                    if (userSignIn.Succeeded)
                    {
                        return Ok(new 
                            {
                                userName = userUpdateDto.UserName,
                                firstName = userUpdateDto.FirstName,
                                lastName = userUpdateDto.LastName,
                                token = _tokenService.CreateToken(userUpdateDto).Result

                            }
                        );
                    }
                    return Unauthorized("Usuário e ou Senha inválidos!");;
                }
                return BadRequest("Usuário não cadastrado!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar logar.{ex.Message}");                
            }
        }

        
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto model)
        {
            try
            {
                var userUpdateDto = await _accountService.GetUserByUserNameAsync(User.GetUserName());
                
                // verifica se usuario existe
                if (userUpdateDto != null)
                {
                    var userUpdate = await _accountService.UpdateaAccount(model);
                    return userUpdate != null ? Ok(userUpdate):BadRequest("Erro a tentar atualizar dados!");
                    
                }
                return BadRequest("Usuário não cadastrado!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar dados do usuário.{ex.Message}");                
            }
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<UserUpdateDto>> GetUser()
        {
            try
            {
                //User nesse caso é da CLaims do controller
                // Recupera os dados do usuário pelo token
                // var userName = User.FindFirst(ClaimTypes.Name)?.Value; 
                var userName = User.GetUserName();
                var user = await _accountService.GetUserByUserNameAsync(userName);
                return user != null ? Ok(user) : BadRequest("Usuário não encontrado!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Usuario.{ex.Message}");                
            }
        }
    }
}