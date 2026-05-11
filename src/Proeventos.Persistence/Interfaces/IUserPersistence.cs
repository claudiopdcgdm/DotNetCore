using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proeventos.Domain;

namespace Proeventos.Persistence.Interfaces
{
    public interface IUserPersistence : IBasePersistence
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>Collection of the users</returns>
        Task<ICollection<User>> GetUsersAsync();

        /// <summary>
        /// Get one user by Id
        /// </summary>
        /// <param name="id">id user</param>
        /// <returns>User Object</returns>
        Task<User> GetUserByIdAsync(int id);

        /// <summary>
        /// Get one User by Username
        /// </summary>
        /// <param name="userName">user name</param>
        /// <returns>User object</returns>
        Task<User> GetUserByUserNameAsync(string userName);

        /// <summary>
        /// Get many users by name
        /// </summary>
        /// <param name="name">first name user</param>
        /// <returns>List of the users</returns>
        Task<ICollection<User>> GetUserByNameAsync(string name);

        /// <summary>
        /// Desable user by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>true:success, false:falied</returns>
        Task DisableEnableUserAsync(int idUser, bool isDisable);
    }
        
}