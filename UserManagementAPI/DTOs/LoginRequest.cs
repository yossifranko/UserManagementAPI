using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Repositories;
using UserManagementAPI.DTOs;
namespace UserManagementAPI.DTOs
{
    // בקובץ DTOs/LoginRequestDto.cs
    namespace UserManagementAPI.DTOs
    {
        public class LoginRequestDto
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }



}