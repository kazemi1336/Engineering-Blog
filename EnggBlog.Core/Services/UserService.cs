using System;
using System.Collections.Generic;
using System.Text;
using EnggBlog.Core.Interfaces;
using EnggBlog.DataLayer.Entities;

using EnggBlog.DataLayer.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EnggBlog.Core.ViewModels;

namespace EnggBlog.Core.Services
{
    public class UserService : IUser
    {
        EnggBlogContext _context;

        public UserService(EnggBlogContext context)
        {
            _context = context;
        }

        public bool CheckUserRole(string roleName, string mobileNumber)
        {
            return _context.Users.Include(u => u.Role).Any(u => u.Mobile == mobileNumber && u.Role.Name == roleName);
        }

        public string GetRoleName(int id)
        {
            var role = _context.Roles.Find(id);
            return role.Name;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User GetUserByMoble(string mobileNumber)
        {
            return _context.Users.SingleOrDefault(u => u.Mobile == mobileNumber);
        }

        public int GetUserId(string mobileNumber)
        {
            User user = _context.Users.FirstOrDefault(u => u.Mobile == mobileNumber);
            if (user != null)
            {
                return user.UserId;
            }
            else
            {
                return 0;
            }
        }

        public int GetUserIdByMoble(string mobileNumber)
        {
            return _context.Users.Single(u => u.Mobile == mobileNumber).UserId;
        }
        
        public bool IsMobileNumberExist(string mobileNumber)
        {            
         return _context.Users.Any(u => u.Mobile == mobileNumber);           
        }

        public User LoginUser(string mobileNumber, string password)
        {
            string Password = password;
            return _context.Users.FirstOrDefault(u => u.Mobile == mobileNumber && u.Password == Password);
        }
    }
}
