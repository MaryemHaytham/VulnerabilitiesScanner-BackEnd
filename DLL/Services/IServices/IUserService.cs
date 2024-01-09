using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Services.IServices
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        bool ResetPassword(string email, string newPassword);
        bool UpdateProfile(int userId, User updatedUser);
        bool RegisterUser(User user);
        User GetUser(int userId);
        string HashPassword(string password);
    }
}
