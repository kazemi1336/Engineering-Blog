using System;
using System.Collections.Generic;
using System.Text;
using EnggBlog.Core.ViewModels;
using EnggBlog.DataLayer.Entities;

namespace EnggBlog.Core.Interfaces
{
    public interface IUser
    {
        User LoginUser(string mobileNumber, string password);

        int GetUserId(string mobileNumber);

        bool CheckUserRole(string roleName, string mobileNumber);

        string GetRoleName(int id);       

    }
}
