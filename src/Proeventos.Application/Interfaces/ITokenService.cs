using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proeventos.DTO;

namespace Proeventos.Application.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Gerate token definition
        /// </summary>
        /// <param name="model">UserUpdateDto</param>
        /// <returns>Token</returns>
        Task<string> CreateToken(UserUpdateDto model);
    }
}