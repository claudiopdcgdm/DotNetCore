using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proeventos.Domain;
using Proeventos.Persistence.Interfaces;

namespace Proeventos.Persistence
{
    public class UserPersistence : BasePersistence, IUserPersistence
    {
        public UserPersistence(ProeventosContext context):base(context)
        {
            
        }
       
        public async Task<ICollection<User>> GetUsersAsync()
        {
            IQueryable<User> query = _context.Users;
            query = query.AsNoTracking().OrderBy(u => u.Id);

            return await query.AsSplitQuery().ToArrayAsync();
        
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            // IQueryable<User> query = _context.Users.Where(u => u.Id == id);
            // query = query.AsNoTracking().OrderBy(u => u.Id);
            // return await query.AsSplitQuery().SingleOrDefaultAsync();
            return await _context.Users.FindAsync(id);
            
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            // IQueryable<User> query = _context.Users.Where(u => u.UserName == userName.ToLower());
            // query = query.AsNoTracking().OrderBy(u => u.UserName);

            // return await query.AsSplitQuery().SingleOrDefaultAsync();
            var result = await _context.Users.SingleOrDefaultAsync(user => user.UserName == userName.ToLower());
            // Console.WriteLine(result.UserName);
            return result;
        }

        public async Task<ICollection<User>> GetUserByNameAsync(string name)
        {
            IQueryable<User> query = _context.Users.Where(u => u.FirstName == name);
            query = query.AsNoTracking().OrderBy(u => u.FirstName);
            return await query.AsSplitQuery().ToArrayAsync();
        }

        public Task DisableEnableUserAsync(int idUser, bool isDisable)
        {
            var user = new User{
                Id = idUser,
                LockoutEnabled = true,
                LockoutEnd = isDisable ? DateTimeOffset.MaxValue : null
            };

            _context.Users.Attach(user);
            _context.Entry(user).Property(x => x.LockoutEnabled).IsModified = true;
            _context.Entry(user).Property(x => x.LockoutEnd).IsModified = true;

            return Task.CompletedTask;
        }
    }
}