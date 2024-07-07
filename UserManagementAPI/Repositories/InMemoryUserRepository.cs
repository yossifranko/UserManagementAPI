using UserManagementAPI.Data;
using UserManagementAPI.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Repositories;
using UserManagementAPI.DTOs;

namespace UserManagementAPI.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public InMemoryUserRepository(UserDbContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool FindUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList(); 
        }


        public User GetUserObj(int userId)
        {
            var user = _context.Users.Find(userId);
            return user;
        }

        public void removeUser( User user_to_remove)
        {
            _context.Users.Remove(user_to_remove);
            _context.SaveChanges();
        }

        public User Validate(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);
        }
    }
}
