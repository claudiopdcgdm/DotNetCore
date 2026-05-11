using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Proeventos.Application.Interfaces;
using Proeventos.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Proeventos.Domain;

namespace Proeventos.Application
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public readonly SymmetricSecurityKey _key;

        

        public TokenService(IConfiguration config, UserManager<User> userManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._mapper = mapper;
            this._config = config;
            this._key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
            
        }
        public async Task<string> CreateToken(UserUpdateDto model)
        {
            try
            {
                var user = _mapper.Map<User>(model);
                
                /*
                
                 DEFINE AS INFORMAÇÕES QUE VÃO NO TOKEN
                 - Claims(id do usuario, userName do usuario, e as permissõe (Roles) do usuario)
                */
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                var roles = await _userManager.GetRolesAsync(user);
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role,role)));

                // Defini uma security key para o token, uma key de cripitografia e descripotografia
                var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

                // Adiciona todas as informações que irão no token
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = credentials,
                };
                
                //Transforma em um token jwt
                var tokenHandler = new JwtSecurityTokenHandler();

                // Cria o token de fato
                var token = tokenHandler.CreateToken(tokenDescription);

                return tokenHandler.WriteToken(token);
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na geração do token: {ex.Message}");
            }
        }
    }
}