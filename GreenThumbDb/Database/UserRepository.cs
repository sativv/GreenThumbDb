using GreenThumbDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbDb.Database
{
    public class UserRepository
    {
        private readonly GreenThumbDbContext _context;
        public UserRepository(GreenThumbDbContext context)
        {
            _context = context;
        }



        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }


        public async Task AddUser(UserModel userToAdd)
        {
            await _context.Users.AddAsync(userToAdd);
        }

    }
}
