using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Repositories;
using UserManagementAPI.DTOs;

namespace UserManagementAPI.Repositories
{
    public interface IUserRepository
    {
        User AddUser(User user);
        bool FindUser(int userId);
        User Validate(string username, string password);
        List<User> GetAllUsers();
        void removeUser(User user_to_remove);
        User GetUserObj(int userId);
    }
}
